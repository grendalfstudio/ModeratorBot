using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bot.Data.Abstractions;
using Bot.Data.Models;
using MongoDB.Driver;

namespace Bot.Data.Repositories
{
    public class ReportRepository : IRepository<Report>
    {
        private readonly IMongoCollection<Report> _reports;

        public ReportRepository(IBotDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _reports = database.GetCollection<Report>(settings.ReportCollectionName);
        }
        
        public async Task<IList<Report>> GetAll()
        {
            var reports = await _reports.FindAsync(m => true);
            return reports.ToList();
        }

        public async Task<Report> GetById(int id)
        {
            var reports = await _reports.FindAsync(m => m.Id == id);
            return await reports.FirstOrDefaultAsync();
        }

        public async Task<IList<Report>> GetFiltered(Expression<Func<Report, bool>> filter)
        {
            var reports = await _reports.FindAsync(filter);
            return await reports.ToListAsync();
        }

        public async Task<Report> Create(Report model)
        {
            await _reports.InsertOneAsync(model);
            return model;
        }

        public async Task Update(int id, Report model)
        {
            await _reports.ReplaceOneAsync(m => m.Id == id, model);
        }

        public async Task Delete(Report model)
        {
            await _reports.DeleteOneAsync(m => m.Id == model.Id);
        }

        public async Task DeleteById(int id)
        {
            await _reports.DeleteOneAsync(m => m.Id == id);
        }
    }
}