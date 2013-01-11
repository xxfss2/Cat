using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;

namespace Cat.Produce.EF
{
    using Cat.Produce.EF.DomainObjects;
    using System.Data.Objects.DataClasses;
    public interface IDatabase : IDisposable
    {
        IQueryable<AddressList> AddressListDS { get; }
        IQueryable<ClientInfo> ClientInfoDS { get; }
        IQueryable<Deliverys> DeliverysDS { get; }
        IQueryable<Produce> ProduceInfoDS { get; }
        IQueryable<Product> ProductDS { get; }
        IQueryable<User> UserDS { get; }
        IQueryable<Produce_Product> Produce_ProductDS { get; }
        IQueryable<Factory> FactoryDS { get; }
        IQueryable<Money> MoneyDS { get; }
        IQueryable<Contact> ContactDS { get; }

        void InsertOnSubmit<TEntity>(TEntity entity)
        where TEntity : EntityObject;
        void InsertAllOnSubmit<TEntity>(IEnumerable<TEntity> instances)
            where TEntity : EntityObject;
        void DeleteOnSubmit<TEntity>(TEntity entity)
            where TEntity : EntityObject;
        void DeleteAllOnSubmit<TEntity>(IEnumerable<TEntity> instances)
            where TEntity : EntityObject;
        void SubmitChanges();
        EntityKey CreateEntityKey(string entitySetName, object entity);
        void Attach(IEntityWithKey entity);
        ObjectStateManager ObjectStateManager { get; }
        object GetObjectByKey(EntityKey key);
        ObjectQuery<T> CreateQuery<T>(string queryString, params ObjectParameter[] parameters);
    }
}
