using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Net.Sockets;

namespace API_MongoDB.Models;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string BookName { get; set; } = null!;

    public decimal Price { get; set; }

    public string Category { get; set; } = null!;

    public string Author { get; set; } = null!;

    // Lista de IDs de Tickets associados
    public List<string> TicketIds { get; set; } = new List<string>();
}


/*
 Na classe acima, a propriedade Id é:

- Necessária para mapear o objeto CLR (Common Language Runtime) para a coleção do MongoDB.

- Anotada com [BsonId] para designar essa propriedade como a chave primária do documento.

- Anotada com [BsonRepresentation(BsonType.ObjectId)] para permitir 
a passagem do parâmetro como tipo string,em vez de uma estrutura ObjectId.
O Mongo processa a conversão de string para ObjectId.

- A propriedade BookName é anotada com o atributo [BsonElement]. 
O valor do atributo de Name representa o nome da propriedade da coleção do MongoDB.
 
 */