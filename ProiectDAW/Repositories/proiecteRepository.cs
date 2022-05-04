using ProiectDAW.Models;
using ProiectDAW.Interfaces;
using ProiectDAW.data;
namespace ProiectDAW.Repositories
{
    public class proiecteRepository : IproiecteRepository
    {
        private readonly ProiectDAWcontext _context;
        public proiecteRepository(ProiectDAWcontext context)
        {
            _context = context;
        }
        public ICollection<proiecte> GetProiect()
        {
            return _context.proiectes.OrderBy(p => p.IdProiect).ToList();
        }
        public bool InsertProiect(proiecte proiecte)
        {
            _context.Add(proiecte);
            return Save();
        }

        public bool DeleteProiect(proiecte proiecte)
        {
            _context.Remove(proiecte);
            return Save();
        }

        public bool UpdateProiect(proiecte proiecte)
        {
            _context.Update(proiecte);
            return Save();
        }

        public proiecte GetProiectById(int IdProiect)
        {
            return _context.proiectes.Where(p => p.IdProiect == IdProiect).FirstOrDefault();
        }

        public bool Save()
        {
            var salvat = _context.SaveChanges();
            return salvat > 0 ? true : false;
        }
    }
}
