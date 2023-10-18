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
                board = Helpers.UpdateBoard(board, persons);
                Helpers.DrawBoard(board);

                //Thread.Sleep(1000);
                Console.Clear();
                Helpers.Move(persons, board);
                Helpers.CheckCollision(persons);
            }



        }
    }
}