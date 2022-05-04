using ProiectDAW.Models;

namespace ProiectDAW.Interfaces
{
    public interface IproiecteRepository
    {
        ICollection<proiecte> GetProiect();
        proiecte GetProiectById(int IdProiect);
        bool InsertProiect(proiecte proiecte);
        bool DeleteProiect(proiecte proiecte);
        bool UpdateProiect(proiecte proiecte);
        bool Save();
    }
}