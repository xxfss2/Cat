using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.DomainObjects;

namespace Cat.Produce.Core.DomainObjects
{
    public interface IProduce_Product:IEntity
    {
        int RemainAmount { get; set; }
        int Amount { get; set; }
        string Material { get; set; }
        string DrawingId { get; set; }
        DateTime OrderDate { get; set; }
        DateTime? FactoryOrderDate { get; set; }
        IProduct Product { get; set; }
        IProduce Produce { get; set; }
        IFactory Factory { get; set; }
        decimal? ClientPrice { get; set; }
        decimal? FactoryPrice { get; set; }
        int? ClientPriceMoney { get; set; }
        bool IsEnd { get; set; }
        string Qualityer { get; set; }
        decimal ModelPrice  {get;set;}
        DateTime? DelivDateCust { get; set; }
        DateTime? DelivDateFact { get; set; }
        ICollection<IDeliverys> Deliverys { get; }
        ICollection<IProSchedule> Schedules { get; }
        decimal ExchangeRate { get; set; }
    }
}
