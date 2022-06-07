using System.Collections.Generic;
using System.Linq;
using AULA13.Domains;
using AULA13.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AULA13.Repositories
{
  public class ClienteRepository : IClienteRepository
  {
    private DataContext context;
    public ClientRepository(DataContext context)
    {
      this.context = context;
    }
    public void Create(Client client)
    {
      context.Add(client);
      context.SaveChanges();
    }

    public List<Client> GetAll()
    {
      return context.Clientes.ToList();
    }

    public Client GetById(int id)
    {
      return context.Clients.SingleOrDefault(x => x.Id == id);
    }

    public void Delete(Client client)
    {
      context.Clients.Remove(client);
      context.SaveChanges();
    }

    public void Update(Client client)
    {
      context.Entry(client).State = EntityState.Modified;
      context.SaveChanges();
    }
  }
}