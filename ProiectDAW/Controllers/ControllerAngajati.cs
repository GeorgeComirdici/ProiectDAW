using ProiectDAW.Models;
using ProiectDAW.Repositories;
using ProiectDAW.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ProiectDAW.DTO;
using BCrypt.Net;
using ProiectDAW.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerAngajati : ControllerBase
    {
        private readonly IAngajatiRepository _angajatiRepository;
        private readonly IMapper _mapper;
        private readonly Jwt _jwt;
        public ControllerAngajati(IAngajatiRepository angajatiRepository, IMapper mapper, Jwt jwt)
        {
            _angajatiRepository = angajatiRepository;
            _mapper = mapper;
            _jwt = jwt;
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
            var angajat = new detaliiAngajati
            {
                IdAngajat = inserareAngajat.IdAngajat,
                Nume = inserareAngajat.Nume,
                Email = inserareAngajat.Email,
                Salariu = inserareAngajat.Salariu,
                ParolaHash = BCrypt.Net.BCrypt.HashPassword(inserareAngajat.Parola),
                IdDepartament = inserareAngajat.IdDepartament
            };
            _angajatiRepository.InsertAngajati(angajat);
            return Ok("Angajat adaugat cu succes");
        }

        [HttpPost("login")]
        public IActionResult LoginAngajat(detaliiAngajatLoginDTO detaliiAngajatLoginDTO)
        {
            var angajatLogin = _angajatiRepository.GetAngajatByEmail(detaliiAngajatLoginDTO.Email);
            if(!BCrypt.Net.BCrypt.Verify(detaliiAngajatLoginDTO.Parola, angajatLogin.ParolaHash))
            {
                return BadRequest(new { message = "Parola gresita" });
            }
            var jwt1 = _jwt.CreateToken(angajatLogin.IdAngajat);
            //return Ok("Ok a mers logarea");
            return Ok(new
            {
                jwt = jwt1
            });
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
