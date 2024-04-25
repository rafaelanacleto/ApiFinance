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
    
}