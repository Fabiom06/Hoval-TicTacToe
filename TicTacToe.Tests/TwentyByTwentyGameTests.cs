namespace TicTacToe.Tests
{
    public class TwentyByTwentyGameTests
    {
        private const int _boardSize = 20;
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
                Tuple.Create(15, 15),
                // O
                Tuple.Create(16, 15),
                // X
                Tuple.Create(15, 16),
                // O
                Tuple.Create(16, 16),
                // X
                Tuple.Create(15, 17),
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
                Tuple.Create(15, 15),
                // O
                Tuple.Create(16, 15),
                // X
                Tuple.Create(15, 16),
                // O
                Tuple.Create(16, 16),
                // X
                Tuple.Create(17, 17),
                // O
                Tuple.Create(16, 17)
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
