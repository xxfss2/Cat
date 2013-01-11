using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;

namespace Cat.Produce.Core.Service
{
    public interface IContactService
    {
        void Add(int id, CantactType type,string name, string phone, string mail, string address);
    }
}
