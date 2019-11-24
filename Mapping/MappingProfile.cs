using AutoMapper;
using bookBank.API.Domain.Models;
using bookBank.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Publisher, PublisherResource>();
            CreateMap<Author, AuthorResource>();
        }
    }
}
