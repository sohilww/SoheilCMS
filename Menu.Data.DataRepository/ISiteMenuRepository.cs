using System.Collections.Generic;
using FrameWork.Application;
using Menu.DomainModel;
using FrameWork.Domain.Model;

namespace Menu.Data.DataRepository
{
    public interface ISiteMenuRepository:IRepository
    {
        SiteMenu Get(int id);
        int GetNextId();

        EntityAction Create(SiteMenu entity);

        EntityAction Update(SiteMenu entity);

        EntityAction Delete(int id);

        int Count();

        List<SiteMenu> SelectAllParentSiteMenu();
        List<SiteMenu> SelectAllChildOfParentSiteMenu(int parentId);
    }
}