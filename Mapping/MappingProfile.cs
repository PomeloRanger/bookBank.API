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
            CreateMap<Book, BookResource>()
                .ForMember(dto => dto.Publishers, opts => opts.MapFrom(x=> x.BookPublishers.Select(y => y.Publisher)));
            CreateMap<BookPublisher, PublisherResource>();
        }
    }
}