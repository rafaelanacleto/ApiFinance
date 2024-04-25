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
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepository categoryRepository,
            IMapper mapper)
        {
            _categoriaRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            if (categorias is null)
            {
                return NotFound("Categorias não existem");
            }
            var categoriasDto = _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
            return Ok(categoriasDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null)
                return BadRequest("Dados inválidos");

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            await _categoriaRepository.AddAsync(categoria);
            return new CreatedAtRouteResult("GetCategoria", new { id = categoriaDto.Id }, categoriaDto);
        }

        [HttpGet("{id:int}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria is null)
            {
                return NotFound("Categoria não encontrada");
            }

            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
            return Ok(categoriaDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (id != categoriaDto.Id)
                return BadRequest();

            if (categoriaDto == null)
                return BadRequest();

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            await _categoriaRepository.UpdateAsync(categoria);
            return Ok(categoriaDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }

            await _categoriaRepository.RemoveAsync(id);
            return Ok(categoria);
        }

    }
}