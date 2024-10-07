namespace Application.Models.NoSqlDocuments;

public class AddressDocument
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
}
