using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.Repository;
using Cat.Produce.Core.DomainObjects;
using Cat.Produce.EF.DomainObjects;
using Cat.Produce.Core.Repository;
using Jiuzh .CoreBase ;

namespace Cat.Produce.EF.Repository
{
    public class DeliverysRepository : BaseRepository<IDeliverys, Deliverys>, IDeliverysRepository
    {
        public DeliverysRepository(IDatabase database) :
            base(database)
        {
        }
        public DeliverysRepository(IDatabaseFactory factory)
            : base(factory)
        {
        }

        public IDeliverys GetById(int id)
        {
            return Database.DeliverysDS.Where(s => s.Id == id).FirstOrDefault();
        }

        public ICollection<IDeliverys> GetsList(int userId, PageBreakParam pagebreak, SortParam sort)
        {
            var result=from p in Database .DeliverysDS.Where (s=>s.UserId ==userId ) select p  ;
            if (pagebreak != null)
                pagebreak.DataCount = result.Count();
            if (sort != null)
            {
                if (sort.SortRule == SortRules.ESC)
                    result = result.OrderBy(sort.SortCode);
                else
                    result = result.OrderByDescending(sort.SortCode);
            }
            if (pagebreak != null && sort == null)
                result = result.OrderBy(s => s.Id);
            if (pagebreak != null)
                return result.Skip(pagebreak.PageIndex * pagebreak.PageSize).Take(pagebreak.PageSize).AsEnumerable().Cast <IDeliverys >(). ToList();
            else
                return result.AsEnumerable().Cast<IDeliverys>().ToList();
        }
     
    }
}
