using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Interfaces;
using ProiectDAW.DTO;
using ProiectDAW.Models;

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
        [HttpPost]
        public IActionResult InsertProiect(proiecteDTO inserareProiect)
        {
            if (inserareProiect == null)
                return BadRequest(ModelState);
            var proiect = _mapper.Map<proiecte>(inserareProiect);
            if (!_proiecteRepository.InsertProiect(proiect))
            {
                ModelState.AddModelError("", "Eroare");
                return StatusCode(500, ModelState);
            }
            return Ok("Proiect adaugat cu succes");
        }
        [HttpDelete("{IdProiect}")]
        public IActionResult DeleteProiect(int IdProiect)
        {
            if (_proiecteRepository.GetProiectById(IdProiect) == null)
            {
                return NotFound();
            }
            var proiectSters = _proiecteRepository.GetProiectById(IdProiect);
            _proiecteRepository.DeleteProiect(proiectSters);
            return Ok("Proiect sters");
        }
    }
}
