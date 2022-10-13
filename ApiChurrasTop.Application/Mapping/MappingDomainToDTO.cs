using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiChurrasTop.Application.DTO;
using APIChurrasTop.Domain.Entities;
using AutoMapper;

namespace ApiChurrasTop.Application.Mapping
{
    public class MappingDomainToDTO : Profile
    {
        public MappingDomainToDTO()
        {
            CreateMap<Agenda, AgendaDTO>().ReverseMap();
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
            CreateMap<AgendaPessoa, AgendaPessoaDTO>().ReverseMap();
        }
    }
}