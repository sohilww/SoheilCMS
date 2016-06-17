using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FrameWork.Application;

namespace FrameWork.Domain.Model
{
    public interface IRepository:IDisposable
    {

    }

    /// <summary>
    /// I Put To This Class UpdateMethod For Update Rep
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<TKey, T> : IRepository where T : IAggregateRoot
    {
        /// <summary>
        /// Get Element From Context
        /// </summary>
        /// <param name="id">Id Of Element</param>
        /// <returns></returns>
        T Get(TKey id);
        TKey GetNextId();
        EntityAction Create(T entity);

        EntityAction Update(T entity);

        EntityAction Delete(TKey id);

        IQueryable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> predicate);


        IQueryable<T> SelectAll();

        IQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> predicate);

        int Count();

    }
}