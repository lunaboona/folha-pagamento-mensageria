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
  
  [HttpGet("total")]
  public IActionResult GetTotal()
  {
    var folhas = GetAll().ToList();
    var total = new TotalDto
    {
      Total = folhas
        .Select(folha => folha.Liquido)
        .Sum()
    };
    return Ok(total);
  }
  
  
  [HttpGet("media")]
  public IActionResult GetMedia()
  {
    var folhas = GetAll().ToList();
    var media = new TotalDto
    {
      Quantidade = folhas.Count,
      Total = folhas
        .Select(folha => folha.Liquido)
        .Sum(),
      Media = folhas
        .Select(folha => folha.Liquido)
        .Average()
    };
    return Ok(media);
  }
}