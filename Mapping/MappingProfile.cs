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
            CreateMap<PublisherResource, Publisher>();
            CreateMap<Publisher, PublisherResource>();
            CreateMap<Book, BookResource>()
                .ForMember(br => br.Publishers, opts => opts
                .MapFrom(b=> b.BookPublishers
                .Select(bp => bp.Publisher)));
            CreateMap<BookPublisher, PublisherResource>();
        }
    }
}