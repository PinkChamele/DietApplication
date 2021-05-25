using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DAL
{
    public interface IDAO<T> where T : IBase
    {
        int Create(T t);

        void Update(T t);

        T Get(int id);

        void Delete(int id);

        IDictionary<int, T> GetAll();
    }
}
