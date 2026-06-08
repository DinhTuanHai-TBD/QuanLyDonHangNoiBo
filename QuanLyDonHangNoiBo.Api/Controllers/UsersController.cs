using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UsersController : ApiControllerBase
{
    public UsersController(OmsApplicationService service)
        : base(service)
    {
    }

    [HttpGet]
    [Authorize(Policy = PermissionPolicies.UsersManage)]
    public ActionResult<IReadOnlyList<UserDto>> GetUsers([FromQuery] UserQuery query)
    {
        return Execute(() => Service.GetUsers(query));
    }

    [HttpGet("{userId:guid}")]
    [Authorize(Policy = PermissionPolicies.UsersManage)]
    public ActionResult<UserDto> GetUser(Guid userId)
    {
        return Execute(() => Service.GetUser(userId));
    }

    [HttpPost]
    [Authorize(Policy = PermissionPolicies.UsersManage)]
    public ActionResult<UserDto> CreateUser(CreateUserRequest request)
    {
        return Execute(() => Service.CreateUser(request));
    }

    [HttpPut("{userId:guid}")]
    [Authorize(Policy = PermissionPolicies.UsersManage)]
    public ActionResult<UserDto> UpdateUser(Guid userId, UpdateUserRequest request)
    {
        return Execute(() => Service.UpdateUser(userId, request));
    }

    [HttpPost("{userId:guid}/activate")]
    [Authorize(Policy = PermissionPolicies.UsersManage)]
    public ActionResult<UserDto> ActivateUser(Guid userId, UserActionRequest? request)
    {
        return Execute(() => Service.SetUserActive(userId, true, request?.UserId));
    }

    [HttpPost("{userId:guid}/deactivate")]
    [Authorize(Policy = PermissionPolicies.UsersManage)]
    public ActionResult<UserDto> DeactivateUser(Guid userId, UserActionRequest? request)
    {
        return Execute(() => Service.SetUserActive(userId, false, request?.UserId));
    }

    [HttpDelete("{userId:guid}")]
    [Authorize(Policy = PermissionPolicies.UsersManage)]
    public IActionResult DeleteUser(Guid userId, [FromQuery] Guid? deletedByUserId)
    {
        return Execute(() => Service.DeleteUser(userId, deletedByUserId));
    }
}





