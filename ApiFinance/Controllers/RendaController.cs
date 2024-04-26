using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFinance.DTOs;
using ApiFinance.Entities;
using ApiFinance.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiFinance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RendaController : ControllerBase
    {
        private readonly IRendaRepository _repository;
        private readonly IMapper _mapper;

        public RendaController(IRendaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RendaDTO>>> Get()
        {
            var rendas = _repository.GetAllAsync();

            if (rendas is null)
                return NotFound("Renda não encontrada");

            var rendaDTOs = _mapper.Map<IEnumerable<RendaDTO>>(rendas);
            return Ok(rendaDTOs);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RendaDTO rendaDto)
        {
            if (rendaDto == null)
                return BadRequest("Dados inválidos");

            var renda = _mapper.Map<Renda>(rendaDto);

            await _repository.AddAsync(renda);
            return new CreatedAtRouteResult("GetRenda", new { id = rendaDto.Id }, rendaDto);
        }


        [HttpGet("{id:int}", Name = "GetRenda")]
        public async Task<ActionResult<RendaDTO>> Get(int id)
        {
            var renda = await _repository.GetByIdAsync(id);

            if (renda is null)
                return NotFound("renda não encontrada");

            var despeDto = _mapper.Map<RendaDTO>(renda);

            return Ok(despeDto);
        }



    }
}