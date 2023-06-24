using iDelivery.Api.Controllers.Common;
using iDelivery.Application.Commands.AddCommands;
using iDelivery.Application.Commands.GetCommands;
using iDelivery.Contracts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace iDelivery.Api.Controllers;
 public class CommandsController : ApiBaseController
 {
    private readonly ISender _sender;

    public CommandsController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost]
    public async Task<IActionResult> PostCommand(AddCommandRequest request)
    {
        // création d'une commande
        AddCommand command = new AddCommand ("Papier10","format");
        //envoie de la commande
        var response = await _sender.Send(command);
        
        return Ok (response);
    }

    [HttpPut("{id}/{ref_num}")]
    public async Task<IActionResult> PutCommand(int id, int ref_num, UpdateCommandRequest updateCommand)
    {
        UpdateCommand command = new UpdateCommand(1);
        var response = await _sender.Send(command);
        return Ok (updateCommand);
    }

    [HttpPut("{id}")]
    public IActionResult PutCommand(int id, UpdateCommand request)
    {
        return Ok(request);
    }

    [HttpGet]
    public async Task<IActionResult> GetCommand(DisplayCommandRequest displayCommand)
    {
        GetCommand command = new GetCommand();
        var result = await _sender.Send(command);
        return Ok(result);
    }
 }