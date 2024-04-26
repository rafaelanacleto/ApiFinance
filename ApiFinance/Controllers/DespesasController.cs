using ApiFinance.DTOs;
using ApiFinance.Entities;
using ApiFinance.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiFinance.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DespesasController : ControllerBase
{
    private readonly IDespesaRepository _repository;
    private readonly IMapper _mapper;

    public DespesasController(IDespesaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DespesasDTO>>> Get()
    {
        var despesas = _repository.GetAllAsync();

        if (despesas is null)
            return NotFound("Despesa não encontrada");

        var despesasDto = _mapper.Map<IEnumerable<DespesasDTO>>(despesas);
        return Ok(despesasDto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] DespesasDTO despesasDto)
    {
        if (despesasDto == null)
            return BadRequest("Dados inválidos");

        var despesa = _mapper.Map<Despesas>(despesasDto);

        await _repository.AddAsync(despesa);
        return new CreatedAtRouteResult("GetDespesa", new { id = despesasDto.Id }, despesasDto);
    }

    [HttpGet("{id:int}", Name = "GetDespesa")]
    public async Task<ActionResult<DespesasDTO>> Get(int id)
    {
        var despesa = await _repository.GetByIdAsync(id);

        if (despesa is null)
            return NotFound("Despesa não encontrada");

        var despeDto = _mapper.Map<Despesas>(despesa);

        return Ok(despeDto);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] DespesasDTO despesaDto)
    {
        if (id != despesaDto.Id)
            return BadRequest();

        if (despesaDto == null)
            return BadRequest();

        var despesa = _mapper.Map<Despesas>(despesaDto);

        await _repository.UpdateAsync(despesa);
        return Ok(despesa);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var despesa = await _repository.GetByIdAsync(id);
        if (despesa == null)
        {
            return NotFound("Categoria não encontrada");
        }

        await _repository.RemoveAsync(id);
        return Ok(despesa);
    }
}