using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI
{
    public class BookingDb
    {
        private DbContext dbContext;

        public BookingDb(DbContext context)
        {
            this.dbContext = context;
        }

        public void Create<T>(T entity) where T : class
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        public T Read<T>(object id) where T : class
        {
            return dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> ReadAll<T>() where T : class
        {
            return dbContext.Set<T>();
        }

        public void Update<T>(T entity) where T : class
        {
            dbContext.Set<T>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Delete<T>(object id) where T : class
        {
            T obj = dbContext.Set<T>().Find(id);

            if (obj != null)
            {
                dbContext.Entry(obj).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }
    }
}
