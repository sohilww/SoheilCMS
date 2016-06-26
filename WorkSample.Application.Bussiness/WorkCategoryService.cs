using System.Collections.Generic;
using System.Linq;
using FrameWork.Application;
using WorkSample.Application.BussinessService;
using WorkSample.Contracts;
using WorkSamples.Data.DataRepository;
using WorkSamples.DomainModel;

namespace WorkSample.Application.Bussiness
{
    public class WorkCategoryService : IWorkCategoryService
    {
        IWorkCategoryRepository rep;



        public WorkCategoryService(IWorkCategoryRepository _rep)
        {
            rep = _rep;
        }
        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public WorkCategoryModel Get(int id)
        {
            var model= rep.Get(id);
            if (model != null)
            {
                WorkCategoryModel result = new WorkCategoryModel(model);
                return result;
            }
            return null;
        }

        public EntityAction Create(WorkCategoryModel entity)
        {

            //entity.Id = rep.GetNextId();
            var model = entity.ToWorkCategory();
            model.Id = rep.GetNextId();
            EntityAction result = rep.Create(model);
            return result;
        }

        public EntityAction Update(WorkCategoryModel entity)
        {
            var category = rep.Get(entity.Id);
            var model = entity.ToWorkCategory(category);
            EntityAction result = rep.Update(model);
            return result;
        }

        public EntityAction Delete(int id)
        {
            EntityAction result = rep.Delete(id);
            return result;
        }



        public int Count()
        {
            return rep.Count();
        }

        public List<WorkCategoryModel> Select()
        {
            var model = rep.Select().Select(a => new WorkCategoryModel()
            {
                CategoryImage = a.CategoryImage,
                Description = a.Description,
                KeyWord = a.KeyWord,
                Id = a.Id,
                ParentName = (a.ParentId.HasValue) ? a.Parent.Title : "هیچکدام",
                Title = a.Title,
                Slug = a.Slug,
                ParentId = a.ParentId
            }).ToList();
            return model;
        }

        public List<SelectList> SelectIdAndName()
        {
            var model = rep.SelectIdAndName();
            return model;
        }

        public List<WorkCategoryBaseDTO> GetBaseCategory(int take)
        {
            var model = rep.GetBaseCategory(take);
            return model;
        }
    }
}