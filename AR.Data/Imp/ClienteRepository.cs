using AP.Domain;
using AR.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AR.Data.Imp
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ContextoPrincipal _db;

        public ClienteRepository(ContextoPrincipal db)
        {
            _db = db;
        }

        public async Task Post(Cliente entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Cliente> Get(int id)
        {
            return await _db.Cliente.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task RemoveAt(int id)
        {
            var t = await Get(id);
            if (t != null)
                _db.Remove(t);

            await _db.SaveChangesAsync();
        }

        public IQueryable<Cliente> GetAll()
        {
            return _db.Cliente;
        }
    }
}