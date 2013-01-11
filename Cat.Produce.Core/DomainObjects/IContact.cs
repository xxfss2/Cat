using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.DomainObjects;

namespace Cat.Produce.Core.DomainObjects
{
    public  interface IContact:IEntity 
    {
        string Name { get; set; }
        string Phone { get; set; }
        string MailAddress { get; set; }
        string Address { get; set; }
        IClientInfo Client { get; set; }
        IFactory Factory { get; set; }
    }
}
