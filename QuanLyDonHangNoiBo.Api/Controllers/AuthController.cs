using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Auth.Commands.Login;
using QuanLyDonHangNoiBo.Application.Features.Auth.Commands.Logout;
using QuanLyDonHangNoiBo.Application.Features.Auth.Queries.Get_Permissions;
using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api/auth")]
[Authorize]
public sealed class AuthController : ControllerBase
{
    private readonly LoginCommandHandler _loginHandler;
    private readonly LogoutCommandHandler _logoutHandler;
    private readonly GetAuthPermissionListQueryHandler _permissionListHandler;
    private readonly JwtTokenService _jwtTokenService;

    public AuthController(
        LoginCommandHandler loginHandler,
        LogoutCommandHandler logoutHandler,
        GetAuthPermissionListQueryHandler permissionListHandler,
        JwtTokenService jwtTokenService)
    {
        _loginHandler = loginHandler;
        _logoutHandler = logoutHandler;
        _permissionListHandler = permissionListHandler;
        _jwtTokenService = jwtTokenService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public ActionResult<LoginResponse> Login(LoginRequest request)
    {
        return Execute(() =>
        {
            var loginResponse = _loginHandler.Handle(new LoginCommand(request));
            var token = _jwtTokenService.GenerateAccessToken(loginResponse.Tenant, loginResponse.User, loginResponse.Permissions);
            return loginResponse with { AccessToken = token };
        });
    }

    [HttpPost("logout")]
    public ActionResult<LogoutResponse> Logout(LogoutRequest request)
    {
        return Execute(() => _logoutHandler.Handle(new LogoutCommand(request)));
    }

    [HttpGet("permissions")]
    [Authorize(Policy = PermissionPolicies.UsersManage)]
    public ActionResult<IReadOnlyList<string>> GetPermissions([FromQuery] UserRole role)
    {
        return Execute(() => _permissionListHandler.Handle(new GetAuthPermissionListQuery(role)));
    }

    private ActionResult<T> Execute<T>(Func<T> action)
    {
        return Ok(action());
    }
}
