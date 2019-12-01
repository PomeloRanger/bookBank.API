using AutoMapper;
using bookBank.API.Domain.Models;
using bookBank.API.Extensions;
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
                .ForMember(br => br.Publishers, opts => opts
                    .MapFrom(b => b.BookPublishers
                    .Select(bp => bp.Publisher)))
                .ForMember(br => br.Categories, opts => opts
                    .MapFrom(b => b.BookCategories
                    .Select(bp => bp.Category)));
            CreateMap<Category, CategoryResource>().ForMember(src => src.Genre,
                                                              opts => opts.MapFrom(src => src.Genre.ToDescriptionString()));
        }
    }
}