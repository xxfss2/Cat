using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.Repository;
using Cat.Produce.Core.DomainObjects;
using Cat.Produce.EF.DomainObjects;
using Cat.Produce.Core.Repository;
using Jiuzh.CoreBase;

namespace Cat.Produce.EF.Repository
{
    public class ProductRepository : BaseRepository<IProduct, Product>, IProductRepository
    {
        public ProductRepository(IDatabase database) :
            base(database)
        {
        }
        public ProductRepository(IDatabaseFactory factory)
            : base(factory)
        {
        }

        public IProduct GetById(int  id)
        {
            return Database.ProductDS.Where(s => s.Id == id).FirstOrDefault();
        }

        public IProduct GetByNum(string number)
        {
            return Database.ProductDS.Where(s => s.Number == number).FirstOrDefault();
        }

        public ICollection<IProduct> GetsByNum(string number)
        {
            return Database.ProductDS.Where(s => s.Number.Contains(number)).AsEnumerable().Cast<IProduct>().ToList();
        }

        public IProduct CreateEntityByKey(int id)
        {
            Product entity = new Product { Id = id };
            entity.EntityKey = Database.CreateEntityKey("Products", entity);
            Database.Attach(entity);
            return entity;
        }

        public ICollection<IProduct> GetByNameOrNumber(string id, string name)
        {
            return Database.ProductDS.Where(s => s.Name == name || s .Number ==id).AsEnumerable().Cast<IProduct>().ToList();
        }
        public ICollection<IProduct> GetByNameAndNumber(string number, string name)
        {
            return Database.ProductDS.Where(s => s.Name == name && s.Number == number).AsEnumerable().Cast<IProduct>().ToList();
        }

        public ICollection<IProduct> GetAll(PageBreakParam param)
        {
            var result = Database.ProductDS;
            if (param != null)
            {
                param.DataCount = result.Count();
                return result.OrderBy(s => s.Id).Skip(param .PageIndex  * param .PageSize ).Take(param .PageSize).AsEnumerable().Cast<IProduct>().ToList();
            }
            else
            {
                return result.AsEnumerable().Cast<IProduct>().ToList();
            }
        }
    }
}
