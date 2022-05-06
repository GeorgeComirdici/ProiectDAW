using ProiectDAW.Models;
using ProiectDAW.Interfaces;
using ProiectDAW.data;
using Microsoft.EntityFrameworkCore;

namespace ProiectDAW.Repositories
{
    public class AngajatiRepository : IAngajatiRepository
    {
        private readonly ProiectDAWcontext _context;
        public AngajatiRepository(ProiectDAWcontext context)
        {
            _context = context;
        }

        public ICollection<detaliiAngajati>GetAngajati()
        {
            return _context.detaliiAngajatis.OrderBy(p => p.IdAngajat).Include(u => u.Adresa).ToList();
        }

        public detaliiAngajati GetAngajatiById(int IdAngajat)
        {
            return _context.detaliiAngajatis.Where(p => p.IdAngajat == IdAngajat).FirstOrDefault();
        }

        //public detaliiAngajati GetAngajatiByNume(string nume)
        //{
            //return context.detaliiAngajatis.Find(nume);
        //}

        public bool InsertAngajati(detaliiAngajati detaliiAngajati)
        {
            _context.Add(detaliiAngajati);
            return Save();
        }

        public bool DeleteAngajati(detaliiAngajati detaliiAngajati)
        {
            _context.Remove(detaliiAngajati);
            return Save();
        }

        public bool UpdateAngajati(detaliiAngajati detaliiAngajati)
        {
            _context.Update(detaliiAngajati);
            return Save();
        }

        public detaliiAngajati GetAngajatByEmail(string Email)
        {
            return _context.detaliiAngajatis.Where(u => u.Email == Email).FirstOrDefault();
        }
        public bool Save()
        {
            var salvat = _context.SaveChanges();
            return salvat > 0 ? true : false;
        }
    }
}
