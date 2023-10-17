namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[25, 100];
            List<Person> persons = Person.CreateList(board);

            while (true)
            {
                board = Helpers.UpdateBoard(board);
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        Console.Write(board[i, j]);

                    }
                    Console.WriteLine();

                }

                Thread.Sleep(2000);
                Console.Clear();
            }
         
            

        }
    }
}