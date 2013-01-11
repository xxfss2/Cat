using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Produce.Core.DomainObjects
{
    public class View_PPtSelect
    {
        public int Id { get; set; }
        public string ProduceNO { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal? ClientPrice { get; set; }
        public decimal  ExchangeRate { get; set; }
        public decimal? FactoryPrice { get; set; }
    }
}
