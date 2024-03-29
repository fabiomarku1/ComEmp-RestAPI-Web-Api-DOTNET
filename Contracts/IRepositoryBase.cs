﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        T FindById (int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
