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

        public Interactions()
        {
            Conversations = new List<string>();
        }
        public void PrintConversations()
        {
            foreach (var conversation in Conversations)
            {
                Console.WriteLine(conversation);
            }
        }

        public void CheckListLength()
        {
            int listLength = 10;

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
