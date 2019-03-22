using SearchService.Facade.IFacades;
using SearchService.Models;
using SearchService.Controllers;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using XAssert = Xunit.Assert;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SearchService.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index_ReturnsAViewResult_IsNotNull()
        {
            //Arrange
            var mock = new Mock<IRecordFacade>();
            mock.Setup(a => a.GetAll()).Returns(new List<Record>()
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

        [TestMethod]
        public void Index_ReturnsAViewResult_WithAListOfRecordModel()
        {
            //Arrange
            var mock = new Mock<IRecordFacade>();
            mock.Setup(a => a.GetAll()).Returns(new List<Record>()
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

            //Asser
            var viewResult = XAssert.IsType<ViewResult>(result);
            var model = XAssert.IsAssignableFrom<IEnumerable<Record>>(
                viewResult.ViewData.Model);
            XAssert.Equal(2, model.Count());
        }

        [TestMethod]
        public void SearchInDb_ReturnsIdInFirstElement_Equals0()
        {
            //Arrange
            var mock = new Mock<IRecordFacade>();
            mock.Setup(a => a.GetAll()).Returns(new List<Record>()
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

            //Asser
            var viewResult = XAssert.IsType<ViewResult>(result);
            var model = XAssert.IsAssignableFrom<IEnumerable<Record>>(
                viewResult.ViewData.Model);
            XAssert.Equal(0, model.First().Id);
        }
    }
}
