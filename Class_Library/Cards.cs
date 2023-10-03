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
        A = 14,
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
            ICard card = Factory.CreateCard(Face, Suit); // Replace this with your factory class logic

            Console.SetCursorPosition(x, y);

            char suitSymbol = GetCardSymbol(card.Suit);
            int faceValue = GetCardValue(card.Face);

            //ConsoleColor suitColor = GetSuitColor(card.Suit);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine($" {suitSymbol}      {suitSymbol} ");
            Console.WriteLine("        ");
            Console.WriteLine($"    {faceValue}    ");
            Console.WriteLine("        ");
            Console.WriteLine($" {suitSymbol}      {suitSymbol} ");

            Console.ResetColor();
            Console.WriteLine();
        }

        public int GetCardValue(CardFace face)
        {
            int value = 0;
            if(((int)face) <= 10)
            {
               value = (int)face;
            }
            if(((int)face) > 10)
            {
                //face.GetType();
            }

            return value;
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
