using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.Repository;
using Cat.Produce.Core.DomainObjects;
using Jiuzh .CoreBase;
namespace Cat.Produce.Core.Repository
{
    public interface IProductRepository:IRepository <IProduct>
    {
        IProduct GetById(int id);
        IProduct GetByNum(string number);
        ICollection<IProduct> GetsByNum(string number);
        IProduct CreateEntityByKey(int id);
        ICollection<IProduct> GetByNameOrNumber(string number,string name);
        ICollection<IProduct> GetByNameAndNumber(string number, string name);
        ICollection<IProduct> GetAll(PageBreakParam param);
        void Update();
    }
}
