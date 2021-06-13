using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bot.Data.Abstractions;
using Bot.Data.Models;
using MongoDB.Driver;

namespace Bot.Data.Repositories
{
    public class LinkRepository : IRepository<Link>
    {
        private readonly IMongoCollection<Link> _links;

        public LinkRepository(ISettingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _links = database.GetCollection<Link>(settings.LinkCollectionName);
        }
        
        public async Task<IList<Link>> GetAll()
        {
            var links = await _links.FindAsync(m => true);
            return links.ToList();
        }

        public async Task<Link> GetById(string id)
        {
            var links = await _links.FindAsync(m => m.Id == id);
            return await links.FirstOrDefaultAsync();
        }

        public async Task<IList<Link>> GetFiltered(Expression<Func<Link, bool>> filter)
        {
            var links = await _links.FindAsync(filter);
            return await links.ToListAsync();
        }

        public async Task<Link> Create(Link model)
        {
            await _links.InsertOneAsync(model);
            return model;
        }

        public async Task Update(string id, Link model)
        {
            await _links.ReplaceOneAsync(m => m.Id == id, model);
        }

        public async Task Delete(Link model)
        {
            await _links.DeleteOneAsync(m => m.Id == model.Id);
        }

        public async Task DeleteById(string id)
        {
            await _links.DeleteOneAsync(m => m.Id == id);
        }
    }
}