using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFinance.DTOs;
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


        




    }
}