using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat .Produce .Core .DomainObjects ;

namespace Cat.Produce.Core.Service
{
   public interface IProduce_ProductService
    {
       void End(int id);
       void Del(int id);
       void Add(int productId, int pruduceId, int factoryId, int amount, string material, string drawingId, DateTime orderdate, DateTime factOrderDate, decimal? clientPrice, decimal? factoryPrice, int? money, DateTime? devliDateFact, DateTime? devliDateCus, string qualityer, decimal modelPrice, decimal exchangeRate);
       void Edit(int id, int factoryId, int amount, string material, string drawingId, DateTime orderdate, DateTime factOrderDate, decimal? clientPrice, decimal? factoryPrice, int? money, DateTime? devliDateFact, DateTime? devliDateCus, string qualityer, decimal modelPrice, IProduct product, decimal exchangeRate);
    }
}
