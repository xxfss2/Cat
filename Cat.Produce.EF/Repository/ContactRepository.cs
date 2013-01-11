using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.Repository;
using Cat.Produce.Core.DomainObjects;
using Cat.Produce.EF.DomainObjects;
using Cat.Produce.Core.Repository;
namespace Cat.Produce.EF.Repository
{
    public class ContactRepository : BaseRepository<IContact, Contact>, IContactRepository
    {
        public ContactRepository(IDatabase database) :
            base(database)
        {
        }
        public ContactRepository(IDatabaseFactory factory)
            : base(factory)
        {
        }

        public IContact GetById(int id)
        {
            return Database.ContactDS.Where(s => s.Id == id).FirstOrDefault();
        }
     
    }
}
