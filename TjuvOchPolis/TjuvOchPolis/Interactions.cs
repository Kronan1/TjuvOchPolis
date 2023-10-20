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
    }
}
