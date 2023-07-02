using iDelivery.Api.Controllers.Common;
using iDelivery.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Controllers;

[JwtAuthorize(Roles = "admin")]
public class UsersController : ApiBaseController
{
    [HttpGet("secret")]
    public IActionResult GetSecret()
    {
        return Ok("Secret");
    }
}
