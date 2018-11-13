using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DoinikSokal.Models.DatabaseContext;
using DoinikSokal.Model.Contracts;
using DoinikSokal.Repository.Contracts;

namespace DoinikSokal.Repository.Base
{
    public class Repository <T>:IRepository<T> where T:class, IDeletable
    {
        protected DbContext db;

        public Repository(DbContext db)
        {
            this.db = db;
        }

        public bool Add(T entity)
        {
            db.Set<T>().Add(entity);
            return db.SaveChanges() > 0;
        }
        public bool Update(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool Remove(IDeletable entity)
        {
            entity.IsDeleted = true;
            return Update((T) entity);
        }

        public bool Remove(ICollection<IDeletable> entities)
        {
            int removeCount = 0;
            foreach (var item in entities)
            {
                var removeData = Remove(item);
                if (removeData)
                {
                    removeCount++;
                }
            }
            return entities.Count == removeCount;
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public ICollection<T> GetAll(bool withDeleted = false)
        {
            return db.Set<T>().Where(c=> c.IsDeleted == false || c.IsDeleted == withDeleted).ToList();
        }

        public ICollection<T> Get(Expression<Func<T, bool>> query)
        {
            return db.Set<T>().ToList();
        } 
    }
}
