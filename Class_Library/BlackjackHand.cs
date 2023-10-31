using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public class BlackjackHand : Hand
    {
        public int Score { get; private set; }

        public bool IsDealer { get; }

        public BlackjackHand(bool isDealer = false)
        {
            IsDealer = isDealer;
        }

        public override void AddCard(ICard card)
        {
            base.AddCard((BlackjackCard)card);

        }
        public override void Draw(int x, int y)
        {
            Score = 0;
            int numberOfAces = 0;
            bool isFirstCard = true;

            foreach (var card in _cards)
            {
                if (card is BlackjackCard blackjackCard)
                {
                    if (IsDealer && isFirstCard)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("XX");
                    }
                    else
                    {
                        blackjackCard.DrawMethod(x + 1, y);
                        Score += blackjackCard.Value;

                        if (blackjackCard.Face == CardFace.A)
                        {
                            numberOfAces++;
                        }
                    }

                    x += 2;
                    isFirstCard = false;
                }
            }

            // Handle Aces with flexible values (1 or 11).
           while (numberOfAces > 0 && Score + 10 <= 21)
            {
                Score += 10;
                numberOfAces--;
            }
        }
    }
}
