using AutoMapper;
using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Application.Features.Orders.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokoPizza.Core.Application.Features.Orders.Queries.GetOrderDetail
{
    public sealed class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, GetOrderDetailQueryResponse>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetOrderDetailQueryResponse> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.OrderId);
            if (order is null)
            {
                throw new ArgumentNullException($"Заказ с номером {request.OrderId} не найден.");
            }
            return new GetOrderDetailQueryResponse(_mapper.Map<OrderDto>(order));
        }
    }
}
