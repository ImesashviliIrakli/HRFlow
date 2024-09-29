using Application.Models.Employee;
using Application.Models.LeaveRequest;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Employee
        CreateMap<Employee, EmployeeDetailsDto>().ReverseMap();
        CreateMap<Employee, EmployeeDto>().ReverseMap();

        // Leave
        CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
    }
}
