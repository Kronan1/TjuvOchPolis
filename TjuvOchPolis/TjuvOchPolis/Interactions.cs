using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Interactions
    {
        public List<string> Conversations { get; set; }

        public bool NewConversation { get; set; }

        public int Robberies { get; set; }
        public int Arrested { get; set; }

        public Interactions()
        {
            Conversations = new List<string>();
            NewConversation = false;
        }
        public void PrintConversations()
        {
            CheckListLength();
            foreach (var conversation in Conversations)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(conversation);
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (NewConversation)
            {
                Thread.Sleep(1500);
                NewConversation = false;
            }
        }

        public void CheckListLength()
        {
            int listLength = 5;

            if (Conversations.Count > listLength)
            {
                int amountToRemove = Conversations.Count - listLength;

                for(int i = 0; i < amountToRemove; i++)
                {
                    Conversations.RemoveAt(0);
                }
            }
        }
    }
}
