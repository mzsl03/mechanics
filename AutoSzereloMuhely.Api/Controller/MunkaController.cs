using AutoSzereloMuhely.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AutoSzereloMuhely.API.Controller;


[ApiController]
[Route("munka")]
public class MunkaController : ControllerBase
{
    private readonly IMunkaService _munkaService;

    public MunkaController(IMunkaService munkaService)
    {
        _munkaService = munkaService;
    }

    [HttpPost]
    public IActionResult Add([FromBody] Munka munka)
    {
        var exists = _munkaService.Get(munka.MunkaID);

        if (exists is not null)
        {
            return Conflict();
        }

        _munkaService.Add(munka);
        return Ok();
    }
    
}