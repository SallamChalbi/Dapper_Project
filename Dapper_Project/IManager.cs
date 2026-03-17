using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Project
{
    public interface IManager<T>
    {
        List<T> GetAll();
        T? GetById(int id);
        bool Add(T item);
        bool Update(T item);
        bool Delete(int id);
    }
}
