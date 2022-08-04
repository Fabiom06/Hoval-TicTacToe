namespace TicTacToe.Tests
{
    public class FiveByFiveCompleteTest
    {
        private const int _boardSize = 5;
        private TicTacToeGame _game;

        [SetUp]
        public void Setup()
        {
            _game = new TicTacToeGame(_boardSize);
        }

        [Test]
        public void CenterToTopLeft()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(2, 2),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(1, 1),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(0, 0),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }

        [Test]
        public void CenterToTopRight()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(2, 2),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(1, 3),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(0, 4),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }

        [Test]
        public void CenterToBottomRight()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(2, 2),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(3, 3),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(4, 4),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void CenterToBottomLeft()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(2, 2),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(3, 1),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(4, 0),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }

        [Test]
        public void LeftCenterToTopCenter()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(2, 0),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(1, 1),
                // O
                Tuple.Create(2, 1),
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
        public void TopCenterToRightCenter()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(0, 2),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(1, 3),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(2, 4),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void RightCenterToBottomCenter()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(2, 4),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(3, 3),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(4, 2),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void BottomCenterToLeftCenter()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(4, 2),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(3, 1),
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
        public void TopCenterToLeftCenter()
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
        public void RightCenterToTopCenter()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(2, 4),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(1, 3),
                // O
                Tuple.Create(2, 1),
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
        public void BottomCenterToRightCenter()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(4, 2),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(3, 3),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(2, 4),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void LeftCenterToBottomCenter()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(2, 0),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(3, 1),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(4, 2),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void LeftMidBottomToRightMidTop()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(3, 1),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(2, 2),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(1, 3),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void LeftMidTopToRightMidBottom()
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
        public void RightMidBottomToLeftMidTop()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(3, 3),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(2, 2),
                // O
                Tuple.Create(2, 1),
                // X
                Tuple.Create(1, 1),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void RightMidTopToLeftMidBottom()
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
        public void OneZeroToThreeTwo()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(1, 0),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(2, 1),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(3, 2),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void ThreeTwoToOneZero()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(3, 2),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(2, 1),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(1, 0),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void TwoOneToFourThree()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(2, 1),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(3, 2),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(4, 3),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void FourThreeToTwoOne()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(4, 3),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(3, 2),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(2, 1),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void ZeroOneToTwoThree()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(0, 1),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(1, 2),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(2, 3),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void TwoThreeToZeroOne()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(2, 3),
                // O
                Tuple.Create(1, 0),
                // X
                Tuple.Create(1, 2),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(0, 1),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void OneTwoToThreeFour()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(1, 2),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(2, 3),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(3, 4),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void ThreeFourToOneTwo()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(3, 4),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(2, 3),
                // O
                Tuple.Create(2, 2),
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
        public void ThreeZeroToOneTwo()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(3, 0),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(2, 1),
                // O
                Tuple.Create(2, 2),
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
        public void OneTwoToThreeZero()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(1, 2),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(2, 1),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(3, 0),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void TwoOneToZeroThree()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(2, 1),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(1, 2),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(0, 3),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void ZeroThreeToTwoOne()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(0, 3),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(1, 2),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(2, 1),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void FourOneToTwoThree()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(4, 1),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(3, 2),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(2, 3),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void TwoThreeToFourOne()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(2, 3),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(3, 2),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(4, 1),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void ThreeTwoToOneFour()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(3, 2),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(2, 3),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(1, 4),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
        [Test]
        public void OneFourToThreeTwo()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                // X
                Tuple.Create(4, 1),
                // O
                Tuple.Create(0, 1),
                // X
                Tuple.Create(2, 3),
                // O
                Tuple.Create(2, 2),
                // X
                Tuple.Create(3, 2),
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }
    }
}
