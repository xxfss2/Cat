using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xxf.Core
{
    public interface IUserCore
    {
        int Id { get;  }
        string Name { get;  }
        string LoginName { get; }
        string PassWord { get;  }
    }
}
