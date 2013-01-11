using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.Repository;
using Cat.Produce.Core.DomainObjects;
namespace Cat.Produce.Core.Repository
{
    public interface IFactoryRepository:IRepository <IFactory>
    {
        IFactory GetById(int id);
        ICollection<IFactory> GetAll();
        IFactory CreateEntityByKey(int id);
        void Update();
    }
}
