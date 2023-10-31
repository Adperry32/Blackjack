using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public enum CardFace
    {
        A = 1,
        K = 13,
        Q = 12,
        J = 11,
        Ten = 10,
        Nine = 9,
        Eight = 8,
        Seven = 7,
        Six = 6,
        Five = 5,
        Four = 4,
        Three = 3,
        Two = 2
    }
    public enum CardSuit
    {
        Spade,
        Diamond,
        Heart,
        Club
    }
    public class Cards : ICard
    {

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public Cards(CardFace face, CardSuit suit)
        {
            Face = face;
            Suit = suit;
        }
        public void DrawMethod(int x, int y)
        {

            char suitSymbol = GetCardSymbol(Suit);
            string faceValue = GetCardValue(Face);

            if (Suit == CardSuit.Spade || Suit == CardSuit.Club)
            {
                //setting symbols in the corners and color per suit

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

            }
            else if (Suit == CardSuit.Heart || Suit == CardSuit.Diamond)
            {
                //setting symbols in the corners and color per suit

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;


            }
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(x, y + i);

                switch (i)
                {
                    case 0:
                    case 4:
                        Console.WriteLine($"{suitSymbol}     {suitSymbol}");
                        break;
                    case 2:
                        //check that value isnt null or types that cant be parsed to int
                        if (faceValue != null && faceValue != "A" && faceValue != "K" && faceValue != "Q" && faceValue != "J")
                        {

                            int faceNumber = int.Parse(faceValue);
                           
                            if (faceNumber == 10)
                            {
                                //adjust the space for a double digit number
                                Console.WriteLine($"   {faceValue}  ");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"   {faceValue}   ");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"   {faceValue}   ");
                            break;
                        }
                    default:
                        Console.WriteLine("       ");
                        break;

                }

            }
            Console.ResetColor();

        }

        public string GetCardValue(CardFace face)
        {

            if (((int)face) >= 2 && ((int)face) <= 10)
            {
                return ((int)face).ToString();
            }
            else if ((int)face == 1)
            {
                return "A";
            }
            else
            {
                // handle the special faced cards (A,K,Q,J)
                switch (face)
                {
                    case CardFace.A:
                        return "A";
                    case CardFace.J:
                        return "J";
                    case CardFace.Q:
                        return "Q";
                    case CardFace.K:
                        return "K";
                }
            }

            return null;

        }
        public static char GetCardSymbol(CardSuit suit)
        {
            switch (suit)
            {
                case CardSuit.Spade:
                    return '♠';
                case CardSuit.Heart:
                    return '♥';
                case CardSuit.Club:
                    return '♣';
                case CardSuit.Diamond:
                    return '♦';
                default:
                    return ' ';
            }
        }

    }
}
