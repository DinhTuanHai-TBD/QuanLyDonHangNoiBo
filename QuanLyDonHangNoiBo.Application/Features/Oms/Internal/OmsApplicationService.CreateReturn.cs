namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public ReturnDto CreateReturn(CreateReturnRequest request)
    {
        var tenantId = ResolveTenantId(request.TenantId);
        var order = FindOrder(request.OrderId);
        if (order.TenantId != tenantId)
        {
            throw new InvalidOperationException("Don hang khong thuoc tenant hien tai.");
        }

        if (string.IsNullOrWhiteSpace(request.Reason))
        {
            throw new InvalidOperationException("Ly do hoan hang la bat buoc.");
        }

        var returnRequest = new ReturnRequest
        {
            TenantId = tenantId,
            OrderId = order.Id,
            ReturnCode = $"RET-{DateTimeOffset.UtcNow:yyMMdd}-{_repository.Returns.Count(item => item.TenantId == tenantId) + 1:0000}",
            Status = ReturnStatus.Requested,
            Reason = request.Reason.Trim(),
            RefundAmount = request.RefundAmount > 0 ? request.RefundAmount : order.Total,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow
        };

        _repository.AddReturn(returnRequest);
        _repository.AddAuditLog(new AuditLog
        {
            TenantId = tenantId,
            EntityName = nameof(ReturnRequest),
            EntityId = returnRequest.Id.ToString(),
            Action = "CreateReturn",
            AfterValue = returnRequest.ReturnCode
        });

        return ToReturnDto(returnRequest);
    }
}

