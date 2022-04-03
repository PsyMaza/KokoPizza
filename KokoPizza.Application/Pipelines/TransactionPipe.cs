using KokoPizza.Core.Application.Contracts.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokoPizza.Core.Application.Pipelines
{
    public sealed class TransactionPipe<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ITransactionFunctionality _transactionFunctionality;

        public TransactionPipe(ITransactionFunctionality transactionFunctionality)
        {
            _transactionFunctionality = transactionFunctionality;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = default(TResponse);

            try
            {
                if (_transactionFunctionality.HasActiveTransaction)
                {
                    return await next();
                }

                var strategy = _transactionFunctionality.Database.CreateExecutionStrategy();

                await strategy.ExecuteAsync(async () =>
                {
                    Guid transactionId;

                    using (var transaction = await _transactionFunctionality.BeginTransactionAsync())
                    {
                        response = await next();

                        await _transactionFunctionality.CommitTransactionAsync(transaction);

                        transactionId = transaction.TransactionId;

                        // Тут мы должны паблишить интеграционные эвенты, которые еще не были отправлены.
                        // Пока это не будет реализовано, в пайплайне мало смысла
                    };
                });

                return response;
            }
            catch (Exception ex)
            {
                // log

                throw;
            }
        }
    }
}
