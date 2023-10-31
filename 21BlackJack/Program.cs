using Class_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21BlackJack
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Deck deck = new Deck();
   
            #region MenuControl
            string[] blackjackmenu = { "1. Play BlackJack", "2. Shuffle & Show Deck", "3. Exit" };
            bool control = true;
            #endregion

            #region GameLogic
            while (control)
            {
                ReadChoice("Selection Below\n", blackjackmenu, out int num);
                {
                    switch (num)
                    {
                        case 1:
                            Console.WriteLine("\nPlay BlackJack\n");
                            break;

                        case 2:
                            deck.Shuffle();
                            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                            List<ICard> shuffled = deck.GetShuffledDeck();

                            int x = 0;
                            int y = 10;
                            int maxCardsPerRow = Console.WindowWidth;

                            foreach (ICard card in shuffled)
                            {
                                if (x  > maxCardsPerRow)
                                {
                                    x = 0;
                                    y += 6; // Adjust for card height
                                }
                                card.DrawMethod(x, y);
                                x += 10;
                            }
                 
                            break;

                        case 3:
                            control = false;
                            break;
                    }
                }
            }
            #endregion
        }
        static public int ReadIntegar(string prompt, int min, int max)
        {
            Console.WriteLine(prompt);
            int num;
            bool Valid = false;
            do
            {
                bool valid = Int32.TryParse(Console.ReadLine(), out num);
                if (!valid || num < min || num > max)

                {
                    Console.WriteLine($"Error Please Try Again Invalid number!!");
                    Console.WriteLine();
                    Console.WriteLine(prompt);
                }
                else if (valid || num > min && num < max)
                {
                    Valid = true;
                }
            }
            while (!Valid);
            return num;
        }
        static void ReadChoice(string prompt, string[] options, out int selection)
        {
            Console.WriteLine(prompt);
            int menu = options.Length;
            string choice = "";
            foreach (string item in options)
            {
                Console.WriteLine(item.ToString());
            }

            if (Int32.TryParse(choice, out int num))
            {
                Console.WriteLine(ReadIntegar(choice, num, menu));
            }
            selection = ReadIntegar("", 1, 3);
        }      
    }
}
