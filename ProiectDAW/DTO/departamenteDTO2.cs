namespace ProiectDAW.DTO
{
    public class departamenteDTO2
    {
        public int IdDepartament { get; set; }
        public string NumeDepartament { get; set; }
        public virtual ICollection<detaliiAngajatiDTO> Angajati { get; set; }
    }
}
