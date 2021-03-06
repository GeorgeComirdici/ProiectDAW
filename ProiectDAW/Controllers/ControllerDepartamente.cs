using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Interfaces;
using ProiectDAW.Models;
using ProiectDAW.DTO;
using Microsoft.AspNetCore.Authorization;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerDepartamente : ControllerBase
    {
        private readonly IdepartamenteRepository _departamenteRepository;
        private readonly IMapper _mapper;
        public ControllerDepartamente(IdepartamenteRepository departamenteRepository, IMapper mapper)
        {
            _departamenteRepository = departamenteRepository;
            _mapper = mapper;
        }

        [HttpGet("getDepartamente")]
        public IActionResult GetDepartament()
        {
            var departamentee = _mapper.Map<List<departamenteDTO2>>(_departamenteRepository.GetDepartament());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(departamentee);
        }

        [HttpGet("getDepartamentById/{IdDepartament}")]
        public IActionResult GetDepartamentById(int IdDepartament)
        {
            var departamente1 = _mapper.Map<departamenteDTO>(_departamenteRepository.GetDepartamentById(IdDepartament));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(departamente1);
        }

        [HttpPost("adaugareDepartament")]
        public IActionResult InsertDepartament(departamenteDTO inserareDepartament)
        {
            if (inserareDepartament == null)
                return BadRequest(ModelState);
            var departament = _mapper.Map<departamente>(inserareDepartament);
            if(!_departamenteRepository.InsertDepartament(departament))
            {
                ModelState.AddModelError("", "Eroare");
            }
            return Ok("Departament adaugat cu succes");
        }

        [HttpDelete("stergereDepartament/{IdDepartament}")]
        public IActionResult DeleteDepartament(int IdDepartament)
        {
            if(_departamenteRepository.GetDepartamentById(IdDepartament) == null)
            {
                return NotFound();
            }
            var departamentSters = _departamenteRepository.GetDepartamentById(IdDepartament);
            _departamenteRepository.DeleteDepartament(departamentSters);
            return Ok("Departament sters");
        }
        [HttpPut("modificareDepartament/{IdDepartament}")]
        public IActionResult UpdateDepartament(int IdDepartament, departamenteDTO departamentUpdadat)
        {
            if(departamentUpdadat == null)
                return BadRequest(ModelState);
            var updatedepartament = _mapper.Map<departamente>(departamentUpdadat);
            _departamenteRepository.UpdateDepartament(updatedepartament);
            return Ok("Departament modificat");
        }
    }
}