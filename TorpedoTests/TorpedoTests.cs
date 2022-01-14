using Microsoft.VisualStudio.TestTools.UnitTesting;
using Torpedo.Model;

namespace TorpedoTests
{
    [TestClass]
    public class TorpedoTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var aiPlayer = new AIPlayer();
            var field = new Field(5, 3);
            var expected = new Field(field.X, field.Y - 1);

            // Act
            aiPlayer.Shoot();
            aiPlayer.Update(field, true);
            var actual = aiPlayer.Shoot();

            // Assert
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }
    }
}
