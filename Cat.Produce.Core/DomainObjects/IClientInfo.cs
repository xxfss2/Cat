using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.DomainObjects;

namespace Cat.Produce.Core.DomainObjects
{
    public interface IClientInfo
    {
        int Id { get; set; }
        string Number { get; set; }
        String Name { get; set; }
        string Contact { get; set; }
        string Mail { get; set; }
        string Phone { get; set; }
        Int32 UserId { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime ModifiedAt { get; set; }
        string Site { get; set; }
        ICollection<IProduce> ProduceInfos { get; }
        string Address { get; set; }
        ICollection<IContact> Contacts{get;}
    }
}
