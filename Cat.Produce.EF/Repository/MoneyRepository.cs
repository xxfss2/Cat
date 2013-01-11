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
    public class MoneyRepository : BaseRepository<IMoney, Money>, IMoneyRepository
    {
        public MoneyRepository(IDatabase database) :
            base(database)
        {
        }
        public MoneyRepository(IDatabaseFactory factory)
            : base(factory)
        {
        }
        #region IMoneyRepository 成员

        public IMoney GetById(int id)
        {
            return Database.MoneyDS.Where(s => s.Id == id).FirstOrDefault();
        }

        public ICollection<IMoney> GetAll()
        {
            return Database.MoneyDS.AsEnumerable().Cast<IMoney>().ToList();
        }

        #endregion
    }
}