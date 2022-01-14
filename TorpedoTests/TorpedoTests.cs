using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var firstTarget = new Field(5, 3);
            aiPlayer.NextTarget = firstTarget;
            var expected = new Field(firstTarget.X - 1, firstTarget.Y);

            // Act
            aiPlayer.Update(firstTarget, true);
            var actual = aiPlayer.Shoot();

            // Assert
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void Shoot_WithOneMissOneHit_LowerField()
        {
            // Arrange
            var aiPlayer = new AIPlayer();
            var firstTarget = new Field(5, 3);
            aiPlayer.NextTarget = firstTarget;
            // First shoot hits
            aiPlayer.Update(firstTarget, true);
            var secondTarget = aiPlayer.Shoot();
            // Second shoot misses
            aiPlayer.Update(secondTarget, false);
            var expected = new Field(firstTarget.X + 1, firstTarget.Y);

            // Act
            var actual = aiPlayer.Shoot();

            // Assert
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void Shoot_WithTwoMissOneHit_LeftField()
        {
            // Arrange
            var aiPlayer = new AIPlayer();
            var firstTarget = new Field(5, 3);
            aiPlayer.NextTarget = firstTarget;
            // First shoot hits
            aiPlayer.Update(firstTarget, true);
            var secondTarget = aiPlayer.Shoot();
            // Second shoot misses
            aiPlayer.Update(secondTarget, false);
            var thirdTarget = aiPlayer.Shoot();
            // Third shoot misses
            aiPlayer.Update(thirdTarget, false);
            var expected = new Field(firstTarget.X, firstTarget.Y - 1);

            // Act
            var actual = aiPlayer.Shoot();

            // Assert
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void Shoot_WithThreeMissOneHit_RightField()
        {
            // Arrange
            var aiPlayer = new AIPlayer();
            var firstTarget = new Field(5, 3);
            aiPlayer.NextTarget = firstTarget;
            // First shoot hits
            aiPlayer.Update(firstTarget, true);
            var secondTarget = aiPlayer.Shoot();
            // Second shoot misses
            aiPlayer.Update(secondTarget, false);
            var thirdTarget = aiPlayer.Shoot();
            // Third shoot misses
            aiPlayer.Update(thirdTarget, false);
            var forthTarget = aiPlayer.Shoot();
            // Forth shoot misses
            aiPlayer.Update(forthTarget, false);
            var expected = new Field(firstTarget.X, firstTarget.Y + 1);

            // Act
            var actual = aiPlayer.Shoot();

            // Assert
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void Shoot_WithBorderField_ValidField()
        {
            // Arrange
            var aiPlayer = new AIPlayer();
            var firstTarget = new Field(0, 3);
            aiPlayer.NextTarget = firstTarget;
            aiPlayer.Update(firstTarget, true);
            var expected = new Field(firstTarget.X + 1, firstTarget.Y);

            // Act
            var actual = aiPlayer.Shoot();

            // Assert
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }
    }
}
