using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.Generic
{
    public interface IFactory<T>
    {
        T Create();
    }
}
