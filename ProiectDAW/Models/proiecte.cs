using System.ComponentModel.DataAnnotations;
namespace ProiectDAW.Models
{
    public class proiecte
    {
        [Key]
        public int IdProiect { get; set; }
        public string DetaliiProiect { get; set; }
        public virtual ICollection<proiecteAngajati> proiecteAngajati  { get; set; }
    }
}
