using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Domain.Model
{
    public class BaseDbContext<TContext> : DbContext where TContext:DbContext
    {

        static BaseDbContext()
        {
            Database.SetInitializer<TContext>(null);
        }
        protected BaseDbContext()
            :base(nameOrConnectionString: "Data Source=.;Initial Catalog=CMSDataBase;Integrated Security=True;MultipleActiveResultSets=True")
        {
            
        }
    }
}
