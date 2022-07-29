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


            bool didWin = false;
            char winnerChar = ActivePlayer ? XValue : YValue;
            bool win = true;

            bool firstWin = false;

            for (int x = xLowerBoundary; x <= xHigherBoundary; x++)
            {
                for (int y = yLowerBoundary; y <= yHigherBoundary; y++)
                {
                    // Check left to right
                    for (int i = x; i <= x + 2; i++)
                    {
                        firstWin = true;
                        for (int j = y; j <= y + 2; j++)
                        {
                            if (Board[i, j] != winnerChar)
                            {
                                firstWin = false;
                                break;
                            }
                        }
                        if (firstWin)
                        {
                            didWin = true;
                            break;
                        }
                    }
                    if (didWin)
                    {
                        break;
                    }
                }
                if (didWin)
                {
                    break;
                }
            }

            // Check top to bottom
            for (int x = xLowerBoundary; x <= xHigherBoundary; x++)
            {
                for (int y = yLowerBoundary; y <= yHigherBoundary; y++)
                {
                    for (int j = y; j <= y + 2; j++)
                    {
                        firstWin = true;
                        for (int i = x; i <= x + 2; i++)
                        {
                            if (Board[i, j] != winnerChar)
                            {
                                firstWin = false;
                                break;
                            }
                        }
                        if (firstWin)
                        {
                            didWin = true;
                            break;
                        }
                    }
                    if (didWin)
                    {
                        break;
                    }
                }
                if (didWin)
                {
                    break;
                }
            }


            // Check top left to bottom right

            for (int i = xLowerBoundary, j = yLowerBoundary; i < xLowerBoundary + 2; i++, j++)
            {
                if (Board[i, j] != winnerChar)
                {
                    win = false;
                    break;
                }
            }

            if (win)
            {
                didWin = true;
            }

            // Check top right to bottom left
            win = true;

            for (int i = xLowerBoundary, j = Math.Max(yHigherBoundary, 2); i < xLowerBoundary + 2; i++, j--)
            {
                if (Board[i, j] != winnerChar)
                {
                    win = false;
                    break;
                }
            }

            if (win)
            {
                didWin = true;
            }

            if (!didWin && _placementCounter == (GameBoardLength * GameBoardLength))
            {
                return TicTacToeResult.Tie;
            }
            else if(didWin && ActivePlayer)
            {
                return TicTacToeResult.XWon;
            }
            else if(didWin)
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