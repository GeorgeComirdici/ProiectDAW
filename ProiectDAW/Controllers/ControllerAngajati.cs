﻿using ProiectDAW.Models;
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
        [HttpGet]
        public IActionResult GetAngajati()
        {
            var angajatii = _mapper.Map<List<detaliiAngajatiDTO>>(_angajatiRepository.GetAngajati());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(angajatii);
        }

        [HttpGet("{IdAngajat}")]
        public IActionResult GetAngajatiById(int IdAngajat)
        {
            var angajati1 = _mapper.Map<detaliiAngajatiDTO>(_angajatiRepository.GetAngajatiById(IdAngajat));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(angajati1);
        }

        [HttpPost("create")]
        public IActionResult InsertAngajat(detaliiAngajati detaliiAngajati)
        {
            var AngajatCreat = new detaliiAngajati
            {
                Nume = detaliiAngajati.Nume,
                Salariu = detaliiAngajati.Salariu
            };
            _angajatiRepository.InsertAngajati(AngajatCreat);
            return Ok("succes - angajat adaugat");
        }
    }
}
