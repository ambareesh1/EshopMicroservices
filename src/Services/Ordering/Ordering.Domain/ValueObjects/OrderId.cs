

namespace Ordering.Domain.ValueObjects
{
    public record OrderId
    {
        public Guid Value { get;}

        private OrderId(Guid value) => Value = value;

        public static OrderId Of(Guid value)
        {

            ArgumentNullException.ThrowIfNull(value, "value");
            if (value == Guid.Empty)
            {
                throw new DomainException("OrderId can not be Empty");
            }

            return new OrderId(value);
        }
    }
}
