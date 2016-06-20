using System;
using System.Collections.Generic;
using System.Linq;
using FrameWork.Application;
using Menu.Data.DataRepository;
using Menu.DomainModel;

namespace Menu.Data.DataAccess
{
    public class SiteMenuRepository:ISiteMenuRepository
    {
        
        private readonly IMenuUnitofWork unit;
        
        public SiteMenuRepository(IMenuUnitofWork _unit)
        {
            
            this.unit = _unit;
        }

        public SiteMenu Get(int id)
        {
            var model = unit.Context.Menus.FirstOrDefault(a => a.Id == id);

            return model;

        }

        public int GetNextId()
        {
            var query = "dbo." + "SiteMenuSEQUENCE";
            int result = unit.Context
                .Database.SqlQuery<int>("SELECT NEXT VALUE FOR  " + query + ";").SingleOrDefault();
            return result;
        }

        public EntityAction Create(SiteMenu entity)
        {
            unit.Context.Menus.Add(entity);

            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Added;
            return EntityAction.Exception;
        }

        public EntityAction Update(SiteMenu entity)
        {
            unit.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Updated;
            return EntityAction.Exception;

        }

        public EntityAction Delete(int id)
        {
            unit.Context.Menus.Remove(Get(id));
            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Deleted;
            return EntityAction.Exception;


        }

        

        public int Count()
        {
            return unit.Context.Menus.Count();
        }

        public List<SiteMenu> SelectAllParentSiteMenu()
        {
            var model = unit.Context.Menus.Where(a => a.ParentId == null).ToList();
            return model;
        }

        public List<SiteMenu> SelectAllChildOfParentSiteMenu(int parentId)
        {
            var model = unit.Context.Menus.Where(a => a.ParentId == parentId).ToList();
            return model;
        }

        public List<SiteMenu> Select()
        {
            var model = unit.Context.Menus.ToList();
            return model;
        }


        public void Dispose()
        {
            //if (rep != null)
            //    rep.Dispose();
            //if (unit != null)
            //    unit.Dispose();
        }
    }

}