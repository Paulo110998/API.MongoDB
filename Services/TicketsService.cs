using API_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API_MongoDB.Services
{
    public class TicketsService
    {
        private readonly IMongoCollection<Ticket> _ticketsCollection;
        private readonly IMongoCollection<Book> _booksCollection;

        public TicketsService(IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(bookStoreDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(bookStoreDatabaseSettings.Value.DatabaseName);

            _ticketsCollection = mongoDatabase.GetCollection<Ticket>(bookStoreDatabaseSettings.Value.TicketsCollectionName);
            _booksCollection = mongoDatabase.GetCollection<Book>(bookStoreDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<Ticket>> GetAsync() =>
            await _ticketsCollection.Find(_ => true).ToListAsync();

        public async Task<Ticket?> GetAsyncId(string id) =>
            await _ticketsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Ticket newTicket)
        {
            await _ticketsCollection.InsertOneAsync(newTicket);

            var filter = Builders<Book>.Filter.Eq(b => b.Id, newTicket.BookId);
            var update = Builders<Book>.Update.AddToSet(b => b.TicketIds, newTicket.Id);
            await _booksCollection.UpdateOneAsync(filter, update);
        }

        public async Task UpdateAsync(string id, Ticket updateTicket) =>
            await _ticketsCollection.ReplaceOneAsync(x => x.Id == id, updateTicket);

        public async Task RemoveAsync(string id)
        {
            var ticket = await _ticketsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (ticket != null)
            {
                var filter = Builders<Book>.Filter.Eq(b => b.Id, ticket.BookId);
                var update = Builders<Book>.Update.Pull(b => b.TicketIds, ticket.Id);
                await _booksCollection.UpdateOneAsync(filter, update);

                await _ticketsCollection.DeleteOneAsync(x => x.Id == id);
            }
        }
    }
}
