using Microsoft.AspNetCore.Mvc;
using ProjetoBApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaApi.Controllers;

[ApiController]
[Route("/folha")]
public class ItemController : ControllerBase
{
  private readonly ILogger<ItemController> _logger;
  private readonly FolhaContext _context;

  public ItemController(ILogger<ItemController> logger, FolhaContext context)
  {
    _logger = logger;
    _context = context;
  }

  [HttpGet(Name = "GetAllFolhas")]
  public IEnumerable<FolhaCalculada> GetAll()
  {
    return _context.Folhas;
  }

  [HttpGet("{id}", Name = "GetOneFolha")]
  public async Task<IActionResult> GetOneAsync(long id)
  {
    FolhaCalculada? folha;
    try
    {
      folha = await _context.Folhas.FindAsync(id);
    }
    catch (Exception e)
    {
      _logger.LogError(e.Message);
      return BadRequest();
    }

    if (folha == null)
    {
      return NotFound();
    }

    return Ok(folha);
  }

  [HttpPost(Name = "CreateFolha")]
  public async Task<IActionResult> CreateAsync(FolhaCalculada folha)
  {
    try
    {
      _context.Folhas.Add(folha);
      await _context.SaveChangesAsync();
      return CreatedAtAction("GetOne", new { id = folha.Id }, folha);
    }
    catch (Exception e)
    {
      _logger.LogError(e.Message);
      return BadRequest();
    }
  }
  
  [HttpGet(Name = "total")]
  public IActionResult GetTotal()
  {
    var folhas = GetAll();
    var total = new TotalDto
    {
      Total = folhas
        .Select(folha => folha.Liquido)
        .Sum()
    };
    return Ok(total);
  }
}