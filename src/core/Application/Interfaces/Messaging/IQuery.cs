using Domain.Shared;
using MediatR;

namespace Application.Interfaces.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> {}