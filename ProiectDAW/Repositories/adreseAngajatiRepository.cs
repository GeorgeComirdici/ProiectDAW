using ProiectDAW.data;
using ProiectDAW.Models;
using ProiectDAW.Interfaces;
namespace ProiectDAW.Repositories
{
    public class adreseAngajatiRepository : IadreseAngajatiRepository
    {
        private ProiectDAWcontext context;
        public adreseAngajatiRepository(ProiectDAWcontext context)
        {
            this.context = context;
        }

        public ICollection<adreseAngajati> GetDepartamente()
        {
            return context.adreseAngajatis.OrderBy(p => p.IdAdresa).ToList();
        }

        public void InsertAdresaAngajati(adreseAngajati adreseAngajati)
        {
            context.adreseAngajatis.Add(adreseAngajati);
            Save();
        }

        public void DeleteAdresaAngajati(int IdAdresa)
        {
            adreseAngajati adreseAngajati = context.adreseAngajatis.Find(IdAdresa);
            context.adreseAngajatis.Remove(adreseAngajati);
            Save();
        }

        public void UpdateAdresaAngajati(adreseAngajati adreseAngajati)
        {
            context.adreseAngajatis.Update(adreseAngajati);
            Save();
        }

        public adreseAngajati GetAdresaById(int IdAdresa)
        {
            return context.adreseAngajatis.Find(IdAdresa);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}