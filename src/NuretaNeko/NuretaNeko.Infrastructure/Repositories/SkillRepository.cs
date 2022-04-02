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
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(NNDbContext dbContext) : base(dbContext)
        {
        }
    }
}
