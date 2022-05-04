using ProiectDAW.Models;
namespace ProiectDAW.Interfaces
{
    public interface IdepartamenteRepository
    {
        ICollection<departamente> GetDepartament();
        departamente GetDepartamentById(int IdDepartament);
        //departamente GetDepartamentByNume(string NumeDepartament);
        bool InsertDepartament(departamente departamente);
        void DeleteDepartament (int IdDepartament);
        void UpdateDepartament(departamente departamente);
        bool Save(); 

    }
}
