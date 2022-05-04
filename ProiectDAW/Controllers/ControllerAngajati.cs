using ProiectDAW.Models;
using ProiectDAW.Repositories;
using ProiectDAW.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ProiectDAW.DTO;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerAngajati : ControllerBase
    {
        private readonly IAngajatiRepository _angajatiRepository;
        private readonly IMapper _mapper;
        public ControllerAngajati(IAngajatiRepository angajatiRepository, IMapper mapper)
        {
            _angajatiRepository = angajatiRepository;
            _mapper = mapper;
        }
        [HttpGet("getAngajati")]
        public IActionResult GetAngajati()
        {
            var angajatii = _mapper.Map<List<detaliiAngajatiDTO>>(_angajatiRepository.GetAngajati());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(angajatii);
        }

        [HttpGet("getAngajatiById/{IdAngajat}")]
        public IActionResult GetAngajatiById(int IdAngajat)
        {
            var angajati1 = _mapper.Map<detaliiAngajatiDTO>(_angajatiRepository.GetAngajatiById(IdAngajat));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(angajati1);
        }

        [HttpPost("inserareAngajat")]
        public IActionResult InsertAngajati(detaliiAngajatiDTO inserareAngajat)
        {
            if (inserareAngajat == null)
                return BadRequest(ModelState);
            var angajat = _mapper.Map<detaliiAngajati>(inserareAngajat);
            if (!_angajatiRepository.InsertAngajati(angajat))
            {
                ModelState.AddModelError("", "Eroare");
                return StatusCode(500, ModelState);
            }
            return Ok("Angajat adaugat cu succes");
        }

        [HttpDelete("stergereAngajat/{IdAngajat}")]
        public IActionResult DeleteAngajati(int IdAngajat)
        {
            if (_angajatiRepository.GetAngajatiById(IdAngajat) == null)
            {
                return NotFound();
            }
            var angajatSters = _angajatiRepository.GetAngajatiById(IdAngajat);
            _angajatiRepository.DeleteAngajati(angajatSters);
            return Ok("Angajat sters");
        }

        [HttpPut("modificareAngajat/{IdAngajat}")]
        public IActionResult UpdateAngajati(int IdAngajat, detaliiAngajatiDTO angajatUpdadat)
        {
            if (angajatUpdadat == null)
                return BadRequest(ModelState);
            var updateangajat = _mapper.Map<detaliiAngajati>(angajatUpdadat);
            _angajatiRepository.UpdateAngajati(updateangajat);
            return Ok("Angajat modificat");
        }
    }
}
