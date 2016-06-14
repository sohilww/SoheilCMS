using System;
using System.Collections.Generic;
using Articles.Application.BussinessService;
using Articles.Data.DataRepository;
using Articles.DomainModel;
using Articles.IOC.Bootstraper;
using FrameWork.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;

namespace Articles.Application.Bussiness.Test
{
    [TestClass]
    public class Articles_Service_Tag_Test
    {
        ITagService serviceMain;
        [TestInitialize]
        public void Initialize()
        {
            using (var kernel = new StandardKernel(new DataAccessModule(), new ArticleServiceModule()))
            {
                serviceMain = kernel.Get<ITagService>();
            }
        }


        [TestMethod]
        public void Articles_Service_Tag_Create_Test()
        {
            Mock<ITagRepository> rep = new Mock<ITagRepository>();

            rep.Setup(a => a.GetNextId()).Returns(1);


            Tag model = new Tag("Test");
            model.Id = rep.Object.GetNextId();

           
            rep.Setup(a => a.Create(model)).Returns(EntityAction.Added);



            ITagService service = new TagService(rep.Object);

            var result = service.Create(model);


            Assert.AreEqual(result, EntityAction.Added);
        }
        [TestMethod]
        public void Articles_Service_Tag_Update_Test()
        {
            Mock<ITagRepository> rep = new Mock<ITagRepository>();



            Tag model = new Tag("Test");
            model.Id = rep.Object.GetNextId();
            rep.Setup(a => a.Update(model)).Returns(EntityAction.Updated);



            ITagService service = new TagService(rep.Object);

            var result = service.Update(model);


            Assert.AreEqual(result, EntityAction.Updated);
        }

        [TestMethod]
        public void Articles_Service_Tag_Get_Test()
        {
            Mock<ITagRepository> rep = new Mock<ITagRepository>();

            rep.Setup(a => a.GetNextId()).Returns(1);


            Tag model = new Tag("Test");
            model.Id = rep.Object.GetNextId();
            rep.Setup(a => a.Get(1)).Returns(model);



            ITagService service = new TagService(rep.Object);

            var result = service.Get(1);


            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Articles_Service_Tag_Where_Test()
        {
          

            var result = serviceMain.Where(a => a.Id == 1);


            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void Articles_Service_Tag_Delete_Test()
        {
            Mock<ITagRepository> rep = new Mock<ITagRepository>();

            rep.Setup(a => a.Delete(1)).Returns(EntityAction.Deleted);
      
      
            ITagService service = new TagService(rep.Object);

            var result =service.Delete(1);


            Assert.AreEqual(EntityAction.Deleted, result);
        }
    }
}
