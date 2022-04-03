using FluentValidation;
using MediatR;

namespace KokoPizza.Core.Application.Pipelines;

public class ValidationPipe<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipe(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = _validators
            .Select(e => e.Validate(context))
            .SelectMany(e => e.Errors)
            .Where(e => e is not null)
            .ToList();

        if (failures.Any())
            throw new ValidationException(failures);

        return next();
    }
}