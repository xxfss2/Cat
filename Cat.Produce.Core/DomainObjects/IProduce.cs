using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.DomainObjects;

namespace Cat.Produce.Core.DomainObjects
{
    public interface IProduce
    {
        int Id { get; set; }
        string Number { get; set; }
        /// <summary>
        /// 单子是否结束
        /// </summary>
        bool IsEnd { get; set; }
        String Remark { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime ModifiedAt { get; set; }
        Int32 UserId { get; set; }
        ICollection<IProduce_Product> Products { get; }
        //ICollection<IDeliverys> Deliverys { get; }
        IClientInfo ClientInfo { get; set; }
    }
}
