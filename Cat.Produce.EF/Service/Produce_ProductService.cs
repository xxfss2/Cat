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
    public class Produce_ProductService : IProduce_ProductService
    {
        private IProduce_ProductRepository _bar;
        private IDomainObjectFactory _factory;

        public Produce_ProductService(IProduce_ProductRepository bar, IDomainObjectFactory factory)
        {
            _bar = bar;
            _factory = factory;
        }
        public void Add(int productId, int pruduceId, int factoryId, int amount, string material, string drawingId, DateTime orderdate, DateTime factOrderDate, decimal? clientPrice, decimal? factoryPrice, int? money, DateTime? devliDateFact, DateTime? devliDateCus, string qualityer, decimal modelPrice, decimal exchangeRate)
        {
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                IProductRepository productRep = IoC.Resolve<IProductRepository>();
                IProduceInfoRepository produceRep = IoC.Resolve<IProduceInfoRepository>();
                IFactoryRepository factoryRep = IoC.Resolve<IFactoryRepository>();
                IProduct product = productRep.GetById(productId);
                IProduce produce = produceRep.GetById(pruduceId);
                IFactory fact = factoryRep.GetById(factoryId);

                IProduce_Product prodcue_product = _factory.CreateProduct_Product(produce, product, fact, amount, material, drawingId, orderdate, factOrderDate,clientPrice ,factoryPrice,money  );
                prodcue_product.DelivDateCust = devliDateCus;
                prodcue_product.DelivDateFact = devliDateFact;
                prodcue_product.Qualityer = qualityer;
                prodcue_product.ModelPrice = modelPrice;
                prodcue_product.ExchangeRate = exchangeRate;
                _bar.Add(prodcue_product);
                uow.Commit();
            }
        }


        public void Edit(int id, int factoryId, int amount, string material, string drawingId, DateTime orderdate, DateTime factOrderDate, decimal? clientPrice, decimal? factoryPrice, int? money, DateTime? devliDateFact, DateTime? devliDateCus, string qualityer, decimal modelPrice, IProduct product, decimal exchangeRate)
        {
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                IFactoryRepository factoryRep = IoC.Resolve<IFactoryRepository>();
                IFactory fact = factoryRep.GetById(factoryId);

                IProduce_Product p = _bar.GetById(id);
                p.Factory = fact;
                p.Amount = amount;
                p.Material = material;
                p.DrawingId = drawingId;
                p.OrderDate = orderdate;
                p.FactoryOrderDate = factOrderDate;
                p.ClientPrice = clientPrice;
                p.FactoryPrice = factoryPrice;
                p.ClientPriceMoney = money;
                p.DelivDateCust = devliDateCus;
                p.DelivDateFact = devliDateFact;
                p.Qualityer = qualityer;
                p.ModelPrice = modelPrice;
                p.Product = product;
                p.ExchangeRate = exchangeRate;
                uow.Commit();
            }
        }

        public void End(int id)
        {
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                IProduce_Product ppt = _bar.GetById(id);
                ppt.IsEnd = true;
                IProduce p = ppt.Produce;
                if (p.Products.Where(s => !s.IsEnd).Count() == 0)
                {
                    p.IsEnd = true;
                }
                uow.Commit();
            }
        }

        public void Del(int id)
        {
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                IProduce_Product ppt = _bar.GetById(id);
                if (ppt.RemainAmount != ppt.Amount)
                {
                    throw new Exception("该订单产品已存在交货记录，无法删除");
                }
                _bar.Remove(ppt);
                uow.Commit();
            }
        }

    }
}
