namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[18, 140];
            List<string> nameList = Helpers.NameList();
            List<Person> persons = Person.CreateList(board, nameList);
            Console.CursorVisible = false;
            Interactions interactions = new Interactions();
            DateTime datetime = DateTime.Now;
            Jail jail = new Jail();
            Poorhouse poorhouse = new Poorhouse();
            int numberOfThieves = 0;

            while (true)
            {
                numberOfThieves = Helpers.UpdateNumberOfThieves(persons);
                numberOfThieves += Helpers.UpdateNumberOfThieves(jail.JailList);

                board = Helpers.UpdateBoard(board);
                jail.Board = Helpers.UpdateBoard(jail.Board);
                poorhouse.Board = Helpers.UpdateBoard(poorhouse.Board);

                Helpers.DrawBoard(board, persons, interactions, numberOfThieves);
                Helpers.DrawBoard(jail.Board, jail.JailList, interactions, numberOfThieves);
                Helpers.DrawBoard(poorhouse.Board, poorhouse.PoorhouseList, interactions, numberOfThieves);
                Console.WriteLine();
                interactions.PrintConversations();

                Thread.Sleep(10);
                Helpers.Move(persons, board, datetime);
                Helpers.CheckCollision(persons, interactions);

                persons = jail.PutPeopleInJail(persons, interactions);
                persons = poorhouse.PutPeopleInPoorhouse(persons, interactions);
                Helpers.Move(jail.JailList, jail.Board, datetime);
                Helpers.Move(poorhouse.PoorhouseList, poorhouse.Board, datetime);
                datetime = Helpers.ChangeDirection(persons, datetime);
                Console.Clear();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    persons = Helpers.AddPerson(key, board, persons);
                }

            }



        }
    }
}