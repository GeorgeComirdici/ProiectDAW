using ProiectDAW.Models;
using ProiectDAW.Interfaces;
using ProiectDAW.data;

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
            return _context.detaliiAngajatis.OrderBy(p => p.IdAngajat).ToList();
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

        public void UpdateAngajati(detaliiAngajati detaliiAngajati)
        {
            _context.detaliiAngajatis.Update(detaliiAngajati);
            Save();
        }

        public bool Save()
        {
            var salvat = _context.SaveChanges();
            return salvat > 0 ? true : false;
        }
    }
}
