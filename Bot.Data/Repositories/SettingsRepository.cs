using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bot.Data.Abstractions;
using Bot.Data.Models;
using MongoDB.Driver;

namespace Bot.Data.Repositories
{
    public class SettingsRepository : IRepository<Settings>
    {
        private readonly IMongoCollection<Settings> _settings;

        public SettingsRepository(ISettingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _settings = database.GetCollection<Settings>(settings.SettingCollectionName);
        }
        
        public async Task<IList<Settings>> GetAll()
        {
            var settings = await _settings.FindAsync(m => true);
            return settings.ToList();
        }

        public async Task<Settings> GetById(string id)
        {
            var settings = await _settings.FindAsync(m => m.Id == id);
            return await settings.FirstOrDefaultAsync();
        }

        public async Task<IList<Settings>> GetFiltered(Expression<Func<Settings, bool>> filter)
        {
            var settings = await _settings.FindAsync(filter);
            return await settings.ToListAsync();
        }

        public async Task<Settings> Create(Settings model)
        {
            await _settings.InsertOneAsync(model);
            return model;
        }

        public async Task Update(string id, Settings model)
        {
            await _settings.ReplaceOneAsync(m => m.Id == id, model);
        }

        public async Task Delete(Settings model)
        {
            await _settings.DeleteOneAsync(m => m.Id == model.Id);
        }

        public async Task DeleteById(string id)
        {
            await _settings.DeleteOneAsync(m => m.Id == id);
        }
    }
}