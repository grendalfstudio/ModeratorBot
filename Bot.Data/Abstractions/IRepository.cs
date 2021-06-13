using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bot.Data.Abstractions
{
    public interface IRepository<TModel> where TModel: class
    {
        public Task<IList<TModel>> GetAll();

        public Task<TModel> GetById(long id);

        public Task<IList<TModel>> GetFiltered(Expression<Func<TModel, bool>> filter);

        public Task<TModel> Create(TModel model);

        public Task Update(long id, TModel model);

        public Task Delete(TModel model);

        public Task DeleteById(long id);
    }
}