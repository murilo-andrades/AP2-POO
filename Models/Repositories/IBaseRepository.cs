namespace AULA13.Models.Repositories
{
    public interface IBaseRepository <Entidade>
        where Entidade : class
    {
        Entidade GetById(int id);
        List<Entidade> GetAll();
        void Create(Entidade obj);
        void Delete(Entidade obj);
        void Update(Entidade obj);
    }
}