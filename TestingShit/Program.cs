using TicTacToe;
using System.Linq;

internal class Program
{
    private static bool TryGetUserXYInput(TicTacToeGame game, char coordinateName, out int coordinate)
    {
        coordinate = 0;

        string? input;
        do
        {
            do
            {
                Console.Clear();
                PrintBoard(game);
                Console.WriteLine($"Enter {coordinateName}: ");

                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && (input[0] == 'c' || input[0] == 'C'))
                {
                    return false;
                }
            }
            while (!int.TryParse(input, out coordinate));

            if (coordinate < 0 || coordinate >= game.GameBoardLength)
            {
                if (WriteError($"Invalid {coordinateName} value"))
                {
                    return false;
                }
                continue;
            }
            break;
        }
        while (true);

        return true;
    }

    private static void PrintBoard(TicTacToeGame game)
    {
        Console.Clear();
        Console.WriteLine($"--{string.Join('-', Enumerable.Range(0, game.GameBoardLength))} --");
        for (int i = 0; i < game.GameBoardLength; i++)
        {
            Console.Write(i);
            Console.Write("|");
            for (int j = 0; j < game.GameBoardLength; j++)
            {
                Console.Write(game.Board[i, j]);
                Console.Write("|");
            }
            Console.WriteLine("");
        }
    }

    private static bool WriteError(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("\n");
        Console.WriteLine("\n");
        if (Console.ReadKey().Key == ConsoleKey.C)
        {
            return true;
        }
        return false;
    }

    private static void PlayGame(int gameSize)
    {
        var game = new TicTacToeGame(gameSize);

        while (true)
        {
            if (!TryGetUserXYInput(game, 'X', out int x) || !TryGetUserXYInput(game, 'Y', out int y))
            {
                return;
            }

            switch (game.SetXYValue(x, y))
            {
                case TicTacToeSetResult.AlreadyPlaced:
                    if (WriteError("Value is already placed! HUSO"))
                    {
                        return;
                    }
                    break;

                case TicTacToeSetResult.InvalidCoordinates:
                    if (WriteError("Invalid coordinates given! HUSO"))
                    {
                        return;
                    }
                    break;

                case TicTacToeSetResult.Success:
                    if (game.TryGetWinner(out var result))
                    {
                        if (result == TicTacToeResult.Tie)
                        {
                            Console.WriteLine("You are both HUSOs");
                        }
                        else
                        {
                            Console.WriteLine($"{(result == TicTacToeResult.XWon ? 'X' : 'Y')} has won! What a HUSO");
                        }
                        return;
                    }
                    break;
            }
        }
    }

    private static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Enter Board Size:");
            if (int.TryParse(Console.ReadLine(), out var gameSize))
            {
                PlayGame(gameSize);
            }
            else
            {
                for (var i = 0; i < Random.Shared.Next(0, 10); i++)
                {
                    Console.WriteLine("was ein HUON du doch bist");
                }
            }

            Console.WriteLine("Play another game?");
            if(Console.ReadKey().Key == ConsoleKey.C)
            {
                return;
            }
        } while (true);
    }
}