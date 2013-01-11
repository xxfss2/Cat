using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Produce.Core.DomainObjects
{
    public class View_Produce_Product
    {
        public int Id { get; set; }
        public string ProduceNO { get; set; }
        public string ProudctNO { get; set; }
        public int RemainAmount { get; set; }
        public int Amount { get; set; }
        /// <summary>
        /// 实际交货数量
        /// </summary>
        public int ActualAmount { get { return Amount - RemainAmount; }}
        public string Material { get; set; }
        public string DrawingId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? FactoryOrderDate { get; set; }
        public string ProductName { get; set; }
        public string FactoryName { get; set; }
        public decimal? ClientPrice { get; set; }
        public string Mark { get; set; }
        public decimal? FactoryPrice { get; set; }
        public DateTime? FactDevliDate { get; set; }
        public DateTime? CustDevliDate { get; set; }
        public string Qualityer { get; set; }
    }
}
