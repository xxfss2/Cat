using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cat.Produce.Core.Service;
using Cat.Produce.Core.Repository;
using Cat.Produce.Core.DomainObjects;
using Jiuzh.CoreBase.Infrastructure;
namespace Cat.Produce.EF.Service
{
    public class ClientInfoService : IClientInfoService
    {
        private IClientInfoRepository _bar;
        private IDomainObjectFactory _factory;

        public ClientInfoService(IClientInfoRepository bar, IDomainObjectFactory factory)
        {
            _bar = bar;
            _factory = factory;
        }
        public void Add(string id, string name, string contact, string mail, string phone, string address, int userId, string site)
        {
            if (_bar.GetByNameOrId(id, name).Count > 0)
            {
                throw new Exception("无法添加，该客户名称已存在!");
            }
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                IClientInfo user = _factory.CreateClient(id, name,contact ,mail ,phone ,address , userId);
                user.Site = site;
                _bar.Add(user);
                uow.Commit();
            }
        }

        public void Del(int[] ids)
        {
            if (ids.Length == 0)
            {
                throw new Exception("id为空.");
            }
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
               for (int i=0;i<ids .Length ;i++)
                {
                IClientInfo user =_bar .CreateEntityByKey (ids[i]);
                _bar.Remove(user);
                }
                uow.Commit();
            }
        }

        public void Edit(int id, string number, string name, string contact, string mail, string phone, string address, int userid, string site)
        {
            ICollection <IClientInfo > clients=_bar.GetByNameAndId(number, name);
            if (clients.Count > 0)
            {
                if(clients .FirstOrDefault ().Id !=id) 
                    throw new Exception("无法修改，该客户名称和编号已存在!");
            }
            using (IUnitOfWork uow = IoC.Resolve<IUnitOfWork>("cat"))
            {
                IClientInfo client = _bar.GetById(id);
                client.Number = number;
                client.Name = name;
                client.Contact = contact;
                client.Mail = mail;
                client.Phone = phone;
                client.Address = address;
                client.Site = site;
                uow.Commit();
            }
        }
    }
}
