using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jiuzh.CoreBase.Repository;
using Cat.Produce.Core.DomainObjects;
namespace Cat.Produce.Core.Repository
{
    public interface IUserRepository:IRepository <IUser>
    {
        IUser GetById(int id);
        int GetUserCount(string loginname, string password);
        ICollection<IUser> GetUser(string loginName, string passWord);
        void Update();
    }
}
