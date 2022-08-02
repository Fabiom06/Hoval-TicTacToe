using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Tests
{
    internal static class Helpers
    {
        internal static void PrintTicTacToe(TicTacToeGame game, List<Tuple<int, int>> steps)
        {
            var currentPlayer = false;
            var board = new char[game.GameBoardLength, game.GameBoardLength];
            foreach(var step in steps)
            {
                board[step.Item1, step.Item2] = currentPlayer ? 'X' : 'Y';
                currentPlayer = !currentPlayer;
            }

            Debug.WriteLine($"--{string.Join('-', Enumerable.Range(0, game.GameBoardLength))} --");
            for (var i = 0; i < game.GameBoardLength; i++)
            {
                Debug.Write(i);
                Debug.Write("|");
                for (var j = 0; j < game.GameBoardLength; j++)
                {
                    Debug.Write(board[i, j] == 0 ? " " : board[i, j]);
                    Debug.Write("|");
                }
                Debug.WriteLine("");
            }
        }
    }
}
