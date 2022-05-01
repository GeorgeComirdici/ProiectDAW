using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace ProiectDAW.Models
{
    public class detaliiAngajati
    {
        [Key]
        public int IdAngajat { get; set; }
        public string Nume { get; set; }
        public int Salariu { get; set; }
        public int foreignKeyDepartament { get; set; }
        public virtual departamente Departamente { get; set; }
        public virtual adreseAngajati Adresa { get; set; }
        public virtual ICollection<proiecteAngajati> proiecteAngajati { get; set; }

    }
}
