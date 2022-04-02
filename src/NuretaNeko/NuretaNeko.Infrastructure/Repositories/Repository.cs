using Microsoft.EntityFrameworkCore;
using NuretaNeko.AppModel.Repositories;
using NuretaNeko.Domain.Entities;
using NuretaNeko.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly NNDbContext _dbContext;

        public Repository(NNDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Add(TEntity entity, CancellationToken cancellationToken)
        {
            entity.Guid = Guid.NewGuid();
            await _dbContext.AddAsync(entity, cancellationToken);
            await Save(cancellationToken);
        }


        public async Task<TEntity> FindById(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Guid == id, cancellationToken: cancellationToken);
        }


        public IQueryable<TEntity> FindAll()
        {
            return _dbContext.Set<TEntity>();
        }


        public async Task Save(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }


        public async Task Update(TEntity entity, CancellationToken cancellationToken)
        {
            _dbContext.Update(entity);
            await Save(cancellationToken);
        }
    }
}
