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

            Board[x, y] = ActivePlayer ? YValue : XValue;
            ActivePlayer = !ActivePlayer;
            _placementCounter++;

            return TicTacToeSetResult.Success;
        }

        public TicTacToeResult GetWinner()
        {
            bool didWin = false;
            char winnerChar = ActivePlayer ? XValue : YValue;
            bool win = true;

            bool firstWin;
            // Check left to right
            for (int i = 0; i < GameBoardLength; i++)
            {
                firstWin = true;
                for (int j = 0; j < GameBoardLength; j++)
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

            // Check top to bottom
            for (int j = 0; j < GameBoardLength; j++)
            {
                firstWin = true;
                for (int i = 0; i < GameBoardLength; i++)
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


            // Check top left to bottom right
            for (int i = 0, j = 0; i < GameBoardLength; i++, j++)
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
            for (int i = 0, j = GameBoardLength - 1; i < GameBoardLength; i++, j--)
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