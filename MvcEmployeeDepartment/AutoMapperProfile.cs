using AutoMapper;
using MvcEmployeeDepartment.Data.Models;
using MvcEmployeeDepartment.ViewModels;

namespace MvcEmployeeDepartment;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Department, DepartmentViewModel>().ReverseMap();

        CreateMap<Department, DropDownViewModel>()
            .ForMember(dvw => dvw.Text, opt => opt.MapFrom(d => d.Name));

        CreateMap<Employee, EmployeeViewModel>()
            .ForMember(evw => evw.DepartmentName, opt => opt.MapFrom(em => em.DepartmentRef.Name))
            .ReverseMap()
            .ForPath(em => em.DepartmentRef.Name, opt => opt.Ignore());
    }
}