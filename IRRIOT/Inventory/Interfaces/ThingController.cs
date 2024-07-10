
using API.Inventory.Domain.Model.Queries;
using API.Inventory.Domain.Service;
using API.Inventory.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace API.Inventory.Interfaces;
    
[ApiController]
[Route("api/v1/[Controller]")]
public class ThingController : ControllerBase
{
    private readonly IThingCommandService _thingCommandService;
    private readonly IThingQueryService _thingQueryService;

    public ThingController(IThingCommandService thingCommandService, IThingQueryService thingQueryService)
    {
        _thingCommandService = thingCommandService;
        _thingQueryService = thingQueryService;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateThing(CreateThingResource resource)
    {
        var createThingCommand = CreateThingCommandFromResourceAssembler.ToCommandFromResource(resource);
        var thing = await _thingCommandService.Handle(createThingCommand);
        var thingResource = ThingResourceFromEntityAssembler.ToResourceFromEntity(thing);
        return StatusCode(201, thingResource);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ThingResource>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetThingById(int thingId)
    {
        var thing = await _thingQueryService.Handle(new GetAllThingById(thingId));
        if (thing is null) return BadRequest();
        var thingResource = ThingResourceFromEntityAssembler.ToResourceFromEntity(thing);
        return Ok(thingResource);
    }
}
