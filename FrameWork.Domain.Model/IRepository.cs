using System;
using System.Collections.Generic;
using FrameWork.Application;

namespace FrameWork.Domain.Model
{
    public interface IRepository
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

        EntityAction Delete(T entity);

        IEnumerable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
    }
}