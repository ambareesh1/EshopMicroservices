﻿using FluentValidation;


namespace Ordering.Applicaion.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand(OrderDto order)
        :ICommand<UpdateOrderResult>;
    public record UpdateOrderResult(bool IsSuccess);

    public class UpdateOrderCommandValidator: AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator() {
            RuleFor(x => x.order.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.order.OrderName).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.order.CustomerId).NotNull().WithMessage("CustomerId is required");

        }
    }
}
