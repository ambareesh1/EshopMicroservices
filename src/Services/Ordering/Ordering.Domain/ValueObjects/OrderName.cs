

namespace Ordering.Domain.ValueObjects
{
    public record OrderName
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        private const int DefaultLength = 5;
        public string Value { get; }

        // Parameterless constructor for EF Core
        private OrderName() { }
        private OrderName(string value) => Value = value;

        public static OrderName Of(string value)
        {
            ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));
            ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);
            
            return new OrderName(value);
        }
    }
}
