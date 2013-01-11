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
    public class AddressListRepository : BaseRepository<IAddressList, AddressList>, IAddressListRepository
    {
        public AddressListRepository(IDatabase database) :
            base(database)
        {
        }
        public AddressListRepository(IDatabaseFactory factory)
            : base(factory)
        {
        }

        public IAddressList GetById(int id)
        {
            return Database.AddressListDS.Where(s => s.Id == id).FirstOrDefault();
        }
     
    }
}
