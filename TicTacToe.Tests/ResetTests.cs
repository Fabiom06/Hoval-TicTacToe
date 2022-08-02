using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Tests
{
    public class ResetTests
    {
        private const int _boardSize = 3;
        private TicTacToeGame _game;

        [SetUp]
        public void Setup()
        {
            _game = new TicTacToeGame(_boardSize);
        }

        [Test]
        public void ResetTest()
        {
            PlayXTest();
            _game.Reset();
            PlayYTest();
        }

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

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.XWon));
        }

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

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
            }
            Assert.That(_game.GetWinner(), Is.EqualTo(TicTacToeResult.YWon));
        }
    }
}
