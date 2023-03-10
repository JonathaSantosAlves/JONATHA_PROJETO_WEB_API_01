using Microsoft.AspNetCore.Mvc;
using Moq;
using JONATHA_PROJETO_WEB_API_01.Controllers;
using JONATHA_PROJETO_WEB_API_01_DOMAIN;
using JONATHA_PROJETO_WEB_API_01_REPOSITORY.Interface;
using System.Text;
using Xunit;

namespace JONATHA_PROJETO_WEB_API_01.Tests
{
    public class DiffControllerTests : Controller
    {
        private readonly DiffController _controller;

        public DiffControllerTests()
        {         
            var leftValueMock = new Mock<ILeftValue>();
            var rightValueMock = new Mock<IRightValue>();
            var getValueMock = new Mock<IGetValue>();
           
            _controller = new DiffController(leftValueMock.Object, rightValueMock.Object, getValueMock.Object);
        }


        [Fact]
        public void Left_Should_Return_Ok()
        {
            var id = 1;
            var base64Data = Convert.ToBase64String(Encoding.UTF8.GetBytes("data"));

            var result = _controller.Left(id, base64Data) as OkResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Right_Should_Return_Ok()
        {
            var id = 1;
            var base64Data = Convert.ToBase64String(Encoding.UTF8.GetBytes("data"));

            var result = _controller.Right(id, base64Data) as OkResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Get_Invalid_Id_Should_Return_NotFound()
        {
            var id = 1;
            var getValueMock = new Mock<IGetValue>();
            getValueMock.Setup(g => g.VerifyValueID(id, It.IsAny<Dictionary<int, DiffData>>())).Returns(false);

            var controller = new DiffController(null, null, getValueMock.Object);

            var result = controller.Get(id) as NotFoundObjectResult;

            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }
    }
}
