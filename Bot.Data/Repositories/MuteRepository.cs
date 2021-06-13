using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bot.Data.Abstractions;
using Bot.Data.Models;
using MongoDB.Driver;

namespace Bot.Data.Repositories
{
    public class MuteRepository : IRepository<Mute>
    {
        private readonly IMongoCollection<Mute> _mutes;

        public MuteRepository(IBotDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _mutes = database.GetCollection<Mute>(settings.MuteCollectionName);
        }
        
        public async Task<IList<Mute>> GetAll()
        {
            var mutes = await _mutes.FindAsync(m => true);
            return mutes.ToList();
        }

        public async Task<Mute> GetById(string id)
        {
            var mutes = await _mutes.FindAsync(m => m.Id == id);
            return await mutes.FirstOrDefaultAsync();
        }

        public async Task<IList<Mute>> GetFiltered(Expression<Func<Mute, bool>> filter)
        {
            var mutes = await _mutes.FindAsync(filter);
            return await mutes.ToListAsync();
        }

        public async Task<Mute> Create(Mute model)
        {
            await _mutes.InsertOneAsync(model);
            return model;
        }

        public async Task Update(string id, Mute model)
        {
            await _mutes.ReplaceOneAsync(m => m.Id == id, model);
        }

        public async Task Delete(Mute model)
        {
            await _mutes.DeleteOneAsync(m => m.Id == model.Id);
        }

        public async Task DeleteById(string id)
        {
            await _mutes.DeleteOneAsync(m => m.Id == id);
        }
    }
}