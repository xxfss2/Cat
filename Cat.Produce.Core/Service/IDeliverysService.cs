using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;

namespace Cat.Produce.Core.Service
{
    public interface IDeliverysService
    {
        void Add(int pptId, int amount, DateTime date, DeliveryType type, string invoice,string HScode,int userid);
        void Edit(int id, int amount, DateTime date, DeliveryType type, string invoice,string HScode, int userid);
    }
}
