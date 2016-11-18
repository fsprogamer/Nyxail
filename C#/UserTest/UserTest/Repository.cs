using System;
using System.Linq;
using System.Data;

namespace UserTest
{
    class Repository
    {
        static readonly object Locker = new object();

        AppDBContext db;
        public Repository(AppDBContext conn)
        {
            db = conn;
        }
        //Get specific item in the database method with Id
        public T GetItem<T>(int userid) where T : class, IEntity 
        {
            lock (Locker)
            {
                IQueryable<T> dbQuery = db.Set<T>();
                try
                {
                    return dbQuery.FirstOrDefault(x => x.UserID == userid);
                }
                catch (Exception e)
                {
                    return default(T);
                }
            }
        }
        //Get all items in the database method
        public T[] GetItems<T>() where T : class, IEntity 
        {
            lock (Locker)
            {
                IQueryable<T> dbQuery = db.Set<T>();
                try
                {
                    return dbQuery.OrderBy(p => p.UserID).ToArray();
                }
                catch (Exception e)
                {                    
                    return null;
                }
            }
        }

        public void AddItem<T>(T item) where T : class, IEntity
        {
            lock (Locker)
            {                
                try
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    
                }
            }
        }

    }
}
