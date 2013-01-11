using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;
using Jiuzh.EFBase;

namespace Cat.Produce.EF.DomainObjects
{
    public partial class ProSchedule:IProSchedule
    {
        [NonSerialized]
        EntityReference<IProduce_Product , Produce_Product > _ToProduceInfo;
        public IProduce_Product Produce_product
        {
            get
            {
                if (ToProduce_Product  == null)
                {
                    EntityHelper.EnsureEntityReference(ref _ToProduceInfo, ToProduce_ProductReference );
                    EntityHelper.EnsureEntityReferenceLoaded(_ToProduceInfo);
                }
                return ToProduce_Product;
            }
            set
            {
                ToProduce_Product = (Produce_Product)value;
            }
        }
    }
}
