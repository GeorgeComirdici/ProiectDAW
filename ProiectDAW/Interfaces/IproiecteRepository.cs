using ProiectDAW.Models;

namespace ProiectDAW.Interfaces
{
    public interface IproiecteRepository
    {
        ICollection<proiecte> GetProiect();
        proiecte GetProiectById(int IdProiect);
        void InsertProiect(proiecte proiecte);
        void DeleteProiect(int IdProiect);
        void UpdateProiect(proiecte proiecte);
        void Save();
    }
}