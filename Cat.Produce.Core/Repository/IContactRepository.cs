using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.Repository;
using Cat.Produce.Core.DomainObjects;
namespace Cat.Produce.Core.Repository
{
    public interface IContactRepository:IRepository <IContact>
    {
        IContact GetById(int id);
        void Update();
    }
}
