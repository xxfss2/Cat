using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;

namespace Cat.Produce.Core.Service
{
    public interface IProductService
    {
        void Add(string number,string name, int userid,string process);
        void Del(int[] id);
        void Edit(int id, string number, string name, int userid, string process);
    }
}
