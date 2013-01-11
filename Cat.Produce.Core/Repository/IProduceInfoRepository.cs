using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.Repository;
using Cat.Produce.Core.DomainObjects;
using Jiuzh.CoreBase;
namespace Cat.Produce.Core.Repository
{
    public interface IProduceInfoRepository:IRepository <IProduce>
    {
        IProduce GetById(int id);
        IProduce GetByNumber(string number);
        ICollection<IProduce> GetAll();
        /// <summary>
        /// 当前活跃订单
        /// </summary>
        /// <returns></returns>
        ICollection<IProduce> GetAllCurr(int userId, PageBreakParam param);
        /// <summary>
        /// 历史订单
        /// </summary>
        /// <returns></returns>
        ICollection<IProduce> GetAllHistroy(int userId);
        void Update();
    }
}
