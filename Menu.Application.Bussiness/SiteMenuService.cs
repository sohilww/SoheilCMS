using System;
using System.Collections.Generic;
using Menu.Application.BussinessService;
using Menu.Data.DataRepository;
using Menu.DomainModel;
using FrameWork.Application;

namespace Menu.Application.Bussiness
{
    public class SiteMenuService : ISiteMenuService
    {
        ISiteMenuRepository rep;

        public SiteMenuService(ISiteMenuRepository _rep)
        {
            rep = _rep;
        }
        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public SiteMenu Get(int id)
        {
            var result = rep.Get(id);
            return result;
        }

        public EntityAction Create(SiteMenu entity)
        {
            entity.Id = rep.GetNextId();
            EntityAction result = rep.Create(entity);
            return result;
        }

        public EntityAction Update(SiteMenu entity)
        {
            EntityAction result = rep.Update(entity);
            return result;
        }

        public EntityAction Delete(int id)
        {
            EntityAction result = rep.Delete(id);
            return result;
        }

      

        public List<SiteMenu> SelectParentMenu()
        {
            return rep.SelectAllParentSiteMenu();
        }

        public List<SiteMenu> SelectChildMenuOfParent(int parentId)
        {
            if (parentId == default(int))
                throw new NullReferenceException("ParentId Dose Not Exsits");
            var model = rep.SelectAllChildOfParentSiteMenu(parentId);

            return model;
        }


        public int Count()
        {
            return rep.Count();
        }
    }
}