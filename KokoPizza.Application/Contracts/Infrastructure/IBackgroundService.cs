namespace KokoPizza.Core.Application.Contracts.Infrastructure;

public interface IBackgroundService
{
    Task Run(CancellationToken cancellationToken);
}