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
            BlackjackCard blackjack = new BlackjackCard(CardFace.Eight, CardSuit.Diamond);
            Hand update = new Hand();
            update.AddCard(card);
            
            foreach (ICard cards in _cards)
            {
                Score += blackjack.Value;
            }
        }
        public override void Draw(int x, int y)
        {
            // draw cards
            //draw the score
            //and if its dealers hand, hide the first card.
        }
    }
}
