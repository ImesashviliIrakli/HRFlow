using Application.Interfaces.Messaging;
using Application.Models.LeaveRequest;
using AutoMapper;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Queries.LeaveRequests.GetEmployeLeaveRequests;

public class GetEmployeLeaveRequestsQueryHandler : IQueryHandler<GetEmployeLeaveRequestsQuery, List<LeaveRequestDto>>
{
    private readonly ILeaveRepository _leaveRepository;
    private readonly IMapper _mapper;
    public GetEmployeLeaveRequestsQueryHandler(ILeaveRepository leaveRepository, IMapper mapper)
    {
        _leaveRepository = leaveRepository;
        _mapper = mapper;
    }
    public async Task<Result<List<LeaveRequestDto>>> Handle(GetEmployeLeaveRequestsQuery request, CancellationToken cancellationToken)
    {
        var leaveRequests = await _leaveRepository.GetEmployeeLeaveRequests(request.EmployeeId);

        if (leaveRequests is null || leaveRequests.Count == 0)
            Result.Success();

        return _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
    }
}
