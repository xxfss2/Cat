using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.DomainObjects;

namespace Cat.Produce.Core.DomainObjects
{
    public interface IProSchedule:IEntity
    {
        DateTime Date { get; set; }
        string Remark { get; set; }
        int UserId{get;set ;}
        DateTime CreatedAt{get;set;}
        DateTime ModifiedAt{get;set;}
        IProduce_Product  Produce_product{get;set;}
    }
}
