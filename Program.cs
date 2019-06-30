using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Words_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Player firstPlayer, secondPlayer;
            Console.WriteLine("Enter the first player nickname");
            Player.InputNickname(out firstPlayer);
            do
            {
                Console.WriteLine("Enter the second player nickname");
                Player.InputNickname(out secondPlayer);
                bool checkEqual = Player.CheckNicknamesEquals(firstPlayer, secondPlayer);
                if (checkEqual) break;
                else
                {
                    Console.WriteLine("You can't enter an equal nicknames. Please press any key to re-enter...");
                    Console.ReadKey();
                }
            }
            while (true);
            string gameLanguage = Game.InputLanguage();
            Game game = new Game(firstPlayer, secondPlayer, gameLanguage);
            
            Console.ReadKey();
        }
        
    }
}
