

namespace Ordering.Domain.ValueObjects
{
    public record Address
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public string? EmailAdress { get; private set; } = default!;
        public string AddressLine { get; private set; } = default!;
        public string Country { get; private set; } = default!;
        public string State { get; private set; } = default!;
        public string ZipCode { get; private set; } = default!;

        protected Address() { }

        private Address(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipcode)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAdress = emailAddress;
            AddressLine = addressLine;
            Country = country;
            State = state;
            ZipCode = zipcode;
        }

        public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipcode)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress, nameof(emailAddress));
            ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);
            return new Address(firstName, lastName, emailAddress, addressLine, country, state, zipcode);
        }
    }


}
