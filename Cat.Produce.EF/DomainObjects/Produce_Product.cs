using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;
using Jiuzh.EFBase;

namespace Cat.Produce.EF.DomainObjects
{
    public partial class Produce_Product:IProduce_Product
    {
        [NonSerialized]
        EntityReference<IProduct, Product> _ToProductInfo;
        public IProduct Product
        {
            get
            {
                if (ToProduct  == null)
                {
                    EntityHelper.EnsureEntityReference(ref _ToProductInfo, ToProductReference);
                    EntityHelper.EnsureEntityReferenceLoaded(_ToProductInfo);
                }
                return ToProduct;
            }
            set
            {
                ToProduct = (Product)value;
            }
        }
        [NonSerialized]
        EntityReference<IProduce, Produce> _ToProduceInfo;
        public IProduce Produce
        {
            get
            {
                if (ToProduce  == null)
                {
                    EntityHelper.EnsureEntityReference(ref _ToProduceInfo, ToProduceReference);
                    EntityHelper.EnsureEntityReferenceLoaded(_ToProduceInfo);
                }
                return ToProduce;
            }
            set
            {
                ToProduce = (Produce)value;
            }
        }

        [NonSerialized]
        EntityReference<IFactory, Factory> _ToFactory;
        public IFactory Factory
        {
            get
            {
                if (ToFactory  == null)
                {
                    EntityHelper.EnsureEntityReference(ref _ToFactory, ToFactoryReference);
                    EntityHelper.EnsureEntityReferenceLoaded(_ToFactory);
                }
                return ToFactory;
            }
            set
            {
                ToFactory = (Factory)value;
            }
        }

        [NonSerialized]
        EntityCollection<IDeliverys, Deliverys> _Deliverys;

        internal IEntityCollection<IDeliverys> DeliverysInternal
        {
            get
            {
                if (_Deliverys == null)
                {
                    EntityHelper.EnsureEntityCollection(ref _Deliverys, ToDelivery);
                    EntityHelper.EnsureEntityCollectionLoaded(_Deliverys);
                }
                return _Deliverys;
            }
            set
            {
                var bacterModels = value as EntityCollection<IDeliverys, Deliverys>;
                if (bacterModels == null)
                {
                    throw new Exception("");
                }
                _Deliverys = bacterModels;
            }
        }
        public ICollection<IDeliverys> Deliverys
        {
            get
            {
                return this.DeliverysInternal.AsEnumerable().Cast<IDeliverys>().ToList();
            }
        }

        [NonSerialized]
        EntityCollection<IProSchedule, ProSchedule> _ToSchedule;
        internal IEntityCollection<IProSchedule> ProScheduleInternal
        {
            get
            {
                if (_ToSchedule == null)
                {
                    EntityHelper.EnsureEntityCollection(ref _ToSchedule, ToProSchedule);
                    EntityHelper.EnsureEntityCollectionLoaded(_ToSchedule);
                }
                return _ToSchedule;
            }
            set
            {
                var bacterModels = value as EntityCollection<IProSchedule, ProSchedule>;
                if (bacterModels == null)
                {
                    throw new Exception("");
                }
                _ToSchedule = bacterModels;
            }
        }
        public ICollection<IProSchedule> Schedules
        {
            get
            {
                return this.ProScheduleInternal.AsEnumerable().Cast<IProSchedule>().ToList();
            }
        }
    }
}
