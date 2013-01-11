using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;

namespace Cat.Produce.Core.Service
{
    public interface IProduceInfoService
    {
        void Add(string id, DateTime orderDate, int clientid, int productid, string material, int amount, string drawingid, DateTime? facDate, string remark, int userid);

        void Add(string id,int clientid, string remark, int userid);

        void Del(int[] ids);
    }
}
