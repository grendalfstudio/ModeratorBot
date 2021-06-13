using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bot.Data.Abstractions;
using Bot.Data.Models;
using MongoDB.Driver;

namespace Bot.Data.Repositories
{
    public class MessageRepository : IRepository<Message>
    {
        private readonly IMongoCollection<Message> _messages;

        public MessageRepository(IBotDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _messages = database.GetCollection<Message>(settings.MessageCollectionName);
        }
        
        public async Task<IList<Message>> GetAll()
        {
            var messages = await _messages.FindAsync(m => true);
            return messages.ToList();
        }

        public async Task<Message> GetById(long id)
        {
            var messages = await _messages.FindAsync(m => m.Id == id);
            return await messages.FirstOrDefaultAsync();
        }

        public async Task<IList<Message>> GetFiltered(Expression<Func<Message, bool>> filter)
        {
            var messages = await _messages.FindAsync(filter);
            return await messages.ToListAsync();
        }

        public async Task<Message> Create(Message model)
        {
            await _messages.InsertOneAsync(model);
            return model;
        }

        public async Task Update(long id, Message model)
        {
            await _messages.ReplaceOneAsync(m => m.Id == id, model);
        }

        public async Task Delete(Message model)
        {
            await _messages.DeleteOneAsync(m => m.Id == model.Id);
        }

        public async Task DeleteById(long id)
        {
            await _messages.DeleteOneAsync(m => m.Id == id);
        }
    }
}