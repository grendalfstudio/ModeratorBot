using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bot.Data.Abstractions;
using Bot.Data.Models;
using MongoDB.Driver;

namespace Bot.Data.Repositories
{
    public class WordRepository : IRepository<WordModel>
    {
        private readonly IMongoCollection<WordModel> _words;

        public WordRepository(ISettingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _words = database.GetCollection<WordModel>(settings.WordCollectionName);
        }
        
        public async Task<IList<WordModel>> GetAll()
        {
            var words = await _words.FindAsync(w => true);
            return words.ToList();
        }

        public async Task<WordModel> GetById(string id)
        {
            var words = await _words.FindAsync(w => w.Id == id);
            return await words.FirstOrDefaultAsync();
        }

        public async Task<IList<WordModel>> GetFiltered(Expression<Func<WordModel, bool>> filter)
        {
            var words = await _words.FindAsync(filter);
            return await words.ToListAsync();
        }

        public async Task<WordModel> Create(WordModel model)
        {
            await _words.InsertOneAsync(model);
            return model;
        }

        public async Task Update(string id, WordModel model)
        {
            await _words.ReplaceOneAsync(w => w.Id == id, model);
        }

        public async Task Delete(WordModel model)
        {
            await _words.DeleteOneAsync(w => w.Id == model.Id);
        }

        public async Task DeleteById(string id)
        {
            await _words.DeleteOneAsync(w => w.Id == id);
        }
    }
}