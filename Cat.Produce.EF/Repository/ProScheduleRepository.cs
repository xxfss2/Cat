using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.Repository;
using Cat.Produce.Core.DomainObjects;
using Cat.Produce.EF.DomainObjects;
using Cat.Produce.Core.Repository;

namespace Cat.Produce.EF.Repository
{
    public class ProScheduleRepository : BaseRepository<IProSchedule, ProSchedule>, IProScheduleRepository
    {
        public ProScheduleRepository(IDatabase database) :
            base(database)
        {
        }
        public ProScheduleRepository(IDatabaseFactory factory)
            : base(factory)
        {
        }
    }
}
