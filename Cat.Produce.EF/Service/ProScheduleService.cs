using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.Service;
using Cat.Produce.Core.Repository;
using Cat.Produce.Core.DomainObjects;
using Jiuzh.CoreBase.Infrastructure;

namespace Cat.Produce.EF.Service
{
    public class ProScheduleService : IProScheduleService
    {
        private IProScheduleRepository _bar;
        private IDomainObjectFactory _factory;

        public ProScheduleService(IProScheduleRepository bar, IDomainObjectFactory factory)
        {
            _bar = bar;
            _factory = factory;
        }

        public void Add(int produceId, string remark, DateTime date, int userid)
        {
            IProduce_ProductRepository pprRep = IoC.Resolve<IProduce_ProductRepository>();
            IProduce_Product ppt = pprRep.GetById(produceId);
            IProSchedule deli = _factory.CreateProSchedule(ppt, date, remark, userid);
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                _bar.Add(deli);
                uow.Commit();
            }
        }
    }
}
