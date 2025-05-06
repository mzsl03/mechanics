using AutoSzereloMuhely.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AutoSzereloMuhely.API.Controller;


[ApiController]
[Route("ugyfel")]
public class UgyfelController : ControllerBase
{
    private readonly IUgyfelService _ugyfelService;
    
    public UgyfelController(IUgyfelService ugyfelService)
    {
        _ugyfelService = ugyfelService;
    }
    
    [HttpPost]
    public IActionResult Add([FromBody] Ugyfel ugyfel)
    {
        _ugyfelService.Add(ugyfel);
        return Ok();
    }
    
    [HttpGet]
    public ActionResult<List<Ugyfel>> GetAll()
    {
        var ugyfelek = _ugyfelService.GetAll();
        return Ok(ugyfelek);
    }
    
    [HttpGet("id")]
    public ActionResult<Ugyfel> Get(int id)
    {
        var ugyfel = _ugyfelService.Get(id);
        return ugyfel;
    }
    
    [HttpDelete("id")]
    public ActionResult Delete(int id)
    {
        var ugyfel = _ugyfelService.Get(id);
        if (ugyfel is not null)
        {
            _ugyfelService.Delete(ugyfel.UgyfelId);    
        }

        return Ok();
    }
    
}