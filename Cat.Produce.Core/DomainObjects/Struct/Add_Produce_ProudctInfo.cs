using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Produce.Core.DomainObjects
{
    public struct Add_Produce_ProudctInfo
    {
       public int ProductId { get; set; }
       public int Amount { get; set; }
       public string DrawingId { get; set; }
       public string Material { get; set; }
    }
}
