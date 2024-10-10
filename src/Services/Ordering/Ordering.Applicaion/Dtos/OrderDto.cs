using Ordering.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Applicaion.Dtos
{
    public record OrderDto
    (
        Guid Id,
        Guid CustomerId,
        string OrderName,
        AddressDto ShippingAddress,
        AddressDto BilldingAddress,
        PaymentDto payment,
        OrderStatus Status,
        List<OrderItemDto> OrderItem

    );
}
