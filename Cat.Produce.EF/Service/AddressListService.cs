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
    public class AddressListService : IAddressListService
    {
        private IAddressListRepository _bar;
        private IDomainObjectFactory _factory;

        public AddressListService(IAddressListRepository bar, IDomainObjectFactory factory)
        {
            _bar = bar;
            _factory = factory;
        }
    }
}
