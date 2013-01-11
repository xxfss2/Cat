using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.DomainObjects;

namespace Cat.Produce.Core.DomainObjects
{
    public interface IMoney : IEntity
    {
        string Name { get; set; }
        decimal Proportion { get; set; }
        /// <summary>
        /// 货币符号
        /// </summary>
        string Mark { get; set; }
        /// <summary>
        /// 缩写
        /// </summary>
        string ShortName { get; set; }
    }
}
