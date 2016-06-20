using System;
using System.Data.Entity;
using FrameWork.Domain.Model;


namespace Menu.DomainModel
{
    public class MenuDbContext:BaseDbContext<MenuDbContext>
    {
        public DbSet<SiteMenu> Menus { get; set; }


        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new SiteMenuMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
