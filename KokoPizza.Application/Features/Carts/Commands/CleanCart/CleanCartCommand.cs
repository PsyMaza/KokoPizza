using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokoPizza.Core.Application.Features.Carts.Commands.CleanCart
{
    internal sealed class CleanCartCommand : IRequest
    {
        public long UserId { get; }

        public CleanCartCommand(long userId)
        {
            UserId = userId;
        }
    }
}
