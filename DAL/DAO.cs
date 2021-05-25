using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DAO<T> : IDAO<T> where T : IBase
    {
        public static int Id { get; set; }
        public static IDictionary<int, T> data;

        public DAO()
        {
            if (data == null)
            {
                data = new Dictionary<int, T>();
            }
        }
        public int Create(T t)
        {
            t.Id = ++Id;
            data.Add(t.Id, t);
            return t.Id;
        }

        public void Delete(int id)
        {
            data.Remove(id);
        }

        public T Get(int id)
        {
            return data[id];
        }

        public void Update(T t)
        {
            data[t.Id] = t;
        }

        public IDictionary<int, T> GetAll()
        {
            return data;
        }
    }
}
