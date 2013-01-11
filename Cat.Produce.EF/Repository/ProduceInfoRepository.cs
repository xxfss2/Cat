using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.Repository;
using Cat.Produce.Core.DomainObjects;
using Cat.Produce.EF.DomainObjects;
using Cat.Produce.Core.Repository;
using Jiuzh.CoreBase;

namespace Cat.Produce.EF.Repository
{
    public class ProduceInfoRepository : BaseRepository<IProduce, Cat.Produce.EF.DomainObjects.Produce>, IProduceInfoRepository
    {
        public ProduceInfoRepository(IDatabase database) :
            base(database)
        {
        }
        public ProduceInfoRepository(IDatabaseFactory factory)
            : base(factory)
        {
        }

        public IProduce GetById(int id)
        {
            return Database.ProduceInfoDS.Where(s => s.Id == id).FirstOrDefault();
        }
        public IProduce GetByNumber(string number)
        {
            return Database.ProduceInfoDS.Where(s => s.Number == number).FirstOrDefault();
        }
        public ICollection<IProduce> GetAll()
        {
            return Database.ProduceInfoDS.AsEnumerable().Cast<IProduce>().ToList();
        }

        public ICollection<IProduce> GetAllHistroy(int userId)
        {
            return Database.ProduceInfoDS.Where (s=>s.UserId ==userId && s.IsEnd==true) .AsEnumerable().Cast<IProduce>().ToList();
        }

        public ICollection<IProduce> GetAllCurr(int userId, PageBreakParam param)
        {
            var result = Database.ProduceInfoDS.Where(s => s.IsEnd == false && s.UserId == userId );
            if (param != null)
            {
                param .DataCount = result.Count();
                return result.OrderBy(s => s.Id).Skip(param .PageSize * param .PageIndex ).Take(param .PageSize ).AsEnumerable().Cast<IProduce>().ToList();
            }
            else
            {
                return result.AsEnumerable().Cast<IProduce>().ToList();
            }
        }
    }
}
