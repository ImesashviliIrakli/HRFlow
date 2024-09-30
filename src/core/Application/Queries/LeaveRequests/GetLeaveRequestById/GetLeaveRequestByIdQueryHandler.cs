using Application.Interfaces.Messaging;
using Application.Models.LeaveRequest;
using AutoMapper;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Queries.LeaveRequests.GetLeaveRequestById;

public class GetLeaveRequestByIdQueryHandler : IQueryHandler<GetLeaveRequestByIdQuery, LeaveRequestDto>
{
    private readonly ILeaveRepository _leaveRepository;
    private readonly IMapper _mapper;
    public GetLeaveRequestByIdQueryHandler(ILeaveRepository leaveRepository, IMapper mapper)
    {
        _leaveRepository = leaveRepository;
        _mapper = mapper;
    }
    public async Task<Result<LeaveRequestDto>> Handle(GetLeaveRequestByIdQuery request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRepository.GetLeaveRequestById(request.LeaveRequestId);

        if (leaveRequest is null)
            Result.Failure(DomainErrors.LeaveRequest.NotFound(request.LeaveRequestId));

        return _mapper.Map<LeaveRequestDto>(leaveRequest);
    }
}
