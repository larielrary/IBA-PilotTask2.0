using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Game_Words_2._0
{
    class Game
    {
        public static Timer myTimer;
        public string Language { get; set; }
        public Player FirstPlayer { get; set; }
        public Player SecondPlayer { get; set; }
        public Game(Player firstPlayer, Player secondPlayer, string language)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            Language = language;
        }
        public static string InputLanguage()
        {
            bool successfulInput = false;
            string checkLanguage = string.Empty;
            do
            {
                Console.WriteLine("\nPleese, select language to play");
                Console.WriteLine("1. English");
                Console.WriteLine("2. Русский");
                checkLanguage = Console.ReadLine();
                successfulInput = CheckLanguage(checkLanguage);
                if (!successfulInput)
                {
                    Console.WriteLine("You enter wrong language key. Please, press any key to re-enter...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    if (checkLanguage == "1")
                    {
                        checkLanguage = "English";
                        break;
                    }
                    if (checkLanguage == "2")
                    {
                        checkLanguage = "Russian";
                        break;
                    }
                }

            }
            while (!successfulInput);
            return checkLanguage;
        }
        public static bool CheckLanguage(string language)
        {
            if (language == "1" || language == "2") ///проверка языка
                return true;
            return false;
        }
        List<string> newWords = new List<string>();
        public void GameInEnglish()
        {
            myTimer = new Timer();
            myTimer.Interval = 10000;
            myTimer.Elapsed += OnTimedEvent;
            string startWord = string.Empty;
            bool successfulInput = false; ///для проверки успешного ввода слова
            bool firstPlayerMove = false;///ход первого игрока
            bool secondPlayerMove = false;///ход второго игрока
            Console.WriteLine($"{FirstPlayer} moves\n");
            do
            {
                firstPlayerMove = true;
                Console.WriteLine("\nEnter a start word: ");
                startWord = Console.ReadLine();
                if (startWord.Length >= 8 && startWord.Length <= 30) ///провера на длину слова
                        successfulInput = true;
                if (!successfulInput)
                {
                    Console.WriteLine("You enter a wrong word. Press any key to re-entry");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (!successfulInput);
            firstPlayerMove = false;
            
            newWords.Add(startWord.ToString());///запоминаем в список, чтобы не было повторяющихся слов
            bool checkWord = true;
            secondPlayerMove = true;
            while (checkWord)
            {
                if (firstPlayerMove == true) Console.WriteLine($" {FirstPlayer} moves");
                if (secondPlayerMove == true) Console.WriteLine($"{SecondPlayer} moves");
                myTimer.Start();
                Console.WriteLine("Enter your new word: ");
                string newWord = Console.ReadLine();
                if (newWords.Contains(newWord))///если слово уже есть в списке, то все плохо - мы проиграли
                {
                    checkWord = false;
                    Console.WriteLine("You enter an existing word. Sorry, you lose");
                    break;
                }
                else
                {
                    bool check = CheckNewWord(startWord);
                   
                    Console.WriteLine(check ? "You can create a word." : "You can't create a word. You lose.\nPress any key to exit...");
                    if (!check) checkWord = false;
                    else newWords.Add(newWord);
                }
                myTimer.Stop();///остановка таймера
                if (firstPlayerMove == true)///переход хода
                {
                    firstPlayerMove = false;
                    secondPlayerMove = true;
                }
                else
                {
                    secondPlayerMove = false;
                    firstPlayerMove = true;
                }
            }
        }
   
        public void OutputRules()
        {
            if (Language == "English")
                Console.WriteLine("Rules of the game. \nThe first player enters the word. \nNext, the second player enters a word consisting of the letters of the source word. \nIf the player does not enter the word / word impossible to create from the source, the player lost.");
            if (Language == "Russian")
                Console.WriteLine("Правила игры. \nПервый игрок вводит слово. \nДалее второй игрок вводит слово, состоящее из букв исходного слова. \nЕсли же игрок не вводит слово / слово невозможно создать из исходного, игрок проиграл.");
             
        }
        public static bool CheckNewWord(string word)
        {
            var baseString = word.ToString().ToLower().GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());///проверка, можно ли составить новое слово из исходного
            bool check = newWord.ToLower().GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count())
                .All(x => baseString.ContainsKey(x.Key) && baseString[x.Key] >= x.Value);
            return check;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Time is up! Game over. Press any key to return to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
