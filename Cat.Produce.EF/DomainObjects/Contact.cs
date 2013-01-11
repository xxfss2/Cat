using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.DomainObjects;
using Jiuzh.EFBase;

namespace Cat.Produce.EF.DomainObjects
{
    public partial class Contact:IContact
    {
        [NonSerialized]
        EntityReference<IClientInfo, ClientInfo> _ToClientInfo;

        public IClientInfo Client
        {
            get
            {
                if (ToClientInfo  == null)
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

        [NonSerialized]
        EntityReference<IFactory, Factory> _ToFactory;

        public IFactory Factory
        {
            get
            {
                if (ToFactory == null)
                {
                    EntityHelper.EnsureEntityReference(ref _ToFactory, ToFactoryReference );
                    EntityHelper.EnsureEntityReferenceLoaded(_ToFactory);
                }
                return ToFactory;
            }
            set
            {
                ToFactory = (Factory)value;
            }
        }
    }
}
