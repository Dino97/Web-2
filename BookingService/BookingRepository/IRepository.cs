using System;
using System.Collections.Generic;
using System.Text;

namespace BookingRepository
{
    interface IRepository<T> where T : class
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(object id);

        T Read(object id);
        List<T> ReadAll();
    }
}
