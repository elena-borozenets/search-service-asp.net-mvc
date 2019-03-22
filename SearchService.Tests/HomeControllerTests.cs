
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SearchService.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<IRecordFacade<Record>>();
            mock.Setup(a => a.List()).Returns(new List<Record>()
            {
                new Record()
                {
                    Id=0,
                    Title = "title",
                    Link = "http/fvd",
                    Snippet = "fdgdbhdf dfbvdf"
                },
                new Record()
                {
                    Id=1,
                    Title = "title2",
                    Link = "http/fvd2",
                    Snippet = "sdfvdfkj dfkvkl"
                }
            });
            HomeController controller = new HomeController(mock.Object);

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
