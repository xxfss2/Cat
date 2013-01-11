using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.Repository;
using Cat.Produce.Core.DomainObjects;
namespace Cat.Produce.Core.Repository
{
    public interface IClientInfoRepository:IRepository <IClientInfo>
    {
        IClientInfo GetById(int  id);
        IClientInfo CreateEntityByKey(int id);
        ICollection<IClientInfo> GetByNameOrId(string id,string name);
        ICollection<IClientInfo> GetByNameAndId(string id, string name);
        ICollection<IClientInfo> GetByUser(int userid);
        void Update();
    }
}
