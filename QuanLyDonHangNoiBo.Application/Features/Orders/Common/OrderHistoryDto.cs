namespace QuanLyDonHangNoiBo.Application.Features.Orders.Common;

public sealed record OrderHistoryDto(OrderStatus OldStatus, OrderStatus NewStatus, string Note, DateTimeOffset ChangedAt);


