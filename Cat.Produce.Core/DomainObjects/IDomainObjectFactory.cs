using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Produce.Core.DomainObjects
{
    public interface IDomainObjectFactory
    {
        IContact CreateContact(IClientInfo client, string name, string phone, string mail,string address);
        IFactory CreateFactory(string name, string contact, string phone, string address, string fax, string phone2);
        IClientInfo CreateClient(string id, string name,string contact,string mail,string phone,string address, int userId);
        IProduct CreateProduct(string namber, string name, int userId);
        IProduce CreateProduce(string id, IClientInfo client,string remark, int userid);
        IDeliverys CreateDelivery(IProduce_Product prodce_product, int amount, DateTime date, DeliveryType type,string invoice,string HScode, int userId);
        IProSchedule CreateProSchedule(IProduce_Product prodce, DateTime date, string remark, int userId);
        IProduce_Product CreateProduct_Product(IProduce produce, IProduct product, IFactory factory, int amount, string Material, string drawingId, DateTime orderDate, DateTime factOrderDate,decimal? clientPrice,decimal? factoryPrice,int?money);
    }
}
