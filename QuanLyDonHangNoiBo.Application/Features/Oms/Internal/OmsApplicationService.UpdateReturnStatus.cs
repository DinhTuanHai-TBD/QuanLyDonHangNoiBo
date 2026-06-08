namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public ReturnDto UpdateReturnStatus(Guid returnId, UpdateReturnStatusRequest request)
    {
        var returnRequest = FindReturn(returnId);
        var before = returnRequest.Status;
        returnRequest.Status = request.Status;
        returnRequest.UpdatedAt = DateTimeOffset.UtcNow;

        if (request.Status == ReturnStatus.Approved)
        {
            returnRequest.ApprovedByUserId = request.UserId;
        }

        if (request.Status == ReturnStatus.Received)
        {
            RestockReturn(returnRequest);
            UpdateOrderStatusInternal(returnRequest.OrderId, OrderStatus.Returned, request.Note, request.UserId, null);
        }

        _repository.AddAuditLog(new AuditLog
        {
            TenantId = returnRequest.TenantId,
            UserId = request.UserId,
            EntityName = nameof(ReturnRequest),
            EntityId = returnRequest.Id.ToString(),
            Action = "ChangeReturnStatus",
            BeforeValue = before.ToString(),
            AfterValue = returnRequest.Status.ToString()
        });

        return ToReturnDto(returnRequest);
    }
}

