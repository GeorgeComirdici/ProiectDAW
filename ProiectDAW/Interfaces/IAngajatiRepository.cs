using ProiectDAW.Models;
namespace ProiectDAW.Interfaces
{
    public interface IAngajatiRepository
    {
        ICollection<detaliiAngajati> GetAngajati();
        detaliiAngajati GetAngajatiById(int IdAngajat);
        //detaliiAngajati GetAngajatiByNume(string nume);
        bool InsertAngajati(detaliiAngajati detaliiAngajati);
        void UpdateAngajati(detaliiAngajati detaliiAngajati);
        bool DeleteAngajati(detaliiAngajati detaliiAngajati);
        bool Save();
    }
}
