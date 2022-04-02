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
    public class ResumeRepository : Repository<Resume>, IResumeRepository
    {
        public ResumeRepository(NNDbContext dbContext) : base(dbContext)
        {
        }
    }
}
