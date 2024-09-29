using AutoMapper;
using Mangas.Domain.Dtos;
using Mangas.Domain.Entities;

public class RequestUpdateMappingProfile : Profile
{
    public RequestUpdateMappingProfile()
    {
        CreateMap<MangaUpdateDTO, Manga>()
            .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(src => new DateTime(src.PublicationYear, 1, 1)))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}