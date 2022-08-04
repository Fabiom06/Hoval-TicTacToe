namespace TicTacToe.Tests
{
    public class FourByFour
    {
        private const int _boardSize = 4;
        private TicTacToeGame _game;

        [SetUp]
        public void Setup()
        {
            _game = new TicTacToeGame(_boardSize);
        }

        [Test]
        public void PlayXNormalTest()
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

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        
        [Test]
        public void PlayXOffsetTest()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(1, 0),
                // O
                Tuple.Create(2, 0),
                // X
                Tuple.Create(1, 1),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(1, 2),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }

        [Test]
        public void PlayXNormalDiagonalTest()
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

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }

        [Test]
        public void PlayXOffsetDiagonalTest()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(1, 1),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(2, 2),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(3, 3),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

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

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }

        [Test]
        public void PlayXOffsetDiagonalMirroredTest()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(1, 3),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(2, 2),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(3, 1),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }

        [Test]
        public void PlayYNormalTest()
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

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.YWon));
        }

        [Test]
        public void PlayYOffsetTest()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(0, 0),
                // O
                Tuple.Create(2, 0),
                // X
                Tuple.Create(0, 1),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(1, 1),
                // O
                Tuple.Create(2, 2)
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.YWon));
        }

        [Test]
        public void PlayYNormalDiagonalTest()
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

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.YWon));
        }

        [Test]
        public void PlayYOffsetDiagonalTest()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(1, 0),
                // O
                Tuple.Create(1, 1),
                // X
                Tuple.Create(0, 1),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(0, 2),
                // O
                Tuple.Create(3, 3)
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.YWon));
        }

        [Test]
        public void PlayYNormalDiagonalMirroredTest()
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

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.YWon));
        }

        [Test]
        public void PlayYOffsetDiagonalMirroredTest()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(1, 0),
                // O
                Tuple.Create(3, 1),
                // X
                Tuple.Create(0, 1),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(1, 2),
                // O
                Tuple.Create(1, 3)
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.YWon));
        }

        //[Test]
        //public void PlayTieTest()
        //{
        //    var valuePairs = new List<Tuple<int, int>>
        //    {
        //        // X
        //        Tuple.Create(0, 0),
        //        // O
        //        Tuple.Create(2, 2),
        //        // X
        //        Tuple.Create(1, 2),
        //        // O
        //        Tuple.Create(0, 1),
        //        // X
        //        Tuple.Create(0, 2),
        //        // O
        //        Tuple.Create(1, 1),
        //        // X
        //        Tuple.Create(2, 1),
        //        // O
        //        Tuple.Create(2, 0),
        //        // X
        //        Tuple.Create(1, 0),
        //    };

        //    foreach (var pair in valuePairs)
        //    {
        //        Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));

        //        // Do not check last item as this result in tie already
        //        if (pair.Item1 != 1 && pair.Item1 != 0)
        //        {
        //            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.None));
        //        }
        //    }

        //    for (int i = 0; i < _boardSize; i++)
        //    {
        //        for (int j = 0; j < _boardSize; j++)
        //        {
        //            Assert.That(_game.SetXYValue(i, j), Is.EqualTo(TicTacToeSetResult.AlreadyPlaced));
        //        }
        //    }

        //    Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.Tie));
        //}
    }
}
