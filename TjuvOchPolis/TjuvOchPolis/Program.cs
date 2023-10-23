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
            
            //Console.ForegroundColor = ConsoleColor.Green;
          

            while (true)
            {
                for (int i = 0; i < persons.Count; i++)
                {
                    persons[i].PersonsMet.Clear();
                }
                board = Helpers.UpdateBoard(board, persons);
                Helpers.DrawBoard(board);
                Console.WriteLine();
                interactions.PrintConversations();

                Thread.Sleep(100);
                Helpers.Move(persons, board);
                Helpers.CheckCollision(persons, interactions);
                Console.Clear();

            }



        }
    }
}