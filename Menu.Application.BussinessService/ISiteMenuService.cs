using System;
using System.Collections.Generic;
using Menu.DomainModel;
using FrameWork.Application;
using FrameWork.Core;

namespace Menu.Application.BussinessService
{
    public interface ISiteMenuService:IService
    {
        SiteMenu Get(int id);
        EntityAction Create(SiteMenu entity);

        EntityAction Update(SiteMenu entity);

        EntityAction Delete(int id);

        

        List<SiteMenu> SelectParentMenu();


        List<SiteMenu> SelectChildMenuOfParent(int Parentid);

        int Count();

        List<SiteMenu> Select();
    }
}