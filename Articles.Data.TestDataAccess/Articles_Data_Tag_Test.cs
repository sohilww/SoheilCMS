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
    public class Articles_Data_Tag_Test
    {

        IArticlesUnitofWork uni;
        ITagRepository rep;
        [TestInitialize]
        public void Initialize()
        {
            using (var kernel=new StandardKernel(new DataAccessModule()))
            {
                uni = kernel.Get<IArticlesUnitofWork>();

                rep = kernel.Get<ITagRepository>();
            }
            
        }

        [TestMethod]
        public void Articles_Data_Tag_NextId_Test()
        {
            var value = rep.GetNextId();

            bool isbigthenZero = value > 0;


            Assert.IsNotNull(value);
            Assert.IsTrue(isbigthenZero);



        }

        [TestMethod]
        public void Articles_Data_Tag_Insert_Test()
        {
            var model = new Tag(name:"Test");
            model.Id = rep.GetNextId();
            uni.BeginTransAction();

            EntityAction result = rep.Create(model);
            Assert.AreEqual(result, EntityAction.Added);
            uni.RollBack();

        }
        [TestMethod]
        public void Articles_Data_Tag_Get_Test()
        {

            var result = rep.Get(1);
            Assert.IsNull(result);


        }
        [TestMethod]
        public void Articles_Data_Tag_where_Test()
        {

            var result = rep.Where(a => a.Id == 1).ToList();
            Assert.IsTrue(!result.Any());


        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Articles_Data_Tag_Delete_Test()
        {

            var result = rep.Delete(1);
            Assert.AreEqual(result,EntityAction.Exception);


        }
    }
}
