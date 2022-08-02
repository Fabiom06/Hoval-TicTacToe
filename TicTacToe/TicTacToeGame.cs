namespace TicTacToe
{
    public class TicTacToeGame
    {
        public int GameBoardLength { get; }
        public char[,] Board { get; }
        public bool ActivePlayer { get; private set; }

        public readonly char XValue = 'X';
        public readonly char YValue = 'O';

        private int _placementCounter;

        private int _lastPlacedX;
        private int _lastPlacedY;

        private const char _emptyValue = ' ';

        public TicTacToeGame(int boardSize = 3, char xValue = 'X', char yValue = 'O')
        {
            GameBoardLength = boardSize;
            Board = new char[boardSize, boardSize];
            XValue = xValue;
            YValue = yValue;

            Reset();
        }

        public void Reset()
        {
            _placementCounter = 0;
            ActivePlayer = false;

            for (int i = 0; i < GameBoardLength; i++)
            {
                for (int j = 0; j < GameBoardLength; j++)
                {
                    Board[i, j] = _emptyValue;   
                }
            }
        }

        public TicTacToeSetResult SetXYValue(int x, int y)
        {
            if (x < 0 || x >= GameBoardLength || y < 0 || y >= GameBoardLength)
            {
                return TicTacToeSetResult.InvalidCoordinates;
            }

            if (Board[x, y] != _emptyValue)
            {
                return TicTacToeSetResult.AlreadyPlaced;
            }

            _lastPlacedX = x;
            _lastPlacedY = y;
            Board[x, y] = ActivePlayer ? YValue : XValue;
            ActivePlayer = !ActivePlayer;
            _placementCounter++;

            return TicTacToeSetResult.Success;
        }

        public TicTacToeResult GetWinner()
        {
            char winnerChar = ActivePlayer ? XValue : YValue;

            // - 1 for array boundaries (start at 0, not 1)
            // - 2 for inner array loop

            var xLowerBoundary = Math.Max(0, _lastPlacedX - 2);
            var xHigherBoundary = Math.Min(GameBoardLength - 1 - 2, _lastPlacedX + 2);

            var yLowerBoundary = Math.Max(0, _lastPlacedY - 2);
            var yHigherBoundary = Math.Min(GameBoardLength - 1 - 2, _lastPlacedY + 2);

            for (int x = xLowerBoundary; x <= xHigherBoundary; x++)
            {
                var verticalWin = true;

                for (int i = x; i < x + 3; i++)
                {
                    if (Board[i, _lastPlacedY] != winnerChar)
                    {
                        verticalWin = false;
                        break;
                    }
                }

                if (verticalWin)
                {
                    return ReturnWinner(true);
                }
            }

            for (int y = yLowerBoundary; y <= yHigherBoundary; y++)
            {
                var horizontalWin = true;

                for (int j = y; j < y + 3; j++)
                {
                    if (Board[_lastPlacedX, j] != winnerChar)
                    {
                        horizontalWin = false;
                        break;
                    }
                }

                if (horizontalWin)
                {
                    return ReturnWinner(true);
                }
            }

            var xDiagonalLowerBoundary = Math.Max(0, _lastPlacedX - 2);
            var yDiagonalLowerBoundary = Math.Max(0, _lastPlacedY - 2);

            var xDiagonalHigherBoundary = Math.Min(_lastPlacedX, GameBoardLength - 1 - 2);
            var yDiagonalHigherBoundary = Math.Min(_lastPlacedY, GameBoardLength - 1 - 2);

            for (
                int x = xDiagonalLowerBoundary, y = yDiagonalLowerBoundary;
                x <= Math.Min(xDiagonalHigherBoundary, yDiagonalHigherBoundary);
                x++, y++)
            {
                bool diagonalWin = true;

                for (int i = x, j = y; i < x + 3; i++, j++)
                {
                    if (Board[i, j] != winnerChar)
                    {
                        diagonalWin = false;
                        break;
                    }
                }

                if (diagonalWin)
                {
                    return ReturnWinner(true);
                }
            }

            var xDiagonalMirroredLowerBoundary = Math.Max(0, _lastPlacedX - 2);
            var yDiagonalMirroredHigherBoundary = Math.Min(GameBoardLength - 1, _lastPlacedY + 2);

            var xDiagonalMirroredHigherBoundary = Math.Min(_lastPlacedX + 2, GameBoardLength - 1);
            var yDiagonalMirroredLowerBoundary = Math.Max(0, _lastPlacedY - 2);

            var isAtLeftSide = _lastPlacedY == 0;
            var isAtTopSide = _lastPlacedX == 0;
            var isAtBottomSide = _lastPlacedX == (GameBoardLength - 1);
            var isAtRightSide = _lastPlacedY == (GameBoardLength - 1);

            if (isAtBottomSide)
            {
                yDiagonalMirroredLowerBoundary = _lastPlacedY;
                if(!isAtRightSide && yDiagonalMirroredLowerBoundary != 0)
                {
                    xDiagonalMirroredLowerBoundary = yDiagonalMirroredLowerBoundary;
                }
            }

            if (isAtRightSide)
            {
                xDiagonalMirroredLowerBoundary = _lastPlacedX;
            }

            if(isAtTopSide)
            {
                yDiagonalMirroredHigherBoundary = _lastPlacedY;
            }

            if (
                yDiagonalMirroredHigherBoundary - yDiagonalMirroredLowerBoundary >= 2 ||
                xDiagonalMirroredHigherBoundary - xDiagonalMirroredLowerBoundary >= 2
            )
            {
                for (
                    int x = xDiagonalMirroredLowerBoundary, y = yDiagonalMirroredHigherBoundary;
                    x <= xDiagonalMirroredHigherBoundary - 2 || y >= yDiagonalMirroredLowerBoundary + 2;
                    x++, y--)
                {
                    bool diagonalWin = true;

                    for (int i = x, j = y; i < x + 3; i++, j--)
                    {
                        if (Board[i, j] != winnerChar)
                        {
                            diagonalWin = false;
                            break;
                        }
                    }

                    if (diagonalWin)
                    {
                        return ReturnWinner(true);
                    }
                }
            }

            return ReturnWinner(false);
        }

        private TicTacToeResult ReturnWinner(bool wonTheGame)
        {
            if (!wonTheGame && _placementCounter == (GameBoardLength * GameBoardLength))
            {
                return TicTacToeResult.Tie;
            }
            else if (wonTheGame && ActivePlayer)
            {
                return TicTacToeResult.XWon;
            }
            else if (wonTheGame)
            {
                return TicTacToeResult.YWon;
            }

            return TicTacToeResult.None;
        }

        public bool TryGetWinner(out TicTacToeResult ticTacToeResult)
        {
            ticTacToeResult = GetWinner();
            if (ticTacToeResult == TicTacToeResult.None)
            {
                return false;
            }
            return true;
        }
    }
}