using System;
using System.Collections.Generic;
using Articles.Application.BussinessService;
using Articles.Data.DataRepository;
using Articles.DomainModel;
using FrameWork.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Articles.Application.Bussiness.Test
{
    [TestClass]
    public class Articles_Service_Post_Test
    {
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

            var result = service.Create(model);


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

            var model = new Post(title: "Test", sendDate: DateTime.Now,
                publishedDate: null, visitCount: 0, content: "test", description: "test", postImage: "test",
                slug: "test",
                authorId: 1, tagId: 1, categoryId: 1, author: author, category: cat)
            { Id = rep.Object.GetNextId() };
            rep.Setup(a => a.Update(model)).Returns(EntityAction.Updated);



            IPostService service = new PostService(rep.Object);

            var result = service.Update(model);


            Assert.AreEqual(result, EntityAction.Updated);
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

            IList<Post> value = new List<Post>();
            value.Add(model);
                
                rep.Setup(a => a.Where(b=>b.Id==1)).Returns(value);



            IPostService service = new PostService(rep.Object);

            var result =(List<Post>) service.Where(a => a.Id == 1);


            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void Articles_Service_Post_Delete_Test()
        {
            Mock<IPostRepository> rep = new Mock<IPostRepository>();

            rep.Setup(a => a.Delete(1)).Returns(EntityAction.Deleted);
      
      
            IPostService service = new PostService(rep.Object);

            var result =service.Delete(1);


            Assert.AreEqual(EntityAction.Deleted, result);
        }
    }
}
