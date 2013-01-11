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
    public class FactoryRepository : BaseRepository<IFactory, Factory>, IFactoryRepository
    {
        public FactoryRepository(IDatabase database) :
            base(database)
        {
        }
        public FactoryRepository(IDatabaseFactory factory)
            : base(factory)
        {

        }

        public IFactory GetById(int id)
        {
            return Database.FactoryDS.Where(s => s.Id == id).FirstOrDefault();
        }
        public ICollection<IFactory> GetAll()
        {
            return Database.FactoryDS.AsEnumerable().Cast<IFactory>().ToList();
        }

        public IFactory CreateEntityByKey(int id)
        {
            Factory entity = new Factory { Id = id };
            entity.EntityKey = Database.CreateEntityKey("Factorys", entity);
            entity = (Factory)Database.GetObjectByKey(entity.EntityKey);
            if (entity != null)
                return entity;
            Database.Attach(entity);
            return entity;
        }
    }
}
