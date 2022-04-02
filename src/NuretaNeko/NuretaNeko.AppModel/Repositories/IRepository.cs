using NuretaNeko.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.AppModel.Repositories
{
    public interface IRepository<TEntity>
         where TEntity : BaseEntity
    {
        IQueryable<TEntity> FindAll();

        Task<TEntity> FindById(Guid id, CancellationToken cancellationToken);

        Task Save(CancellationToken cancellationToken);

        Task Add(TEntity entity, CancellationToken cancellationToken);

        Task Update(TEntity entity, CancellationToken cancellationToken);

    }
}
