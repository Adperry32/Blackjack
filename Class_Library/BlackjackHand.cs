using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Class_Library
{
    public class BlackjackHand : Hand
    {
        public int Score { get; set; }

        public bool IsDealer { get; }
        public bool ShowFirstCard { get; set; }
        public bool isFirstCard { get; set; }

        public BlackjackHand(bool isDealer = false)
        {
            IsDealer = isDealer;
            ShowFirstCard = false;
        }

        public override void AddCard(ICard card)
        {
            base.AddCard((BlackjackCard)card);
        }
        public override void Draw(int x, int y)
        {
            Score = 0;
            int numberOfAces = 0;
            isFirstCard = true;

            foreach (var card in _cards)
            {
                if (card is BlackjackCard blackjackCard)
                {
                    if (IsDealer && isFirstCard && !ShowFirstCard)
                    {
                        Console.SetCursorPosition(x, y);
                        for (int i = 0; i < 5; i++)
                        {
                            string cardBack = "***21**";
                            string cardBack2 = "*******";
                            Console.SetCursorPosition(x + 1, y + i);
                            Console.BackgroundColor = ConsoleColor.Blue;

                            switch (i)
                            {
                                case 0:
                                case 4:

                                    Console.WriteLine($"{cardBack}");
                                    break;
                                case 2:
                                    Console.WriteLine($"{cardBack2}");
                                    break;
                                default:
                                    Console.WriteLine($"{cardBack2}");
                                    break;

                            }
                        }
                        Score += blackjackCard.Value;
                        Console.ResetColor();
                    }
                    else if (IsDealer && ShowFirstCard)
                    {
                        blackjackCard.DrawMethod(5 + 1, 5);
                        Score += blackjackCard.Value;
                        ShowFirstCard = false;
                        Thread.Sleep(1000);
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
