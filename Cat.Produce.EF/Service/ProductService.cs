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
    public class ProductService : IProductService
    {
        private IProductRepository _bar;
        private IDomainObjectFactory _factory;

        public ProductService(IProductRepository bar, IDomainObjectFactory factory)
        {
            _bar = bar;
            _factory = factory;
        }

        public void Add(string id, string name, int userid, string process)
        {
            if (_bar.GetByNameOrNumber(id,name).Count > 0)
            {
                throw new Exception("添加失败，改产品名称已经存在！");
            }
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                IProduct product = _factory.CreateProduct(id,name, userid);
                product.Process=process ;
                _bar.Add(product);
                uow.Commit();
            }
        }
        public void Del(int[] ids)
        {
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    IProduct product = _bar.GetById(ids[0]);
                    _bar.Remove(product);
                }
                uow.Commit();
            }
        }

        public void Edit(int id, string number, string name, int userid, string process)
        {
            ICollection<IProduct> products = _bar.GetByNameOrNumber(number, name);
            if (products.Count > 1)
            {
                throw new Exception("无法修改，该产品编号和名称已存在！");
            }
            else if (products.Count == 1)
            {
                if (products.FirstOrDefault().Id != id)
                {
                    throw new Exception("无法修改，该产品编号和名称已存在！");
                }
            }
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                IProduct prodct = _bar.GetById(id);
                prodct.Number = number;
                prodct.Name = name;
                prodct.UserId = userid;
                prodct.ModifiedAt = DateTime.Now;
                prodct.Process = process;
                uow.Commit();
            }
        }
    }
}
