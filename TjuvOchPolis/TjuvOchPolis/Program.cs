namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            City city = new City();
            Jail jail = new Jail();
            Poorhouse poorhouse = new Poorhouse();
            Interactions interactions = new Interactions();
            Console.CursorVisible = false;

            while (true)
            {
                city.NumberOfThieves = Helpers.UpdateNumberOfThieves(city.Persons);
                city.NumberOfThieves += Helpers.UpdateNumberOfThieves(jail.JailList);

                city.Board = Helpers.UpdateBoard(city.Board);
                jail.Board = Helpers.UpdateBoard(jail.Board);
                poorhouse.Board = Helpers.UpdateBoard(poorhouse.Board);
                
                Helpers.DrawBoard(city.Board, city.Persons, interactions, city.NumberOfThieves);
                Helpers.DrawBoard(jail.Board, jail.JailList, interactions, city.NumberOfThieves);
                Helpers.DrawBoard(poorhouse.Board, poorhouse.PoorhouseList, interactions, city.NumberOfThieves);
                Console.WriteLine();
                interactions.PrintConversations();

                Thread.Sleep(100);
                Helpers.Move(city.Persons, city.Board, city.Datetime);
                Helpers.CheckCollision(city.Persons, interactions);

                city.Persons = jail.PutPeopleInJail(city.Persons, interactions);
                city.Persons = poorhouse.PutPeopleInPoorhouse(city.Persons, interactions);
                Helpers.Move(jail.JailList, jail.Board, city.Datetime);
                Helpers.Move(poorhouse.PoorhouseList, poorhouse.Board, city.Datetime);
                city.Datetime = Helpers.ChangeDirection(city.Persons, city.Datetime);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    city.Persons = Helpers.AddPerson(key, city.Board, city.Persons);
                }


                Console.Clear();
            }
        }
    }
}