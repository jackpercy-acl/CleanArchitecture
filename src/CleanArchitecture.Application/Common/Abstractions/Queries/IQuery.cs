using ErrorOr;
using MediatR;

namespace CleanArchitecture.Application.Common.Abstractions.Queries;

public interface IQuery<TResponse> : IRequest<ErrorOr<TResponse>>;