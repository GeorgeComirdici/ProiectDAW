using ProiectDAW.Models;
namespace ProiectDAW.Interfaces
{
    public interface IdepartamenteRepository
    {
        ICollection<departamente> GetDepartament();
        departamente GetDepartamentById(int IdDepartament);
        //departamente GetDepartamentByNume(string NumeDepartament);
        bool InsertDepartament(departamente departamente);
        bool DeleteDepartament (departamente departamente);
        void UpdateDepartament(departamente departamente);
        bool Save(); 

    }
}
