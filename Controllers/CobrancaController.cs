using AULA13.Models.Domains;
using AULA13.Models.Repositories;
using AULA13.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AULA13.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CobrancaController : ControllerBase
  {
    private readonly ICobrancaRepository repository;
    public CobrancaController(ICobrancaRepository cobrancaRepository)
    {
      this.repository = cobrancaRepository;
    }

    [HttpGet()] 
    public IEnumerable<Cobranca>Get()
    {
      return repository.GetAll();
    }

    [HttpGet("{id}")] 
    public IActionResult Get([FromRoute] int id)
    {
      var cobranca = repository.GetById(id);
      if (cobranca == null)return NotFound();
      else return Ok(cobranca);
    }
    
    [HttpPost()] 
    public IActionResult Post([FromBody]Cobranca cobranca)
    {
      repository.Create(cobranca);
      return Ok(cobranca);
    }

    [HttpDelete("{id}")] 
    public IActionResult Delete([FromRoute]int id)
    {
      var cobranca = repository.GetById(id);
      if (cobranca == null) return NotFound();

      repository.Delete(cobranca);
      return Ok(cobranca);
    }

    [HttpPut("{id}")] 
    public IActionResult Put([FromRoute]int id, [FromBody] CobrancaVencimentoUpdate update)
    {
      var cobranca = repository.GetById(id);
      if (cobranca == null) return NotFound();

      cobranca.DataVencimento = update.DataVencimento;
      repository.Update(cobranca);
      return Ok(cobranca);
    }

    [HttpPatch("{id}")] 
    public IActionResult Patch([FromRoute]int id, [FromBody] CobrancaPagamentoUpdate update)
    {
      var cobranca = repository.GetById(id);
      if (cobranca == null) return NotFound();
      cobranca.DataPagamento = DateTime.Now;
      repository.Update(cobranca);
      return Ok(cobranca);
    }
  }
}