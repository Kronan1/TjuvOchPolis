namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[25, 100];
            List<Person> persons = Person.CreateList(board);
            Console.CursorVisible = false;

            while (true)
            {
                board = Helpers.UpdateBoard(board, persons);
                Helpers.DrawBoard(board);

                Thread.Sleep(10);
                Console.Clear();
                Helpers.Move(persons, board);
                Helpers.CheckCollision(persons);
            }



        }
    }
}