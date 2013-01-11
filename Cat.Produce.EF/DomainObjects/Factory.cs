using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;
using Jiuzh.EFBase;

namespace Cat.Produce.EF.DomainObjects
{
    public partial class Factory:IFactory
    {
        [NonSerialized]
        EntityCollection<IProduce_Product, Produce_Product> _produceInfo;

        internal IEntityCollection<IProduce_Product> IProduceInfosInternal
        {
            get
            {
                if (_produceInfo == null)
                {
                    EntityHelper.EnsureEntityCollection(ref _produceInfo, ToProduce_Product);
                    EntityHelper.EnsureEntityCollectionLoaded(_produceInfo);
                }
                return _produceInfo;
            }
            set
            {
                var bacterModels = value as EntityCollection<IProduce_Product, Produce_Product>;
                if (bacterModels == null)
                {
                    throw new Exception("");
                }
                _produceInfo = bacterModels;
            }
        }

        public ICollection<IProduce_Product> Produce_products
        {
            get
            {
                return this.IProduceInfosInternal.AsEnumerable().Cast<IProduce_Product>().ToList();
            }
        }
    }
}
