

namespace Ordering.Domain.ValueObjects
{
    public record Address
    {
        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;
        public string? EmailAdress { get; } = default!;

        public string AddressLine { get; } = default!;

        public string Country { get; } = default!;

        public string State { get; } = default!;    

        public string ZipCode { get; } = default!;

        protected Address()
        {
            
        }

        private Address(string firstName, string lastName, string emailAddress,string addressLine ,string country, string state, string zipcode) 
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAdress = emailAddress;
            Country = country;
            State = state;
            ZipCode = zipcode;
            AddressLine = addressLine;

        }

        public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipcode)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress, nameof(emailAddress));
            ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);
            return new Address(firstName, lastName, emailAddress, addressLine, country, state, zipcode);
        }
    }
}
