﻿using AutoMapper;
using Consultorio.Models.Dtos;
using Consultorio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Helpers
{
    public class ConsultorioProfile : Profile
    {
        public ConsultorioProfile()
        {
            CreateMap<Paciente, PacienteDetalhesDto>().ReverseMap();
            CreateMap<ConsultaDto, Consulta>()
                .ForMember(dest => dest.Profissional, opt => opt.Ignore())
                .ForMember(dest => dest.Especialidade, opt => opt.Ignore());

            CreateMap<Consulta, ConsultaDto>()
                .ForMember(dest => dest.Especialidade, opt => opt.MapFrom(src => src.Especialidade.Nome))
                .ForMember(dest => dest.Profissional, opt => opt.MapFrom(src => src.Profissional.Nome));

            //CreateMap<ConsultaAdicionarDto, Consulta>();
            //CreateMap<ConsultaAtualizarDto, Consulta>()
            //    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PacienteAdicionarDto, Paciente>();
            CreateMap<PacienteAtualizarDto, Paciente>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Profissional, ProfissionalDetalhesDto>()
                .ForMember(dest => dest.TotalConsultas, opt => opt.MapFrom(src => src.Consultas.Count()))
                .ForMember(dest => dest.Especialidades, opt => opt.MapFrom(src =>
                src.Especialidades.Select(x => x.Nome).ToArray()));
            CreateMap<Profissional, ProfissionalDto>();

            CreateMap<ProfissionalAdicionarDto, Profissional>();
            CreateMap<ProfissionalAtualizarDto, Profissional>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Especialidade, EspecialidadeDetalhesDto>();

        }
    }
}
