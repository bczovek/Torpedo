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
            var field = new Field(5, 2);
            var expected = new Field(4, 2);

            // Act
            aiPlayer.Shoot();
            aiPlayer.Update(field, true);

            // Assert
            Assert.AreEqual(expected, aiPlayer.Shoot());
        }
    }
}
