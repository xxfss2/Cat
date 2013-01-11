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
    public class FactoryService : IFactoryService
    {
        private IFactoryRepository _bar;
        private IDomainObjectFactory _factory;

        public FactoryService(IFactoryRepository bar, IDomainObjectFactory factory)
        {
            _bar = bar;
            _factory = factory;
        }

        public void Add(string name, string contact, string phone, string address, string fax, string phone2)
        {
            IFactory factory = _factory.CreateFactory(name, contact, phone, address,fax,phone2  );
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                _bar.Add(factory);
                uow.Commit();
            }
        }

        public void Edit(int id, string name, string contact, string phone, string address, string fax, string phone2)
        {
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                IFactory fact = _bar.GetById(id);
                fact.Name = name;
                fact.Contact = contact;
                fact.Phone = phone;
                fact.Address = address;
                fact.Fax = fax;
                fact.Phone2 = phone2;
                uow.Commit();
            }
        }

        public void Del(int[] ids)
        {
            if (ids.Length == 0)
            {
                throw new Exception("idÎª¿Õ.");
            }
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    IFactory user = _bar.CreateEntityByKey(ids[i]);
                    _bar.Remove(user);
                }
                uow.Commit();
            }
        }
    }
}
