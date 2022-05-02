using ProiectDAW.Models;

namespace ProiectDAW.Interfaces
{
    public interface IadreseAngajatiRepository
    {
        ICollection<adreseAngajati> GetDepartamente();
        adreseAngajati GetAdresaById(int IdAdresa);
        void InsertAdresaAngajati(adreseAngajati adreseAngajati);
        void DeleteAdresaAngajati(int IdAdresa);
        void UpdateAdresaAngajati(adreseAngajati adreseAngajati);
        void Save();

    }
}