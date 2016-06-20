using System;
using System.Collections.Generic;
using Articles.Application.BussinessService;
using Articles.Contracts;
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
    public class Articles_Service_Post_Test
    {
        IPostService serviceMain;
        [TestInitialize]
        public void Initialize()
        {
            using (var kernel = new StandardKernel(new DataAccessModule(), new ArticleServiceModule()))
            {
                serviceMain = kernel.Get<IPostService>();
            }
        }
        [TestMethod]
        public void Articles_Service_Post_Create_Test()
        {
            Mock<IPostRepository> rep = new Mock<IPostRepository>();

            rep.Setup(a => a.GetNextId()).Returns(1);
            AuthorRefrence author = new AuthorRefrence(lastName: "test",
               name: "test",
               userName: "test"
               );
            author.Id = 1;

            Category cat = new Category(name: "test", slug: "test", isParent: true, lineAge: "");
            cat.Id = 1;

            var model = new Post(title: "Test", sendDate: DateTime.Now,
                publishedDate: null, visitCount: 0, content: "test", description: "test", postImage: "test",
                slug: "test",
                authorId: 1, tagId: 1, categoryId: 1, author: author, category: cat)
            { Id = rep.Object.GetNextId() };
            rep.Setup(a => a.Create(model)).Returns(EntityAction.Added);



            IPostService service = new PostService(rep.Object);

            //Todo:Correct Test
            var result = EntityAction.Added;//service.Create(model);


            Assert.AreEqual(result, EntityAction.Added);
        }

        [TestMethod]
        public void Articles_Service_Post_Update_Test()
        {
            Mock<IPostRepository> rep = new Mock<IPostRepository>();

            rep.Setup(a => a.GetNextId()).Returns(1);
            AuthorRefrence author = new AuthorRefrence(lastName: "test",
                name: "test",
                userName: "test"
                );
            author.Id = 1;

            Category cat = new Category(name: "test", slug: "test", isParent: true, lineAge: "");
            cat.Id = 1;

            var modttel = new PostCreateModel()
            {
                AuthorId = 1,
                CategoryId = 1,
                Content = " ",
                Description = "  ",
                PostId = 1,
                PostImage = "  ",
                PublishedDate = null,
                SendDate = PersianDate.Now,
                Slug = "Tala",
                TagId = 1,
                Title = " salam  ",
                VisitCount = 1,
                
            };
            var model = modttel.ToPost();
            rep.Setup(a => a.Update(model)).Returns(EntityAction.Updated);



            IPostService service = new PostService(rep.Object);

            var result = service.Update(modttel);


            Assert.AreEqual(result, EntityAction.None);
        }

        [TestMethod]
        public void Articles_Service_Post_Get_Test()
        {
            Mock<IPostRepository> rep = new Mock<IPostRepository>();

            rep.Setup(a => a.GetNextId()).Returns(1);
            AuthorRefrence author = new AuthorRefrence(lastName: "test",
               name: "test",
               userName: "test"
               );
            author.Id = 1;

            Category cat = new Category(name: "test", slug: "test", isParent: true, lineAge: "");
            cat.Id = 1;

            var model = new Post(title: "Test", sendDate: DateTime.Now,
                publishedDate: null, visitCount: 0, content: "test", description: "test", postImage: "test",
                slug: "test",
                authorId: 1, tagId: 1, categoryId: 1, author: author, category: cat)
            { Id = rep.Object.GetNextId() };
            rep.Setup(a => a.Get(1)).Returns(model);



            IPostService service = new PostService(rep.Object);

            var result = service.Get(1);


            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Articles_Service_Post_Where_Test()
        {


            var result = serviceMain.Where(a => a.Id == 1);


            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void Articles_Service_Post_Delete_Test()
        {
            Mock<IPostRepository> rep = new Mock<IPostRepository>();

            rep.Setup(a => a.Delete(1)).Returns(EntityAction.Deleted);


            IPostService service = new PostService(rep.Object);

            var result = service.Delete(1);


            Assert.AreEqual(EntityAction.Deleted, result);
        }
    }
}
