using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Jiuzh.CoreBase.Infrastructure;
using System.Web;
namespace Cat.Produce.Infrastructure
{
    public class ProduceRegisterUCF : IBootstrapperTask
    {
        public void Execute()
        {
           string strPath = HttpContext.Current.Server.MapPath("~");

           bool b = IoC.RegisterUCF(strPath + "\\Config\\unity\\unity.di.Produce.infrastructure.config");
           if (b == false)
           {
               throw new Exception("read file error");
           }
        }
    }
}
