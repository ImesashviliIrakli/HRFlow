using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Application.Models.NoSqlDocuments;

public class EmployeeDocument
{
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    public string? UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Position { get; set; }
    [BsonElement("Address")]
    public AddressDocument? Address { get; set; }

    [BsonElement("LeaveRequests")]
    public List<LeaveRequestDocument>? LeaveRequests { get; set; }
}
