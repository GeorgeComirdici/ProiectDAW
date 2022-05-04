using ProiectDAW.Models;

namespace ProiectDAW.Interfaces
{
    public interface IproiecteRepository
    {
        ICollection<proiecte> GetProiect();
        proiecte GetProiectById(int IdProiect);
        bool InsertProiect(proiecte proiecte);
        void DeleteProiect(int IdProiect);
        void UpdateProiect(proiecte proiecte);
        bool Save();
    }
}