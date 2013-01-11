using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;
using Jiuzh.EFBase;

namespace Cat.Produce.EF.DomainObjects
{
    public partial class Deliverys : IDeliverys
    {
        [NonSerialized]
        EntityReference<IProduce_Product, Produce_Product> _ToProduceInfo;
        public IProduce_Product Produce_ProductInfo
        {
            get
            {
                if (ToProduce_Product == null)
                {
                    EntityHelper.EnsureEntityReference(ref _ToProduceInfo, ToProduce_ProductReference);
                    EntityHelper.EnsureEntityReferenceLoaded(_ToProduceInfo);
                }
                return ToProduce_Product;
            }
            set
            {
                ToProduce_Product = (Produce_Product)value;
            }
        }

        public string TypeName
        {
            get
            {
                return ((DeliveryType)this.Type).ToString();
            }
            set
            {

            }
        }
    }
}
