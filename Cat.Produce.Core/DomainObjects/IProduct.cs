using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.DomainObjects;

namespace Cat.Produce.Core.DomainObjects
{
    public interface IProduct
    {
        int Id { get; set; }
        string Number { get; set; }
        String Name { get; set; }
        Int32 UserId { get; set; }
        string Process { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime ModifiedAt { get; set; }
        ICollection<IProduce_Product> Produce_products { get; }

    }
}
