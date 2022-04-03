using System;
using System.Collections.Generic;
using System.Text;

namespace KokoPizza.Core.Domain.Enums
{
    // NOTE: Перечень статусов упрощенный
    public enum OrderStatus : long
    {
        PendingPayment = 1L,
        InProcess,
        Delivering,
        Completed,
        Declined
    }
}
