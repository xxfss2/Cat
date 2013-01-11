using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.Repository;
using Cat.Produce.Core.DomainObjects;
using Jiuzh.CoreBase;

namespace Cat.Produce.Core.Repository
{
    public interface IProduce_ProductRepository : IRepository<IProduce_Product>
    {
        IProduce_Product GetById(int id);
        /// <summary>
        /// 获取某个订单的最后一个添加的产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IProduce_Product GetLastByProduceId(int id);
        ICollection<View_Produce_Product> GetDetailList(bool? end,string clientid,string orderid, PageBreakParam pagebreak,SortParam sort);
        ICollection<View_PPtSelect> GetDetailList(string productNum, PageBreakParam pagebreak, SortParam sort);
        ICollection<View_Produce_Product> DeliveryRemindList();
        int DeliveryRemind();
    }
}
