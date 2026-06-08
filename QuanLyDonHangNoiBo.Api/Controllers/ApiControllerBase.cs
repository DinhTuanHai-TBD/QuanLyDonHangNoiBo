using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyDonHangNoiBo.Application.Features.Oms;

namespace QuanLyDonHangNoiBo.Api.Controllers;

// Base controller dung chung cho cac API controller: inject service va gom cac helper response.
[Authorize]
public abstract class ApiControllerBase : ControllerBase
{
    protected readonly OmsApplicationService Service;

    protected ApiControllerBase(OmsApplicationService service)
    {
        Service = service;
    }

    protected ActionResult<T> Execute<T>(Func<T> action)
    {
        return Ok(action());
    }

    protected IActionResult Execute(Action action)
    {
        action();
        return NoContent();
    }
}





