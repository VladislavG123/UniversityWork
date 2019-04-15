using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.DataAccess
{
    public interface IService<T>
    {
        List<T> Select();
        bool Insert(T item);
        bool Update(int oldItemId, T newItem);
        bool Delete(int itemId);
    }
}
