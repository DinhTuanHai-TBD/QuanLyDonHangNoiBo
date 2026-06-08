namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public AiChatResponse AskAi(AiChatRequest request)
    {
        var tenantId = ResolveTenantId(request.TenantId);
        var question = request.Question.Trim();
        if (string.IsNullOrWhiteSpace(question))
        {
            throw new InvalidOperationException("Cau hoi khong duoc de trong.");
        }

        var normalized = question.ToLowerInvariant();
        var orders = _repository.Orders.Where(item => item.TenantId == tenantId).ToList();
        var cods = _repository.CodCollections.Where(item => item.TenantId == tenantId).ToList();
        var lowStocks = GetInventoryStocks(tenantId, null, null).Where(item => item.IsLowStock).ToList();
        var links = new List<RelatedLinkDto>();
        string answer;

        if (normalized.Contains("cod") || normalized.Contains("doi soat") || normalized.Contains("thu ho"))
        {
            var pending = cods.Where(item => item.Status is CodStatus.Pending or CodStatus.Collected).ToList();
            answer = $"Hien co {pending.Count} phieu COD can doi soat, tong gia tri {FormatMoney(pending.Sum(item => item.ExpectedAmount))}. Uu tien xu ly cac phieu da thu tien nhung chua reconcile.";
            links.Add(new RelatedLinkDto("Mo man hinh COD", "/finance"));
        }
        else if (normalized.Contains("ton kho") || normalized.Contains("sap het") || normalized.Contains("kho"))
        {
            answer = lowStocks.Count == 0
                ? "Chua co SKU nao duoi nguong canh bao. Nen tiep tuc theo doi hang ban nhanh trong 7 ngay gan nhat."
                : $"Co {lowStocks.Count} SKU sap het hang. SKU can uu tien: {string.Join(", ", lowStocks.Take(3).Select(item => $"{item.SkuCode} ({item.Available})"))}.";
            links.Add(new RelatedLinkDto("Mo ton kho", "/inventory"));
        }
        else if (normalized.Contains("tre") || normalized.Contains("trĂ¡Â»â€¦") || normalized.Contains("that bai") || normalized.Contains("thĂ¡ÂºÂ¥t bĂ¡ÂºÂ¡i"))
        {
            var risky = orders.Where(item =>
                item.Status is OrderStatus.InTransit or OrderStatus.Failed ||
                item.SlaDeadline < DateTimeOffset.UtcNow).ToList();
            answer = $"Tim thay {risky.Count} don co rui ro giao tre/that bai. Nen loc theo trang thai InTransit va Failed de dieu phoi lai.";
            links.Add(new RelatedLinkDto("Mo dieu phoi giao hang", "/delivery"));
            links.Add(new RelatedLinkDto("Mo danh sach don", "/orders"));
        }
        else
        {
            var delivered = orders.Count(item => item.Status == OrderStatus.Delivered);
            answer = $"Tong quan hom nay: he thong co {orders.Count} don, {delivered} don da giao thanh cong, {lowStocks.Count} SKU sap het hang va {cods.Count(item => item.Status != CodStatus.Reconciled)} phieu COD chua hoan tat.";
            links.Add(new RelatedLinkDto("Mo dashboard", "/dashboard"));
        }

        var suggested = new[]
        {
            "Hom nay co bao nhieu don giao tre?",
            "Kho nao sap het hang?",
            "COD nao chua doi soat?",
            "Don nao co nguy co giao that bai?"
        };

        return new AiChatResponse(answer, links, suggested);
    }
}

