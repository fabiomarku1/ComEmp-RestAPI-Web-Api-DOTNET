using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _repositoryContext;

        public RepositoryBase(RepositoryContext context)
        {
            _repositoryContext = context;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
                _repositoryContext.Set<T>()
                    .AsNoTracking() :
                _repositoryContext.Set<T>();

        public T FindById(int id, bool trackChanges)
        {
         var element=  _repositoryContext.Set<T>().Find(id);
         return element;
        }

            public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);

            public void Update(T entity)=> _repositoryContext.Set<T>().Update(entity);

            public void Delete(T entity)=> _repositoryContext.Set<T>().Remove(entity);

        }
}
