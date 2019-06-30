using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Words_2._0
{
    class Player
    {
        public string Name { get; set; }
        public Player(string name)
        {
            Name = name;
        }
        public static void InputNickname(out Player player)
        {
            player = null;
            bool checkNickname = false;
            do
            {
                string playerNickname = Console.ReadLine();    ///ввод ника игрока
                checkNickname = CheckNicknameLength(playerNickname);
                if (!checkNickname)
                {
                    Console.WriteLine("You enter nickname with wrong length. Length can be 8-20 characters. Please press any key to re-enter...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    player = new Player(playerNickname);
                    break;
                }
            }
            while (!checkNickname);
        }
        public static bool CheckNicknameLength(string name)
        {
            if (name.Length >= 8 && name.Length < 20)///проверка на длину первого ника
                return true;
            return false;
        }
        public static bool CheckNicknamesEquals(Player first, Player second)
        {
            if (first.Name != second.Name)
                return true;
            else return false;
        }
    }
}
