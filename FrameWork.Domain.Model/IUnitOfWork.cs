using System;
using System.Data.Entity;
using FrameWork.Application;

namespace FrameWork.Domain.Model
{
    public interface IUnitOfWork<TContext>:IDisposable where TContext:DbContext
    {
        EntityAction SaveChanges();

        TContext Context { get; set; }

        void BeginTransAction();

        void Commit();

        void RollBack();


    }

    
}