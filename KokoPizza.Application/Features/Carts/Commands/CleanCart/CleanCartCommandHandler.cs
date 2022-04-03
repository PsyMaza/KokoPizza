using KokoPizza.Core.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokoPizza.Core.Application.Features.Carts.Commands.CleanCart
{
    internal sealed class CleanCartCommandHandler : AsyncRequestHandler<CleanCartCommand>
    {
        private readonly ICartRepository _cartRepository;

        public CleanCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException();
        }

        protected override async Task Handle(CleanCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartByUserId(request.UserId);

            if (cart is null)
            {
                throw new ArgumentNullException(nameof(cart));
            }

            await _cartRepository.DeleteAsync(cart);
        }
    }
}
