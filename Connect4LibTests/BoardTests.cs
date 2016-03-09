using Connect4Lib;
using NUnit.Framework;

namespace Connect4LibTests
{
    [TestFixture]
    public sealed class BoardTests
    {
        [Test]
        public void Can_play_one()
        {
            var board = new Board();
            board.Play(0);
            Assert.IsTrue(board.Pos(0, 6));
            Assert.IsFalse(board.Pos(0, 5));
        }

        [Test]
        public void Can_play_two()
        {
            var board = new Board();
            board.Play(2);
            board.Play(2);
            Assert.IsTrue(board.Pos(2, 6));
            Assert.IsTrue(board.Pos(2, 5));
        }

        [Test]
        public void When_fill_column_cant_go_there()
        {
            var board = new Board();
            for (int i = 0; i < 7; i++)
                Assert.IsTrue(board.Play(3));
            Assert.IsFalse(board.Play(3));
        }

    }
}
