using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface ICRUD<T>
    {
        T Create(T model);
        T GetById(int id);
        T Update(int id, T model);
        T Delete(int id);

    }
}
