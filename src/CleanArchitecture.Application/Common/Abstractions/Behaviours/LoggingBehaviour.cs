using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Common.Abstractions.Behaviours;

internal sealed class LoggingBehaviour<TRequest, TResponse>(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
    where TResponse : IErrorOr
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting {@RequestName}", typeof(TRequest).Name);

        var result = await next();

        if (result.IsError)
        {
            logger.LogWarning(
                "{@RequestName} failed: {@ErrorType} - {@ErrorCode}",
                typeof(TRequest).Name,
                result.Errors?[0].Type,
                result.Errors?[0].Code);
        }

        logger.LogInformation("Finished {@RequestName}", typeof(TRequest).Name);

        return result;
    }
}