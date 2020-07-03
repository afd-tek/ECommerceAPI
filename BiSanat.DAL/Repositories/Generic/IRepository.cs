using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BiSanat.DAL.Repositories.Generic
{
    public interface IRepository<T> where T : class,new()
    {
        T Add(T entity);

        T Update(T entity);

        IList<T> GetList(Expression<Func<T, bool>> filter = null);

        T GetById(int id);

        bool Delete(int id);
    }
}
