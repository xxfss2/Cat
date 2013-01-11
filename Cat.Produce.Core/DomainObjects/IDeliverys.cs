using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.DomainObjects;

namespace Cat.Produce.Core.DomainObjects
{
    public interface IDeliverys : IEntity
    {
        DateTime DDate { get; set; }
        Int32 Amount { get; set; }
        Int32 Type { get; set; }
        string Invoice { get; set; }
        Int32 UserId { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime ModifiedAt { get; set; }
        IProduce_Product Produce_ProductInfo { get; set; }
        string TypeName { get; set; }
        string HScode { get; set; }
    }
}
