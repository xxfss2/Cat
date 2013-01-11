using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Produce.EF
{
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Data.Metadata.Edm;
    using System.Data.EntityClient;
    using System.Configuration;

    using Jiuzh.EFBase;
    using Cat.Produce.EF.DomainObjects;
    public class Database : ObjectContext, IDatabase
    {

        private IQueryable<AddressList> _AddressList;
        private IQueryable<ClientInfo> _ClientInfo;
        private IQueryable<Deliverys> _Deliverys;
        private IQueryable<Produce> _ProduceInfo;
        private IQueryable<Product> _Product;
        private IQueryable<User> _user;
        private IQueryable<Produce_Product> _Produce_Product;
        private IQueryable<Factory> _factroy;
        private IQueryable<Money> _money;

        #region Factorys
        internal ObjectQuery<Factory> FactorySet
        {
            get
            {
                return FactoryDS as ObjectQuery<Factory>;
            }
        }
        public IQueryable<Factory> FactoryDS
        {
            get
            {
                if (_factroy == null)
                {
                    _factroy = GetQueryable<Factory>();
                }
                return _factroy;
            }
        }
        #endregion

        #region Produce_Products
        internal ObjectQuery<Produce_Product> Produce_ProductSet
        {
            get
            {
                return Produce_ProductDS as ObjectQuery<Produce_Product>;
            }
        }
        public IQueryable<Produce_Product> Produce_ProductDS
        {
            get
            {
                if (_Produce_Product == null)
                {
                    _Produce_Product = GetQueryable<Produce_Product>();
                }
                return _Produce_Product;
            }
        }
        #endregion

        #region AddressList
        internal ObjectQuery<AddressList> AddressListSet
        {
            get
            {
                return AddressListDS as ObjectQuery<AddressList>;
            }
        }
        public IQueryable<AddressList> AddressListDS
        {
            get
            {
                if (_AddressList == null)
                {
                    _AddressList = GetQueryable<AddressList>();
                }
                return _AddressList;
            }
        }
        #endregion

        #region ClientInfo
        internal ObjectQuery<ClientInfo> ClientInfoSet
        {
            get
            {
                return ClientInfoDS as ObjectQuery<ClientInfo>;
            }
        }
        public IQueryable<ClientInfo> ClientInfoDS
        {
            get
            {
                if (_ClientInfo == null)
                {
                    _ClientInfo = GetQueryable<ClientInfo>();
                }
                return _ClientInfo;
            }
        }
        #endregion

        #region Deliverys
        internal ObjectQuery<Deliverys> DeliverysSet
        {
            get
            {
                return DeliverysDS as ObjectQuery<Deliverys>;
            }
        }
        public IQueryable<Deliverys> DeliverysDS
        {
            get
            {
                if (_Deliverys == null)
                {
                    _Deliverys = GetQueryable<Deliverys>();
                }
                return _Deliverys;
            }
        }
        #endregion

        #region ProduceInfo
        internal ObjectQuery<Produce> ProduceInfoSet
        {
            get
            {
                return ProduceInfoDS as ObjectQuery<Produce>;
            }
        }
        public IQueryable<Produce> ProduceInfoDS
        {
            get
            {
                if (_ProduceInfo == null)
                {
                    _ProduceInfo = GetQueryable<Produce>();
                }
                return _ProduceInfo;
            }
        }
        #endregion

        #region Product
        internal ObjectQuery<Product> ProductSet
        {
            get
            {
                return ProductDS as ObjectQuery<Product>;
            }
        }
        public IQueryable<Product> ProductDS
        {
            get
            {
                if (_Product == null)
                {
                    _Product = GetQueryable<Product>();
                }
                return _Product;
            }
        }
        #endregion

        #region User
        internal ObjectQuery<User> UserSet
        {
            get
            {
                return UserDS as ObjectQuery<User>;
            }
        }
        public IQueryable<User> UserDS
        {
            get
            {
                if (_user == null)
                {
                    _user = GetQueryable<User>();
                }
                return _user;
            }
        }
        #endregion

        #region Money
        internal ObjectQuery<Money> MoneySet
        {
            get
            {
                return MoneyDS as ObjectQuery<Money>;
            }
        }
        public IQueryable<Money> MoneyDS
        {
            get
            {
                if (_money == null)
                {
                    _money = GetQueryable<Money>();
                }
                return _money;
            }
        }
        #endregion

        #region Contact
        private IQueryable<Contact> _Contact;
        internal ObjectQuery<Contact> ContactSet
        {
            get
            {
                return ContactDS as ObjectQuery<Contact>;
            }
        }
        public IQueryable<Contact> ContactDS
        {
            get
            {
                if (_Contact == null)
                {
                    _Contact = GetQueryable<Contact>();
                }
                return _Contact;
            }
        }
        #endregion

        public IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : EntityObject
        {
            var entitySetName = GetEntitySetName(typeof(TEntity));
            return GetQueryable<TEntity>(entitySetName);
        }

        private IQueryable<TEntity> GetQueryable<TEntity>(string queryString) where TEntity : EntityObject
        {
            return ApplyDataLoadOptions<TEntity>(queryString);
        }

        private ObjectQuery<TEntity> ApplyDataLoadOptions<TEntity>(string queryString) where TEntity : EntityObject
        {
            var query = CreateQuery<TEntity>(queryString);
            if (LoadOptions != null)
            {
                var members = LoadOptions.GetPreloadedMembers<TEntity>();
                foreach(var member in members)
                {
                    query = query.Include(member.Name);
                }
            }
            return query;

        }

        const String _defaultContainerName = "CatEntities";

        public Database()
            : base(ConfigurationManager.ConnectionStrings["CatEntitiesCon"].ConnectionString, _defaultContainerName)
        {
        }

        public Database(string connection)
            : base(connection, _defaultContainerName)
        {
        }

        public Database(EntityConnection connection)
            : base(connection, _defaultContainerName)
        {
        }

        private readonly static IDictionary<String, String> EntitySetNames = new Dictionary<String, String>(1000);

        public DataLoadOptions LoadOptions { get; set; }

        

        public String GetEntitySetName(Type entitySetType)
        {
            lock (EntitySetNames)
            {
                if (EntitySetNames.ContainsKey(entitySetType.FullName))
                {
                    return EntitySetNames[entitySetType.FullName];
                }

                var container = MetadataWorkspace.GetEntityContainer(DefaultContainerName, DataSpace.CSpace);

                var entitySetName = (from meta in container.BaseEntitySets
                                     where meta.BuiltInTypeKind == BuiltInTypeKind.EntitySet &&
                                     meta.ElementType.Name == entitySetType.Name
                                     select meta.Name).First();
                return entitySetName;

            }
        }

        public void InsertOnSubmit<TEntity>(TEntity entity)
            where TEntity : EntityObject
        {
            var entitySetName = GetEntitySetName(typeof(TEntity));
            AddObject(entitySetName, entity);
        }

        public void DeleteOnSubmit<TEntity>(TEntity entity)
            where TEntity : EntityObject
        {
            DeleteObject(entity);
        }

        public void InsertAllOnSubmit<TEntity>(IEnumerable<TEntity> instances)
            where TEntity : EntityObject
        {
            var entitySetName = GetEntitySetName(typeof(TEntity));
            foreach (var entity in instances)
            {
                AddObject(entitySetName, entity);
            }
        }

        public void DeleteAllOnSubmit<TEntity>(IEnumerable<TEntity> instances)
            where TEntity : EntityObject
        {
            foreach (var entity in instances)
            {
                DeleteOnSubmit(entity);
            }
        }

        public void SubmitChanges()
        {
            SaveChanges();
        }

    }
}
