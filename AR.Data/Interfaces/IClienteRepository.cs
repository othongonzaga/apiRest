using AP.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace AR.Data.Interfaces
{
    public interface IClienteRepository
    {
        IQueryable<Cliente> GetAll();
        Task Post(Cliente entity);
        Task RemoveAt(int id);
        Task<Cliente> Get(int id);
    }
}