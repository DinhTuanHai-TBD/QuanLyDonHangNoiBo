namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<UserDto> GetUsers(UserQuery query)
    {
        var resolvedTenantId = ResolveTenantId(query.TenantId);
        var users = _repository.Users.Where(item => item.TenantId == resolvedTenantId);

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            users = users.Where(item =>
                Contains(item.FullName, query.Search) ||
                Contains(item.Email, query.Search) ||
                Contains(item.Role.ToString(), query.Search));
        }

        if (query.Role.HasValue)
        {
            users = users.Where(item => item.Role == query.Role.Value);
        }

        if (query.IsActive.HasValue)
        {
            users = users.Where(item => item.IsActive == query.IsActive.Value);
        }

        return users
            .OrderByDescending(item => item.IsActive)
            .ThenBy(item => item.Role)
            .ThenBy(item => item.FullName)
            .Select(ToUserDto)
            .ToList();
    }
}

