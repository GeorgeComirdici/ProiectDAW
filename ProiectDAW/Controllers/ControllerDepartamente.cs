using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Interfaces;
using ProiectDAW.Models;
using ProiectDAW.DTO;

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
        [HttpGet]
        public IActionResult GetDepartament()
        {
            var departamentee = _mapper.Map<List<departamenteDTO>>(_departamenteRepository.GetDepartament());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(departamentee);
        }
        [HttpGet("{IdDepartament}")]
        public IActionResult GetDepartamentById(int IdDepartament)
        {
            var departamente1 = _mapper.Map<departamenteDTO>(_departamenteRepository.GetDepartamentById(IdDepartament));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(departamente1);
        }

    }
}