using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Interfaces;
using ProiectDAW.DTO;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerProiecte : ControllerBase
    {
        private readonly IproiecteRepository _proiecteRepository;
        private readonly IMapper _mapper;
        public ControllerProiecte(IproiecteRepository proiecteRepository, IMapper mapper)
        {
            _proiecteRepository = proiecteRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetProiect()
        {
            var proiecte = _mapper.Map<List<proiecteDTO>>(_proiecteRepository.GetProiect());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(proiecte);
        }
        [HttpGet("{IdProiect}")]
        public IActionResult GetProiectById(int IdProiect)
        {
            var proiecte1 = _mapper.Map<proiecteDTO>(_proiecteRepository.GetProiectById(IdProiect));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(proiecte1);
        }
    }
}
