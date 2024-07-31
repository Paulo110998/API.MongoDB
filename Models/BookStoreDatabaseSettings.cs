namespace API_MongoDB.Models;

public class BookStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string BooksCollectionName { get; set; } = null!;

    public string TicketsCollectionName { get; set; } = null!;
}