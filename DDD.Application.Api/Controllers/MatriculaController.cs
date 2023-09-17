﻿using DDD.Domain;
using DDD.Infra.SQLServer.Interfaces;
using DDD.Infra.SQLServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        readonly IMatriculaRepository _matriculaRepository;

        public MatriculaController(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Matricula> GetbyId(int id)
        {
            return Ok(_matriculaRepository.GetMatricula(id));
        }

        [HttpPost]
        public ActionResult<Matricula> CreateMatricula(Matricula matricula)
        {
            _matriculaRepository.fazerMatricula(matricula);
            return CreatedAtAction(nameof(GetbyId), new { id = matricula.Id }, matricula);
        }


    }
}