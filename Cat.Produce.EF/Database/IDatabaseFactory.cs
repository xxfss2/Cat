using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Produce.EF
{
    public interface IDatabaseFactory:IDisposable
    {
        IDatabase Create();
    }
}
