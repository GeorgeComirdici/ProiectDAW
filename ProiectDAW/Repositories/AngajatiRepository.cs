using ProiectDAW.Models;
using ProiectDAW.Interfaces;
using ProiectDAW.data;

namespace ProiectDAW.Repositories
{
    public class AngajatiRepository : IAngajatiRepository
    {
        private ProiectDAWcontext context;
        public AngajatiRepository(ProiectDAWcontext context)
        {
            this.context = context;
        }

        public ICollection<detaliiAngajati>GetAngajati()
        {
            return context.detaliiAngajatis.OrderBy(p => p.IdAngajat).ToList();
        }

        public detaliiAngajati GetAngajatiById(int IdAngajat)
        {
            return context.detaliiAngajatis.Find(IdAngajat);
        }

        public detaliiAngajati GetAngajatiByNume(string nume)
        {
            return context.detaliiAngajatis.Find(nume);
        }

        public void InsertAngajati(detaliiAngajati detaliiAngajati)
        {
            context.detaliiAngajatis.Add(detaliiAngajati);
            Save();
        }

        public void DeleteAngajati(int IdAngajat)
        {
            detaliiAngajati detaliiAngajati = context.detaliiAngajatis.Find(IdAngajat);
            context.detaliiAngajatis.Remove(detaliiAngajati);
            Save();
        }

        public void UpdateAngajati(detaliiAngajati detaliiAngajati)
        {
            context.detaliiAngajatis.Update(detaliiAngajati);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
