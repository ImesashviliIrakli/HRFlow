namespace Domain.ValueObjects;

public class Address
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string ZipCode { get; }

    public Address(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    // Override equality checks since this is a value object
    public override bool Equals(object obj) =>
        obj is Address address &&
        Street == address.Street &&
        City == address.City &&
        State == address.State &&
        ZipCode == address.ZipCode;

    public override int GetHashCode() =>
        HashCode.Combine(Street, City, State, ZipCode);
}

