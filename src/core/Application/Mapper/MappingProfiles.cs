using Application.Models.Employee;
using Application.Models.LeaveRequest;
using Application.Models.NoSqlDocuments;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Mapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Employee
        CreateMap<Employee, EmployeeDetailsDto>().ReverseMap();
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Employee, EmployeeDocument>().ReverseMap();
        CreateMap<EmployeeDocument, EmployeeDetailsDto>().ReverseMap();
        CreateMap<EmployeeDocument, EmployeeDto>().ReverseMap();

        // Leave
        CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestDocument>().ReverseMap();

        // Address
        CreateMap<Address, AddressDocument>().ReverseMap();
    }
}
