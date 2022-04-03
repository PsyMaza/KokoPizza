using AutoMapper;
using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Application.Features.Orders.Queries.DTOs;
using KokoPizza.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokoPizza.Core.Application.Features.Orders.Queries.GetOrders
{
    public sealed class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, GetOrdersQueryResponse>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetOrdersQueryResponse> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetOrdersByUserId(request.UserId);
            if (orders == null)
            {
                throw new ArgumentNullException($"Заказы для пользователя {request.UserId} не найдены.");
            }

            return new GetOrdersQueryResponse(_mapper.Map<IEnumerable<Order>,List<OrderDto>>(orders.ToList()));
        }
    }
}
