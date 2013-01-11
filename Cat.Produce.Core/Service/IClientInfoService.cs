using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;

namespace Cat.Produce.Core.Service
{
    public interface IClientInfoService
    {
        void Add(string number, string name, string contact, string mail, string phone, string address, int userid,string site);
        void Del(int[] id);
        void Edit(int id, string number, string name, string contact, string mail, string phone, string address, int userid, string site);
    }
}
