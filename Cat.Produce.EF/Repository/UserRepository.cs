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
    public class UserRepository : BaseRepository<IUser, User>, IUserRepository
    {
        public UserRepository(IDatabase database) :
            base(database)
        {
        }
        public UserRepository(IDatabaseFactory factory)
            : base(factory)
        {
        }

        public IUser GetById(int id)
        {
            return Database.UserDS.Where(s => s.Id == id).FirstOrDefault();
        }

        public int GetUserCount(string loginname, string password)
        {
            return Database.UserDS.Where(s => s.LoginName == loginname && s.PassWord == password).Count();
        }

        public ICollection<IUser> GetUser(string loginName, string passWord)
        {
            return Database.UserDS.Where(s => s.LoginName == loginName && s.PassWord == passWord).AsEnumerable().Cast<IUser>().ToList();
        }
    }
}
