using AutoMapper;
using ProiectDAW.DTO;
using ProiectDAW.Models;

namespace ProiectDAW.Helpers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<departamente, departamenteDTO>();
            CreateMap<detaliiAngajati, detaliiAngajatiDTO>();
            CreateMap<proiecte, proiecteDTO>();
        }
    }
}