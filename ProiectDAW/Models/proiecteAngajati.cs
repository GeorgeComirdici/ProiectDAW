namespace ProiectDAW.Models
{
    public class proiecteAngajati
    {
        public int ID { get; set; }
        public int IdProiect { get; set; }
        public proiecte proiecte { get; set; }
        public int IdAngajat { get; set; }
        public detaliiAngajati detaliiAngajati { get; set; }

    }
}
