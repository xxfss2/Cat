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
    public class UserService : IUserService
    {
        private IUserRepository _bar;
        private IDomainObjectFactory _factory;

        public UserService(IUserRepository bar, IDomainObjectFactory factory)
        {
            _bar = bar;
            _factory = factory;
        }

    }
}
