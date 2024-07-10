
using API.Observability.Domain.Service;
using API.Observability.Interfaces.REST.Resources;
using API.Observability.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace API.Observability.Interfaces;

[ApiController]
[Route("api/v1/Thing-states")]
public class ThingStateController : ControllerBase
{
    private readonly IThingStateCommandService _thingStateCommandService;

    public ThingStateController(IThingStateCommandService thingStateCommandService)
    {
        _thingStateCommandService = thingStateCommandService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateThingState(CreateThingStateResource resource)
    {
        var command = CreateThingStateCommandFromResourceAssembler.ToCommandFromResource(resource);
        var createdThingState = await _thingStateCommandService.Handle(command);
        var thingStateResource = ThingStateResourceFromEntityAssembler.ToResourceFromEntity(createdThingState);
        
        return CreatedAtAction(nameof(CreateThingState), thingStateResource);
    }
}
