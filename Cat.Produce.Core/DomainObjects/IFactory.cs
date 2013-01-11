using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.DomainObjects;

namespace Cat.Produce.Core.DomainObjects
{
    public interface IFactory : IEntity
    {
        String Name { get; set; }
        string Address { get; set; }
        string Contact { get; set; }
        string Phone { get; set; }
        string Fax { get; set; }
        string Phone2 { get; set; }
        ICollection<IProduce_Product> Produce_products { get; }

    }
}
