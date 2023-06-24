using iDelivery.Api.Controllers.Common;
using iDelivery.Contracts.Commands;
using Microsoft.AspNetCore.Mvc;
namespace iDelivery.Api.Controllers;
 public class CommandsController : ApiBaseController
 {
    [HttpPost]
    public IActionResult PostCommand(AddCommandRequest request)
    {
        return Ok (request);
    }

    [HttpPut("{id}/{ref_num}")]
    public IActionResult PutCommand(int id, int ref_num, UpdateCommandRequest updateCommand)
    {
        return Ok (updateCommand);
    }

    [HttpPut("{id}")]
    public IActionResult PutCommand(int id, UpdateCommand request)
    {
        return Ok(request);
    }

    [HttpGet]
    public IActionResult GetCommand(DisplayCommandRequest displayCommand)
    {
        return Ok(displayCommand);
    }
 }