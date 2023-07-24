using EquationsFromSp;
using EquationsFromSp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationsFromSpTests
{
    public class EquationsFromSp468Tests
    {
        IEquationsFromSp468 equations;
        public EquationsFromSp468Tests()
        {
            equations = new EquationsFromSp468();
        }

        [Fact]
        public void GetRbWithGammaBt()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.Equal("Hello world!", result?.ViewData["Message"]);
        }
    }
}
