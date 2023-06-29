using Microsoft.AspNetCore.Mvc;
using ProjetoBApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoBApi.Controllers;

[ApiController]
[Route("folha")]
public class FolhaController : ControllerBase
{
  private readonly ILogger<FolhaController> _logger;
  private readonly FolhaContext _context;

  public FolhaController(ILogger<FolhaController> logger, FolhaContext context)
  {
    _logger = logger;
    _context = context;
  }

  [HttpGet("listar")]
  public IEnumerable<FolhaCalculadaDTO> GetAll()
  {
    return _context.Folhas.Select(x => x.toDTO());
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

    return Ok(folha.toDTO());
  }

  [HttpPost(Name = "CreateFolha")]
  public async Task<IActionResult> CreateAsync(FolhaCalculadaDTO dto)
  {
    try
    {
      var folha = FolhaCalculada.fromDTO(dto);
      _context.Folhas.Add(folha);
      await _context.SaveChangesAsync();
      return CreatedAtAction("GetOne", new { id = folha.Id }, dto);
    }
    catch (Exception e)
    {
      _logger.LogError(e.Message);
      return BadRequest();
    }
  }
  
  [HttpGet("total")]
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