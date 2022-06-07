using System.Collections.Generic;
using AULA13.Domains;
using AULA13.Models.Repositories;
using AULA13.Repositories;
using AULA13.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AULA13.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ClientController : ControllerBase
  {
    private readonly IClienteRepository repository;

    public ClientController(IClienteRepository clienteRepository)
    {
      this.repository = clienteRepository;
    }

    [HttpGet()] 
    public IEnumerable<Client>Get()
    {
      return repository.GetAll();
    }

    [HttpGet("{id}")] 
    public IActionResult Get([FromRoute] int id)
    {
      var cliente = repository.GetById(id);

      if (cliente == null)return NotFound();
      else return Ok(cliente);
    }

    [HttpPost()] 
    public IActionResult Post([FromBody]Client cliente)
    {
      repository.Create(cliente);
      return Ok(cliente);
    }

    [HttpDelete("{id}")] 
    public IActionResult Delete([FromRoute]int id)
    {
      var cliente = repository.GetById(id);
      if (cliente == null) return NotFound();

      repository.Delete(cliente);
      return Ok(cliente);
    }

    [HttpPut("{id}")] 
    public IActionResult Put([FromRoute]int id, [FromBody] ClientUpdate update)
    {
      var cliente = repository.GetById(id);
      if (cliente == null) return NotFound();

      cliente.Nome = update.Nome;
      cliente.Email = update.Email;
      cliente.Cpf = update.Cpf;
      cliente.Fone = update.Fone;
      cliente.Endereco = update.Endereco;

      repository.Update(cliente);
      return Ok(cliente);
    }
  }
}