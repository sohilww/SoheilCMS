using System;
using Articles.Data.DataRepository;
using Articles.DomainModel;
using Articles.IOC.Bootstraper;
using FrameWork.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Linq;
namespace Articles.Data.TestDataAccess
{
    [TestClass]
    public class Articles_Data_Post_Test
    {

        IArticlesUnitofWork uni;
        IPostRepository rep;
        [TestInitialize]
        public void Initialize()
        {
            using (var kernel = new StandardKernel(new DataAccessModule()))
            {
                uni = kernel.Get<IArticlesUnitofWork>();

                rep = kernel.Get<IPostRepository>();
            }

        }

        [TestMethod]
        public void Articles_Data_Post_NextId_Test()
        {
            var value = rep.GetNextId();

            bool isbigthenZero = value > 0;


            Assert.IsNotNull(value);
            Assert.IsTrue(isbigthenZero);



        }

        [TestMethod]
        public void Articles_Data_Post_Insert_Test()
        {
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
                authorId: 1, tagId: 1, categoryId: 1, author: author, category: cat) {Id = rep.GetNextId()};
            uni.BeginTransAction();

            EntityAction result = rep.Create(model);
            Assert.AreEqual(result, EntityAction.Added);
            uni.RollBack();

        }
        [TestMethod]
        public void Articles_Data_Post_Get_Test()
        {

            var result = rep.Get(1);
            Assert.IsNull(result);


        }
        [TestMethod]
        public void Articles_Data_Post_where_Test()
        {

            var result = rep.Where(a => a.Id == 1).ToList();
            Assert.IsTrue(!result.Any());


        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Articles_Data_Post_Delete_Test()
        {

            var result = rep.Delete(1);
            Assert.AreEqual(result, EntityAction.Exception);


        }
    }
}
