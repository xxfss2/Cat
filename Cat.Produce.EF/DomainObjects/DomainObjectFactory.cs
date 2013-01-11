using System;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;
namespace Cat.Produce.EF.DomainObjects
{
    public class DomainObjectFactory : IDomainObjectFactory
    {
        public IClientInfo CreateClient(string number, string name, string contact, string mail, string phone,string address, int userId)
        {
            return new ClientInfo 
            {
                Number = number,
                Name =name ,
                Contact =contact ,
                Mail =mail ,
                Phone =phone ,
                CreatedAt =DateTime .Now ,
                ModifiedAt =DateTime .Now ,
                UserId =userId,
                Address =address
            };
        }
        public IProduct CreateProduct(string namber,string name, int userid)
        {
            return new Product
            {
                Number =namber ,
                Name = name,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                UserId = userid
            };
        }

        public IProduce CreateProduce(string number,IClientInfo client,string remark,int userid)
        {
            return new Produce
            {
                Number = number,
                ToClientInfo =(ClientInfo)client,
                Remark =remark ,
                CreatedAt =DateTime .Now ,
                ModifiedAt =DateTime .Now ,
                UserId =userid 
            };
        }

        public IDeliverys CreateDelivery(IProduce_Product  prodce_product, int amount, DateTime date,DeliveryType type,string invoice,string hsCode,int userId)
        {
            return new Deliverys
            {
                ToProduce_Product = (Produce_Product)prodce_product,
                DDate = date,
                Amount = amount,
                Type =(int)type ,
                UserId =userId ,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Invoice =invoice ,
                HScode =hsCode 
            };
        }

        public IProSchedule CreateProSchedule(IProduce_Product prodce, DateTime date, string remark, int userId)
        {
            return new ProSchedule
            {
                ToProduce_Product  = (Produce_Product)prodce,
                Date = date,
                Remark =remark ,
                UserId = userId,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
        }

        public IProduce_Product CreateProduct_Product(IProduce produce, IProduct product, IFactory factory, int amount, string Material, string drawingId, DateTime orderDate, DateTime factOrderDate, decimal? clientPrice, decimal? factoryPrice,int? money)
        {
            return new Produce_Product
            {
                ToProduce = (Produce)produce,
                ToProduct = (Product)product,
                ToFactory =(Factory )factory ,
                Amount = amount,
                RemainAmount = amount,
                Material =Material ,
                DrawingId =drawingId ,
                OrderDate =orderDate ,
                FactoryOrderDate =factOrderDate ,
                ClientPrice =clientPrice ,
                FactoryPrice =factoryPrice ,
                ClientPriceMoney =money
            };
        }

        public IFactory CreateFactory(string name, string contact, string phone, string address,string fax,string phone2)
        {
            return new Factory
            {
                Name = name,
                Contact = contact,
                Phone = phone,
                Address = address,
                Fax =fax ,
                Phone2 =phone2
            };
        }

        public IContact CreateContact(IClientInfo client, string name, string phone, string mail, string address)
        {
            return new Contact
            {
                Name = name,
                MailAddress = mail,
                Address = address,
                Client = client,
                Phone = phone
            };
        }
    }
}
