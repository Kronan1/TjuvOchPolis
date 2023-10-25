namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[25, 100];
            List<string> nameList = Helpers.NameList();
            List<Person> persons = Person.CreateList(board, nameList);
            Console.CursorVisible = false;
            Interactions interactions = new Interactions();

            Jail jail = new Jail();

            //Console.ForegroundColor = ConsoleColor.Green;

            while (true)
            {
                board = Helpers.UpdateBoard(board);
                jail.Board = Helpers.UpdateBoard(jail.Board);
                Helpers.DrawBoard(board, persons);
                Helpers.DrawBoard(jail.Board, jail.JailList);
                Console.WriteLine();
                interactions.PrintConversations();

                Thread.Sleep(10);
                Helpers.Move(persons, board);
                Helpers.CheckCollision(persons, interactions);
                Console.Clear();

            }



        }
    }
}