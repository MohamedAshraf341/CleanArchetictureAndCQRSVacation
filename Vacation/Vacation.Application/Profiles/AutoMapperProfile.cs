using AutoMapper;
using Vacation.Application.Features.Vacation.Commands.CreateVacation;
using Vacation.Application.Features.Vacation.Commands.UpdateVacation;
using Vacation.Application.Features.Vacation.Queries.GetVacationDetail;
using Vacation.Application.Features.Vacation.Queries.GetVacationList;
using Vacation.Domain.Entities;

namespace Vacation.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<VacationRequest, GetVacationDetailViewModel>().ReverseMap();
            CreateMap<VacationRequest, GetVacationListViewModel>().ReverseMap();
            CreateMap<VacationRequest, CreateVacationCommand>().ReverseMap();
            CreateMap<VacationRequest, UpdateVacationCommand>().ReverseMap();

        }
    }
}
