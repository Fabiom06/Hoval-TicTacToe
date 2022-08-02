namespace TicTacToe.Tests
{
    public class Tests
    {
        private const int _boardSize = 3;
        private TicTacToeGame _game;

        [SetUp]
        public void Setup()
        {
            _game = new TicTacToeGame(_boardSize);
        }

        [Test]
        public void TestInvalidCoordinates()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                Tuple.Create(-1, -1),
                Tuple.Create( 0, -1),
                Tuple.Create(-1, 0 ),
                Tuple.Create( -1, -1 ),
                Tuple.Create(_boardSize, 0 ),
                Tuple.Create(0, _boardSize ),
                Tuple.Create(_boardSize * _boardSize, _boardSize)
            };

            foreach (var pair in valuePairs)
            {
                Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.InvalidCoordinates));
            }
        }

        [Test]
        public void TestExistingCoordinates()
        {
            var valuePairs = new List<Tuple<int, int>>
            {
                Tuple.Create(0, 0),
                Tuple.Create(2, 1),
                Tuple.Create(1, 1),
                Tuple.Create(1, 2),
                Tuple.Create(0, 1),
                Tuple.Create(1, 0)
            };

            Helpers.PrintTicTacToe(_game, valuePairs);

            foreach (var pair in valuePairs)
            {
                var activePlayerBefore = _game.ActivePlayer;
                Assert.Multiple(() =>
                {
                    Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.Success));
                    Assert.That(!_game.ActivePlayer, Is.EqualTo(activePlayerBefore));
                });

                var activePlayerAfter = _game.ActivePlayer;
                Assert.Multiple(() =>
                {
                    Assert.That(_game.SetXYValue(pair.Item1, pair.Item2), Is.EqualTo(TicTacToeSetResult.AlreadyPlaced));
                    Assert.That(_game.ActivePlayer, Is.EqualTo(activePlayerAfter));
                });
            }
        }
    }
}