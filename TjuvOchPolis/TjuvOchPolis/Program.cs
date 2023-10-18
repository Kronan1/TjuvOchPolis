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
                Helpers.Move(persons);

                Thread.Sleep(2000);
                Console.Clear();
            }
         
            

        }
    }
}