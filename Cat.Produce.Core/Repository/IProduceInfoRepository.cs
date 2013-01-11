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
        /// ��ǰ��Ծ����
        /// </summary>
        /// <returns></returns>
        ICollection<IProduce> GetAllCurr(int userId, PageBreakParam param);
        /// <summary>
        /// ��ʷ����
        /// </summary>
        /// <returns></returns>
        ICollection<IProduce> GetAllHistroy(int userId);
        void Update();
    }
}
