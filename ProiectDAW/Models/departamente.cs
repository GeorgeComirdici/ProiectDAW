using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace ProiectDAW.Models
{
    public class departamente
    {
        [Key]
        public int IdDepartament { get; set; }
        public string NumeDepartament { get; set; }
        public virtual ICollection<detaliiAngajati> Angajati { get; set; }
    }
}
