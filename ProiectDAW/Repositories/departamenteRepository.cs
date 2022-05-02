using ProiectDAW.Models;
using ProiectDAW.Interfaces;
using ProiectDAW.data;
namespace ProiectDAW.Repositories
{
    public class departamenteRepository : IdepartamenteRepository
    {
        private ProiectDAWcontext context;
        public departamenteRepository(ProiectDAWcontext context)
        {
            this.context = context;
        }

        public ICollection<departamente> GetDepartament()
        {
            return context.departamentes.OrderBy(p => p.IdDepartament).ToList();
        }

        public void InsertDepartament(departamente departamente)
        {
            context.departamentes.Add(departamente);
            Save();
        }

        public void DeleteDepartament(int IdDepartament)
        {
            departamente departamente = context.departamentes.Find(IdDepartament);
            context.departamentes.Remove(departamente);
            Save();
        }

        public void UpdateDepartament(departamente departamente)
        {
            context.departamentes.Update(departamente);
            Save();
        }

        public departamente GetDepartamentById(int IdDepartament)
        {
            return context.departamentes.Find(IdDepartament);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
