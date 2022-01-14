using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Torpedo.Model;

namespace TorpedoTests
{
    [TestClass]
    public class TorpedoTests
    {
        [TestMethod]
        public void Shoot_WithOneHit_UpperField()
        {
            // Arrange
            var aiPlayer = new AIPlayer();
            var field = aiPlayer.Shoot();
            var expected = new Field(field.X - 1, field.Y);

            // Act
            aiPlayer.Update(field, true);
            var actual = aiPlayer.Shoot();

            // Assert
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }
    }
}
