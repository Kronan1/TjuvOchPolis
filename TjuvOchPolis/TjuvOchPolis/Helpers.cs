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

        public static void Move(List<Person> persons, char[,] board)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                switch (persons[i].Direction)
                {
                    case 0:
                        persons[i].X++;
                        break;
                    case 1:
                        persons[i].X--;
                        break;
                    case 2:
                        persons[i].Y++;
                        break;
                    case 3:
                        persons[i].Y--;
                        break;
                    case 4:
                        persons[i].Y++;
                        persons[i].X++;
                        break;
                    case 5:
                        persons[i].X--;
                        persons[i].Y--;
                        break;
                }

                if (persons[i].Y > board.GetLength(0) - 1)
                {
                    persons[i].Y = 0;
                }
                else if (persons[i].Y < 0)
                {
                    persons[i].Y = board.GetLength(0) - 1;
                }

                if (persons[i].X > board.GetLength(1) - 1)
                {
                    persons[i].X = 0;
                }
                else if (persons[i].X < 0)
                {
                    persons[i].X = board.GetLength(1) - 1;
                }

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

        public static void CheckCollision(List<Person> persons)
        {

            for (int i = 0; i < persons.Count; i++)
            {
                persons[i].PersonsMet.Clear();
                for (int j = 0; j > persons.Count; j++)
                {

                    if (persons[i].X == persons[j].X && persons[i].Y == persons[j].Y && i != j && !persons[i].PersonsMet.Contains(persons[j]))
                    {
                        Helpers.CalculateColission(persons[i], persons[j]);
                    }

                }
            }

        }

        public static void CalculateColission(Person person1, Person person2)
        {
            person1.PersonsMet.Add(person2);

            //switch (person1.GetType())
            //{

            //    case Police:
            //        int test = 0;
            //        break;


            //}

        }
    }
}
