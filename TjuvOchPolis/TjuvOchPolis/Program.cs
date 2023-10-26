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
            DateTime datetime = DateTime.Now;
            Jail jail = new Jail();
            int numberOfThieves = 0;

            //Console.ForegroundColor = ConsoleColor.Green;

            foreach (Person person in persons)
            {
                if (person is Thief thief)
                {
                    numberOfThieves += 1;
                }
            }

            while (true)
            {
                board = Helpers.UpdateBoard(board);
                jail.Board = Helpers.UpdateBoard(jail.Board);
                Helpers.DrawBoard(board, persons, interactions, numberOfThieves);
                Helpers.DrawBoard(jail.Board, jail.JailList, interactions, numberOfThieves);
                Console.WriteLine();
                interactions.PrintConversations();

                Thread.Sleep(10);
                Helpers.Move(persons, board, datetime);
                Helpers.CheckCollision(persons, interactions);
                persons = jail.PutPeopleInJail(persons, interactions);
                Helpers.Move(jail.JailList, jail.Board, datetime);
                datetime = Helpers.ChangeDirection(persons, datetime);
                Console.Clear();

            }



        }
    }
}