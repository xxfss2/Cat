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
    public class DeliverysService : IDeliverysService
    {
        private IDeliverysRepository _bar;
        private IDomainObjectFactory _factory;

        public DeliverysService(IDeliverysRepository bar, IDomainObjectFactory factory)
        {
            _bar = bar;
            _factory = factory;
        }

        public void Add(int pptId, int amount, DateTime date,DeliveryType type,string invoice,string HScode,int userid)
        {
            IProduce_ProductRepository produce_productRep = IoC.Resolve<IProduce_ProductRepository>();
            IProduce_Product prodcue_product = produce_productRep.GetById(pptId);
            //if (amount > prodcue_product.RemainAmount)
            //{
            //    throw new Exception("录入失败，交货数量大于剩余数量！");
            //}
            IDeliverys deli = _factory.CreateDelivery(prodcue_product, amount, date, type,invoice,HScode , userid);
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                prodcue_product.RemainAmount -= amount;
                _bar.Add(deli);
                uow.Commit();
            }
        }

        public void Edit(int id, int amount, DateTime date, DeliveryType type, string invoice,string HScode, int userid)
        {
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                IDeliverys dev = _bar.GetById(id);
                dev.DDate = date;
                dev.Type = (int)type;
                dev.Invoice = invoice;
                dev.HScode = HScode;
                int val = amount - dev.Amount;
                IProduce_Product pro= dev.Produce_ProductInfo;
                pro .RemainAmount -=val ;
                //if (pro.RemainAmount < 0 || pro.RemainAmount > pro.Amount)
                //{
                //    throw new Exception("修改失败，数量有误！");
                //}
                dev.Amount = amount;
                uow.Commit();
            }
        }
    }
}
