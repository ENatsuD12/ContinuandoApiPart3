using Mangas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Features.Mangas;

namespace Mangas.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class MangaController : ControllerBase
{
    private readonly MangaService _mangaService;

    private MangaController(MangaService mangaService)
    {
        this._mangaService = mangaService;

    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_mangaService.GetAll());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var manga = _mangaService.GetById(id);
        if (manga == null)
        {
            return NotFound();
        }
        return Ok(manga);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Manga manga)
    {
        _mangaService.add(manga);
        return CreatedAtAction(nameof(GetById), new {id = manga.id}, manga);
    }

    [HttpPut]
    public IActionResult Update(int id, Manga manga)
    {
        if (id != manga.id)
        {
            return BadRequest();
        }
        
        _mangaService.update(manga);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _mangaService.delete(id);
        return NoContent();
    }
}
