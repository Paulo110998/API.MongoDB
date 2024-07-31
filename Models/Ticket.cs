using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_MongoDB.Models;

public class Ticket
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } 

    [BsonElement("Name")]
    public string TicketName { get; set; } = null!;

    public int Code { get; set; }

    // ID do Book associado
    [BsonRepresentation(BsonType.ObjectId)]
    public string BookId { get; set; } = null!;
}

