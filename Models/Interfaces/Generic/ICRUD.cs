using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface ICRUD<T>
    {
        T Create(T model);
        T GetById(string id);
        T Update(string id, T model);
        T Delete(string id);
        List<T> GetAll();

    }
}
