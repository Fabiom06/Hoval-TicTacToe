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
            // Lower bound cant go below 0 otherwise you go out of array bounds
            var xLowerBoundary = Math.Max(0, _lastPlacedX - 2);
            var yLowerBoundary = Math.Max(0, _lastPlacedY - 2);
            // - 1 for array boundaries (start at 0, not 1)
            // - 2 for inner array loop
            var xHigherBoundary = Math.Min(GameBoardLength - 1 - 2, _lastPlacedX + 2);
            var yHigherBoundary = Math.Min(GameBoardLength - 1 - 2, _lastPlacedY + 2);


            bool wonTheGame = false;
            char winnerChar = ActivePlayer ? XValue : YValue;

            // Check left to right
            bool horizontalWin;
            for (int x = xLowerBoundary; x <= xHigherBoundary; x++)
            {
                for (int y = yLowerBoundary; y <= yHigherBoundary; y++)
                {
                    // Check left to right
                    for (int i = x; i <= x + 2; i++)
                    {
                        horizontalWin = true;
                        for (int j = y; j <= y + 2; j++)
                        {
                            if (Board[i, j] != winnerChar)
                            {
                                horizontalWin = false;
                                break;
                            }
                        }
                        if (horizontalWin)
                        {
                            wonTheGame = true;
                            break;
                        }
                    }
                    if (wonTheGame)
                    {
                        break;
                    }
                }
                if (wonTheGame)
                {
                    break;
                }
            }

            // Check top to bottom
            bool verticalWin;
            for (int x = xLowerBoundary; x <= xHigherBoundary; x++)
            {
                for (int y = yLowerBoundary; y <= yHigherBoundary; y++)
                {
                    for (int j = y; j <= y + 2; j++)
                    {
                        verticalWin = true;
                        for (int i = x; i <= x + 2; i++)
                        {
                            if (Board[i, j] != winnerChar)
                            {
                                verticalWin = false;
                                break;
                            }
                        }
                        if (verticalWin)
                        {
                            wonTheGame = true;
                            break;
                        }
                    }
                    if (wonTheGame)
                    {
                        break;
                    }
                }
                if (wonTheGame)
                {
                    break;
                }
            }

            if (!wonTheGame)
            {
                var xDiagonalLowerBoundary = Math.Max(0, _lastPlacedX - 2);
                var yDiagonalLowerBoundary = Math.Max(0, _lastPlacedY - 2);
                var xDiagonalHigherBoundary = Math.Min(_lastPlacedX - 2, _lastPlacedX + 2);
                var yDiagonalHigherBoundary = Math.Min(_lastPlacedY - 2, _lastPlacedY + 2);

                for(
                    int x = xDiagonalLowerBoundary, y = yDiagonalLowerBoundary;
                    x <= Math.Min(xDiagonalHigherBoundary, yDiagonalHigherBoundary);
                    x++, y++)
                {
                    bool diagonalWin = true;

                    for (int i = x, j = y; i < x + 2; i++, j++)
                    {
                        if (Board[i, j] != winnerChar)
                        {
                            diagonalWin = false;
                            break;
                        }
                    }

                    if(diagonalWin)
                    {
                        wonTheGame = true;
                    }
                }

                //var xDiagonalMirroredLowerBoundary = Math.Max(0, _lastPlacedX - 2);
                //var yDiagonalMirroredLowerBoundary = Math.Min(GameBoardLength - 1, _lastPlacedY + 2);
                //var xDiagonalMirroredHigherBoundary = Math.Min(GameBoardLength - 1, _lastPlacedX + 2);
                //var yDiagonalMirroredHigherBoundary = Math.Max(0, _lastPlacedY - 2);

                //for (
                //    int x = xDiagonalMirroredLowerBoundary;
                //    x < Math.Min(xDiagonalMirroredHigherBoundary, yDiagonalMirroredLowerBoundary);
                //    x++)
                //{
                //    bool diagonalMirroredWin = true;

                //    for (int i = x, j = yDiagonalMirroredLowerBoundary; i < Math.Min(xDiagonalMirroredHigherBoundary, x + 2); i++, j--)
                //    {
                //        if (Board[i, j] != winnerChar)
                //        {
                //            diagonalMirroredWin = false;
                //            break;
                //        }
                //    }

                //    if (diagonalMirroredWin)
                //    {
                //        wonTheGame = true;
                //    }
                //}
            }

            if (!wonTheGame && _placementCounter == (GameBoardLength * GameBoardLength))
            {
                return TicTacToeResult.Tie;
            }
            else if(wonTheGame && ActivePlayer)
            {
                return TicTacToeResult.XWon;
            }
            else if(wonTheGame)
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