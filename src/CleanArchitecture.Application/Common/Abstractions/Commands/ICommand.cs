using ErrorOr;
using MediatR;

namespace CleanArchitecture.Application.Common.Abstractions.Commands;

public interface ICommand<TResponse> : IRequest<ErrorOr<TResponse>>;