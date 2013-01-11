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
    public class ClientInfoRepository : BaseRepository<IClientInfo, ClientInfo>, IClientInfoRepository
    {
        public ClientInfoRepository(IDatabase database) :
            base(database)
        {
        }
        public ClientInfoRepository(IDatabaseFactory factory)
            : base(factory)
        {
        }

        public IClientInfo GetById(int id)
        {
            return Database.ClientInfoDS.Where(s => s.Id == id).FirstOrDefault();
        }

        public ICollection<IClientInfo> GetByNameOrId(string number,string name)
        {
            return Database.ClientInfoDS.Where(s => s.Name == name || s.Number == number).AsEnumerable().Cast<IClientInfo>().ToList();
        }
        public ICollection<IClientInfo> GetByNameAndId(string number, string name)
        {
            return Database.ClientInfoDS.Where(s => s.Name == name && s.Number == number).AsEnumerable().Cast<IClientInfo>().ToList();
        }

        public ICollection<IClientInfo> GetByUser(int userid)
        {
            return Database.ClientInfoDS.Where(s => s.UserId == userid).AsEnumerable().Cast<IClientInfo>().ToList();
        }

        public IClientInfo CreateEntityByKey(int id)
        {
            ClientInfo entity = new ClientInfo { Id = id };
            entity.EntityKey = Database.CreateEntityKey("ClientInfos", entity);
            entity= (ClientInfo)Database.GetObjectByKey(entity.EntityKey);
            if (entity != null)
                return entity;
            Database.Attach(entity);
            return entity;
        }
    }
}
