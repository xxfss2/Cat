using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.Repository;
using Cat.Produce.Core.DomainObjects;
namespace Cat.Produce.Core.Repository
{
    public interface IMoneyRepository : IRepository<IMoney>
    {
        IMoney GetById(int id);
        ICollection<IMoney> GetAll();
    }
}
