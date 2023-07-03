using iDelivery.Api.Controllers.Common;
using iDelivery.Domain.Common.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Controllers;

[Authorize(Policy = Policies.AdminOnly)]
public class UsersController : ApiBaseController
{
    [HttpGet("secret")]
    public IActionResult GetSecret()
    {
        return Ok("Secret");
    }
}
