using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;
using Jiuzh.EFBase;

namespace Cat.Produce.EF.DomainObjects
{
    public partial class ClientInfo : IClientInfo
    {
        [NonSerialized]
        EntityCollection<IProduce, Produce> _ProduceInfo;

        internal IEntityCollection<IProduce> ProduceInfosInternal
        {
            get
            {
                if (_ProduceInfo == null)
                {
                    EntityHelper.EnsureEntityCollection(ref _ProduceInfo, ToProduce);
                    EntityHelper.EnsureEntityCollectionLoaded(_ProduceInfo);
                }
                return _ProduceInfo;
            }
            set
            {
                var bacterModels = value as EntityCollection<IProduce, Produce>;
                if (bacterModels == null)
                {
                    throw new Exception("");
                }
                _ProduceInfo = bacterModels;
            }
        }
        public ICollection<IProduce> ProduceInfos
        {
            get
            {
                return this.ProduceInfosInternal.AsEnumerable().Cast<IProduce>().ToList();
            }
        }

        [NonSerialized]
        EntityCollection<IContact, Contact> _ToContact;
        internal IEntityCollection<IContact> ToContactsInternal
        {
            get
            {
                if (_ToContact == null)
                {
                    EntityHelper.EnsureEntityCollection(ref _ToContact, ToContact);
                    EntityHelper.EnsureEntityCollectionLoaded(_ToContact);
                }
                return _ToContact;
            }
            set
            {
                var entitys = value as EntityCollection<IContact, Contact>;
                if (entitys == null)
                {
                    throw new Exception("");
                }
                _ToContact = entitys;
            }
        }
        public ICollection<IContact> Contacts
        {
            get
            {
                return this.ToContactsInternal.AsEnumerable().Cast<IContact>().ToList();
            }
        }
    }
}
