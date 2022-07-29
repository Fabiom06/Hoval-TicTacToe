using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Tests
{
    public class PlayTests
    {
        private const int _boardSize = 3;
        private TicTacToeGame _game;

        [SetUp]
        public void Setup()
        {
            _game = new TicTacToeGame(_boardSize);
        }

        [Test]
        public void PlayXTest()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(0, 0),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(0, 1),
                // O
                Tuple.Create(1, 1),
                // X
                Tuple.Create(0, 2),
            };

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }

        [Test]
        public void PlayXDiagonalTest()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(0, 0),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(1, 1),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(2, 2),
            };

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }

        [Test]
        public void PlayXDiagonalMirroredTest()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(0, 2),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(1, 1),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(2, 0),
            };

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }

        [Test]
        public void PlayYTest()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(0, 0),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(0, 1),
                // O
                Tuple.Create(1, 1),
                // X
                Tuple.Create(2, 2),
                // O
                Tuple.Create(1, 2)
            };

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.YWon));
        }

        [Test]
        public void PlayYDiagonalTest()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(1, 0),
                // O
                Tuple.Create(0, 0),
                // X
                Tuple.Create(0, 1),
                // O
                Tuple.Create(1, 1),
                // X
                Tuple.Create(0, 2),
                // O
                Tuple.Create(2, 2)
            };

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.YWon));
        }

        [Test]
        public void PlayYDiagonalMirroredTest()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(1, 0),
                // O
                Tuple.Create(2, 0),
                // X
                Tuple.Create(0, 1),
                // O
                Tuple.Create(1, 1),
                // X
                Tuple.Create(1, 2),
                // O
                Tuple.Create(0, 2)
            };

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.YWon));
        }

        [Test]
        public void PlayTieTest()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(0, 0),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(1, 2),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(0, 2),
                // O
                Tuple.Create(1, 1),
                // X
                Tuple.Create(2, 1),
                // O
                Tuple.Create(2, 0),
                // X
                Tuple.Create(1, 0),
            };

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
                
                // Do not check last item as this result in tie already
                if (pair.Item1 != 1 && pair.Item1 != 0)
                {
                    Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.None));
                }
            }

            for (int i = 0; i < _boardSize; i++)
            {
                for(int j = 0; j < _boardSize; j++)
                {
                    Assert.That(_game.SetXYValue(i, j), Is.EqualTo(TicTacToeSetResult.AlreadyPlaced));
                }
            }

            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.Tie));
        }
    }
}
