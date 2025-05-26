using AutoSzereloMuhely.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AutoSzereloMuhely.API.Controller;


[ApiController]
[Route("api/munka")]
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
        _munkaService.Add(munka);
        return Ok();
    }

    [HttpGet]
    public ActionResult<List<Munka>> GetAll()
    {
        var munkak = _munkaService.GetAll();
        return Ok(munkak ?? new List<Munka>());
    }

    [HttpGet("{id}")]
    public ActionResult<Munka> Get(int id)
    {
        try
        {
            var munka = _munkaService.Get(id);
            return munka is not null ? Ok(munka) : NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Hiba történt: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var munka = _munkaService.Get(id);
        if (munka is not null)
        {
            _munkaService.Delete(munka.MunkaID);    
        }
        else
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Munka munka)
    {
        if (id != munka.MunkaID)
        {
            return BadRequest();
        }

        var oldMunka = _munkaService.Get(munka.MunkaID);

        if (oldMunka is null)
        {
            return NotFound();
        }
        _munkaService.Update(munka);
        return Ok();
    }
    
}