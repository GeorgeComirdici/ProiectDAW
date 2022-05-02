using ProiectDAW.Models;
using ProiectDAW.Interfaces;
using ProiectDAW.data;
namespace ProiectDAW.Repositories
{
    public class proiecteRepository : IproiecteRepository
    {
        private ProiectDAWcontext context;
        public proiecteRepository(ProiectDAWcontext context)
        {
            this.context = context;
        }
        public ICollection<proiecte> GetProiect()
        {
            return context.proiectes.OrderBy(p => p.IdProiect).ToList();
        }
        public void InsertProiect(proiecte proiecte)
        {
            context.proiectes.Add(proiecte);
            Save();
        }

        public void DeleteProiect(int IdProiect)
        {
            proiecte proiecte = context.proiectes.Find(IdProiect);
            context.proiectes.Remove(proiecte);
            Save();
        }

        public void UpdateProiect(proiecte proiecte)
        {
            context.proiectes.Update(proiecte);
            Save();
        }

        public proiecte GetProiectById(int IdProiect)
        {
            return context.proiectes.Find(IdProiect);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
