using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Helpers
    {
        public static char[,] UpdateBoard(char[,] board, List<Person> persons)
        {
            char[,] newBoard = new char[board.GetLength(0), board.GetLength(1)];
            for (var i = 0; i < newBoard.GetLength(0); i++)
            {
                for (var j = 0; j < newBoard.GetLength(1); j++)
                {
                    newBoard[i, j] = ' ';
                }
            }
            foreach (var person in persons)
            {
                newBoard[person.Y, person.X] = person.Type;
            }

            return newBoard;   
        }

        public static void Move(List<Person> persons)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                //switch ()
            }
        }

        public static void DrawBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(1) + 2; i++)
            {
                Console.Write('=');
            }
            Console.WriteLine();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write('|');
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);

                }
                Console.Write('|');
                Console.WriteLine();
            }

            for (int i = 0; i < board.GetLength(1) + 2; i++)
            {
                Console.Write('=');
            }
            Console.WriteLine();

        }
    }
}
