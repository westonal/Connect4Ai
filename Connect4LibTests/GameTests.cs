using Connect4Lib;
using NUnit.Framework;

namespace Connect4LibTests
{
    [TestFixture]
    public sealed class GameTests
    {
        [Test]
        public void Row_for_column()
        {
            var game = new Game();
            Assert.AreEqual(6, game.RowForColumn(0));
            Assert.IsTrue(game.Play(0));
            Assert.AreEqual(5, game.RowForColumn(0));
            Assert.IsTrue(game.Play(0));
            Assert.AreEqual(4, game.RowForColumn(0));
            Assert.IsTrue(game.Play(0));
            Assert.AreEqual(3, game.RowForColumn(0));
            Assert.IsTrue(game.Play(0));
            Assert.AreEqual(2, game.RowForColumn(0));
            Assert.IsTrue(game.Play(0));
            Assert.AreEqual(1, game.RowForColumn(0));
            Assert.IsTrue(game.Play(0));
            Assert.AreEqual(0, game.RowForColumn(0));
            Assert.IsTrue(game.Play(0));
            Assert.AreEqual(-1, game.RowForColumn(0));
            Assert.IsFalse(game.Play(0));
            Assert.AreEqual(-1, game.RowForColumn(0));
        }
    }
}
