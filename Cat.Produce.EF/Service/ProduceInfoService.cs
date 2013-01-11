using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.Service;
using Cat.Produce.Core.Repository;
using Cat.Produce.Core.DomainObjects;
using Jiuzh.CoreBase.Infrastructure;
namespace Cat.Produce.EF.Service
{
    public class ProduceInfoService : IProduceInfoService
    {
        private IProduceInfoRepository _bar;
        private IDomainObjectFactory _factory;

        public ProduceInfoService(IProduceInfoRepository bar, IDomainObjectFactory factory)
        {
            _bar = bar;
            _factory = factory;
        }

        public void Add(string number, DateTime orderDate, int clientid, int productid, string material, int amount, string drawingid, DateTime? facDate, string remark, int userid)
        {
            if (_bar.GetByNumber(number) != null)
            {
                throw new Exception("添加失败，该订单号已存在！");
            }
            IProductRepository productRep = IoC.Resolve<IProductRepository>();
            IProduct product = productRep.CreateEntityByKey(productid);
            IClientInfoRepository clientRep = IoC.Resolve<IClientInfoRepository>();
            IClientInfo client = clientRep.CreateEntityByKey(clientid);
            IProduce produce = _factory.CreateProduce(number,  client, remark, userid);
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                _bar.Add(produce);
                uow.Commit();
            }
        }

        public void Add(string id, int clientid, string remark, int userid)
        {
            if (_bar.GetByNumber(id) != null)
            {
                throw new Exception("添加失败，该订单号已存在！");
            }
            IProductRepository productRep=IoC .Resolve <IProductRepository >();
            IProduce_ProductRepository produce_productRep = IoC.Resolve<IProduce_ProductRepository>();
            IClientInfoRepository clientRep = IoC.Resolve<IClientInfoRepository>();
            IClientInfo client = clientRep.CreateEntityByKey(clientid);
            IProduce produce = _factory.CreateProduce(id,client, remark, userid);
            //foreach (Add_Produce_ProudctInfo item in products)
            //{
            //    IProduct product=productRep .GetById (item .ProductId );
            //    IProduce_Product produce_product = _factory.CreateProduct_Product(produce, product, item.Amount,item.Material ,item.DrawingId );
            //    produce_productRep.Add(produce_product);
            //} 
            _bar.Add(produce);
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                uow.Commit();
            }
        }

        public void Del(int[] ids)
        {
            if (ids.Length == 0)
            {
                throw new Exception("id为空.");
            }
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    IProduce produce = _bar.GetById(ids[i]);
                    ICollection<IProduce_Product > proudcts = produce.Products;
                    IProduce_ProductRepository rep = IoC.Resolve<IProduce_ProductRepository>();
                    foreach (IProduce_Product item in proudcts)
                    {
                        rep.Remove(item);
                    }
                    _bar.Remove(produce);
                }
                uow.Commit();
            }
        }
    }
}
