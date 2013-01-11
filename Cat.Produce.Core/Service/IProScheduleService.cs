using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;

namespace Cat.Produce.Core.Service
{
    public interface IProScheduleService
    {
        void Add(int produceId, string remark, DateTime date, int userid);
    }
}
