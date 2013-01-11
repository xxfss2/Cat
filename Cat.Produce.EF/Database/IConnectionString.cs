using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Produce.EF
{
    public interface IConnectionString
    {
        string Value { get; }
        string ProviderName { get; }
    }
}
