using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.Repository;
using Cat.Produce.Core.DomainObjects;
using Cat.Produce.EF.DomainObjects;
using Cat.Produce.Core.Repository;
//using Xxf.Extension;
using Jiuzh.CoreBase;

namespace Cat.Produce.EF.Repository
{
    public class Produce_ProductRepository : BaseRepository<IProduce_Product, Produce_Product>, IProduce_ProductRepository
    {
        public Produce_ProductRepository(IDatabase database) :
            base(database)
        {
        }
        public Produce_ProductRepository(IDatabaseFactory factory)
            : base(factory)
        {
        }

        public IProduce_Product GetById(int id)
        {
            return Database.Produce_ProductDS.Where(s => s.Id == id).FirstOrDefault();
        }
        public IProduce_Product GetLastByProduceId(int id)
        {
            return Database.Produce_ProductDS.Where(s => s.ToProduce.Id == id).OrderByDescending(s => s.Id).FirstOrDefault();
        }

        public ICollection<View_Produce_Product> GetDetailList(bool? end, string clientid, string orderid, PageBreakParam pagebreak, SortParam sort)
        {
            var baseResult = from p in Database.Produce_ProductDS select p;
            if (end.HasValue)
                baseResult = baseResult.Where(s => s.IsEnd == end.Value);
            if (!string.IsNullOrEmpty(clientid))
            {
                baseResult = baseResult.Where(s => s.ToProduce.ToClientInfo.Number.Contains(clientid));
            }
            if (!string.IsNullOrEmpty(orderid))
            {
                baseResult = baseResult.Where(s => s.ToProduce.Number.Contains(orderid));
            }
            var result = from p in baseResult
                         select new View_Produce_Product
                             {
                                 Id = p.Id,
                                 Amount = p.Amount,
                                 DrawingId = p.DrawingId,
                                 FactoryName = p.ToFactory.Name,
                                 FactoryOrderDate = p.FactoryOrderDate,
                                 Material = p.Material,
                                 OrderDate = p.OrderDate,
                                 ProduceNO = p.ToProduce.Number,
                                 ProudctNO = p.ToProduct.Number,
                                 ProductName = p.ToProduct.Name,
                                 RemainAmount = p.RemainAmount,
                                 ClientPrice = p.ClientPrice,
                                 Mark = Database.MoneyDS.FirstOrDefault(s => s.Id == p.ClientPriceMoney.Value).ShortName,
                                 FactoryPrice = p.FactoryPrice,
                                  FactDevliDate =p.DelivDateFact ,
                                CustDevliDate =p.DelivDateCust ,
                             };
            if (pagebreak != null)
                pagebreak.DataCount = result.Count();
            if (sort != null)
            {
                if (sort.SortRule == SortRules.ESC)
                    result = result.OrderBy(sort.SortCode);
                else
                    result = result.OrderByDescending(sort.SortCode);
            }
            if (pagebreak != null && sort == null)
                result = result.OrderBy(s => s.Id);
            if (pagebreak != null)
                return result.Skip(pagebreak.PageIndex * pagebreak.PageSize).Take(pagebreak.PageSize).AsEnumerable().ToList();
            else
                return result.AsEnumerable().ToList();
        }

        public ICollection<View_PPtSelect> GetDetailList(string productNum, PageBreakParam pagebreak, SortParam sort)
        {
            var baseResult = from p in Database.Produce_ProductDS.Where(s => s.ToProduct.Number == productNum && s.IsEnd == true) select p;
            //if (end)
            //    baseResult = baseResult.Where(s => s.RemainAmount == 0);
            //else
            //    baseResult = baseResult.Where(s => s.RemainAmount > 0);
            //if (!string.IsNullOrEmpty(clientid))
            //{
            //    baseResult = baseResult.Where(s => s.ToProduce.ToClientInfo.Number.Contains(clientid));
            //}
            //if (!string.IsNullOrEmpty(orderid))
            //{
            //    baseResult = baseResult.Where(s => s.ToProduce.Number.Contains(orderid));
            //}
            var result = from p in baseResult
                         select new View_PPtSelect
                         {
                             Id = p.Id,
                             ExchangeRate = p.ExchangeRate ,
                             OrderDate = p.OrderDate,
                             ProduceNO = p.ToProduce.Number,
                             ClientPrice = p.ClientPrice,
                             FactoryPrice = p.FactoryPrice
                         };
            if (pagebreak != null)
                pagebreak.DataCount = result.Count();
            if (sort != null)
            {
                if (sort.SortRule == SortRules.ESC)
                    result = result.OrderBy(sort.SortCode);
                else
                    result = result.OrderByDescending(sort.SortCode);
            }
            if (pagebreak != null && sort == null)
                result = result.OrderBy(s => s.Id);
            if (pagebreak != null)
                return result.Skip(pagebreak.PageIndex * pagebreak.PageSize).Take(pagebreak.PageSize).AsEnumerable().ToList();
            else
                return result.AsEnumerable().ToList();
        }

        public int DeliveryRemind()
        {
            var keyDay = DateTime.Now.AddDays(+15);
            return Database.Produce_ProductDS.Where(s => s.DelivDateFact < keyDay && s.IsEnd ==false).Count();
        }

        public ICollection<View_Produce_Product> DeliveryRemindList()
        {
            var keyDay = DateTime.Now.AddDays(+15);
            var baseResult = from p in Database.Produce_ProductDS.Where(s => s.DelivDateFact < keyDay && s.IsEnd == false) select p;
            var result = from p in baseResult
                         select new View_Produce_Product
                         {
                             Id = p.Id,
                             Amount = p.Amount,
                             DrawingId = p.DrawingId,
                             FactoryName = p.ToFactory.Name,
                             FactoryOrderDate = p.FactoryOrderDate,
                             Material = p.Material,
                             OrderDate = p.OrderDate,
                             ProduceNO = p.ToProduce.Number,
                             ProudctNO = p.ToProduct.Number,
                             ProductName = p.ToProduct.Name,
                             RemainAmount = p.RemainAmount,
                             ClientPrice = p.ClientPrice,
                             Mark = Database.MoneyDS.FirstOrDefault(s => s.Id == p.ClientPriceMoney.Value).ShortName,
                             FactoryPrice = p.FactoryPrice,
                             FactDevliDate =p.DelivDateFact ,
                             CustDevliDate =p.DelivDateCust ,
                             Qualityer =p.Qualityer 
                         };
            return result.AsEnumerable().ToList();
        }
    }
}
