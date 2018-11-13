using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DoinikSokal.Identity.IdentityConfig;
using DoinikSokal.Model.Contracts;
using DoinikSokal.Repository.Contracts;
using DoinikSokal.BLL.Contracts;

namespace DoinikSokal.BLL.Base
{
    public class Manager<T>:IManager<T> where T:class
    {
        protected IRepository<T> BaseRepository;

        public Manager(IRepository<T> baseRepository)
        {
            BaseRepository = baseRepository;
        }

        public bool Add(T entity)
        {
            return BaseRepository.Add(entity);
        }

        public bool Update(T entity)
        {
            return BaseRepository.Update(entity);
        }

        public bool Remove(IDeletable entity)
        {
            bool isDeleted = entity is IDeletable;
            if (!isDeleted)
            {
                throw new Exception("This Item Is Not Deletable");
            }
            return BaseRepository.Remove(entity);
        }

        public bool Remove(ICollection<IDeletable> entities)
        {
            return BaseRepository.Remove(entities);
        }

        public ICollection<T> GetAll(bool withDeleted = false)
        {
            return BaseRepository.GetAll(withDeleted);
        }

        public ICollection<T> Get(Expression<Func<T, bool>> query)
        {
            return BaseRepository.Get(query);
        }

        public T GetById(int id)
        {
            return BaseRepository.GetById(id);
        }
    }
}
