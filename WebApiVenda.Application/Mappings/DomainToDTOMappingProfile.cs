﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Application.DTOs;
using WebApiVenda.Domain.Entities;

namespace WebApiVenda.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Venda, VendaDTO>().ReverseMap();
            CreateMap<VendaItem, VendaItemDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
