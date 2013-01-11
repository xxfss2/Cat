using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;
using Jiuzh.EFBase;

namespace Cat.Produce.EF.DomainObjects
{
    public partial class Produce : IProduce
    {
        [NonSerialized]
        EntityCollection<IProduce_Product, Produce_Product> _ToProducts;
        internal IEntityCollection<IProduce_Product> ProductsInternal
        {
            get
            {
                if (_ToProducts == null)
                {
                    EntityHelper.EnsureEntityCollection(ref _ToProducts, ToProduce_Product);
                    EntityHelper.EnsureEntityCollectionLoaded(_ToProducts);
                }
                return _ToProducts;
            }
            set
            {
                var bacterModels = value as EntityCollection<IProduce_Product, Produce_Product>;
                if (bacterModels == null)
                {
                    throw new Exception("");
                }
                _ToProducts = bacterModels;
            }
        }
        public ICollection<IProduce_Product> Products
        {
            get
            {
                return this.ProductsInternal.AsEnumerable().Cast<IProduce_Product>().ToList();
            }
        }

        [NonSerialized]
        EntityReference<IClientInfo, ClientInfo> _ToClientInfo;
        public IClientInfo ClientInfo
        {
            get
            {
                if (ToClientInfo == null)
                {
                    EntityHelper.EnsureEntityReference(ref _ToClientInfo, ToClientInfoReference);
                    EntityHelper.EnsureEntityReferenceLoaded(_ToClientInfo);
                }
                return ToClientInfo;
            }
            set
            {
                ToClientInfo = (ClientInfo)value;
            }
        }

    }
}
