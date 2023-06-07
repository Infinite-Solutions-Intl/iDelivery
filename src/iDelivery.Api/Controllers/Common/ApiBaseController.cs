using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Controllers.Common;

[ApiController]
[Route("[controller]")]
public abstract class ApiBaseController : ControllerBase
{
}
