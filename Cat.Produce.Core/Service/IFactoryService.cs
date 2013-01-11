using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;

namespace Cat.Produce.Core.Service
{
    public interface IFactoryService
    {
        void Del(int[] id);
        void Add(string name, string contact, string phone, string address, string fax, string phone2);
        void Edit(int id, string name, string contact, string phone, string address, string fax, string phone2);
    }
}
