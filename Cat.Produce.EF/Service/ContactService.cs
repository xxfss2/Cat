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
    public class ContactService : IContactService
    {
        private IContactRepository _bar;
        private IDomainObjectFactory _factory;

        public ContactService(IContactRepository bar, IDomainObjectFactory factory)
        {
            _bar = bar;
            _factory = factory;
        }

        public void Add(int id, CantactType type, string name, string phone, string mail, string address)
        {
            IClientInfoRepository clientRep = IoC.Resolve<IClientInfoRepository>();
            IFactoryRepository factroyRep=IoC.Resolve <IFactoryRepository >();
            IClientInfo client = null ;
            IFactory factory=null ;
            if (type == CantactType.工厂联系人)
            {
                factory = factroyRep.GetById(id);
            }
            else
            {
                client = clientRep.GetById(id);
            }
            IContact contact = _factory.CreateContact(client, name, phone, mail, address);
            contact.Factory = factory;
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                _bar.Add(contact);
                uow.Commit();
            }
        }
    }
}
