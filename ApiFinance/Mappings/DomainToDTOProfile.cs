using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFinance.DTOs;
using ApiFinance.Entities;
using AutoMapper;

namespace ApiFinance.Mappings
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Renda, RendaDTO>().ReverseMap();
            CreateMap<Despesas, DespesasDTO>().ReverseMap();

            // cria um mapeamento entre a classe Manga e a classe MangaCategoriaDTO.
            // O mapeamento especifica que a propriedade NomeCategoria do DTO será
            // mapeada a partir da propriedade Nome da propriedade Categoria do objeto Manga.
            CreateMap<Despesas, DespesasDTO>()
                .ForMember(dto => dto.Nome, opt => opt.MapFrom(src => src.Categoria.Nome));

        }
    }
}