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
            CreateMap<departamenteDTO, departamente>();
            CreateMap<detaliiAngajati, detaliiAngajatiDTO>();
            CreateMap<detaliiAngajatiDTO, detaliiAngajati>();
            CreateMap<proiecte, proiecteDTO>();
            CreateMap<proiecteDTO, proiecte>();
            CreateMap<departamente, departamenteDTO2>();
            CreateMap<departamenteDTO2, departamente>();
        }
    }
}