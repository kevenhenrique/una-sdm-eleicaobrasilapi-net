using EleicaoBrasilApi.Data;
using EleicaoBrasilApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace EleicaoBrasilApi.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
    public class CandidatosController : ControllerBase
{
    private readonly AppDbContext _context;
    public CandidatosController(AppDbContext context) => _context = context;

    [HttpGet]

    public IActionResult Get() => Ok(_context.candidatos.ToList());

    [HttpPost]
    public IActionResult Put(int id, Candidato c)
    {
      var existing = _context.candidatos.Find(id);
      if (existing == null) return NotFound();
      existing.Nome = c.Nome;
      _context.candidatos.Update(existing);
      _context.SaveChanges();
      return NoContent();

    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var c = _context.candidatos.Find(id);
        if (c == null) return NotFound();
        _context.candidatos.Remove(c);
        _context.SaveChanges();
        return NoContent();
    }
}
}