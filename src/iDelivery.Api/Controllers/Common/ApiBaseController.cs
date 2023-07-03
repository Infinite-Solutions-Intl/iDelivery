using iDelivery.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Controllers.Common;

[ApiController]
[ApiKeyAuthorize]
[Route("[controller]")]
public abstract class ApiBaseController : ControllerBase
{
}
