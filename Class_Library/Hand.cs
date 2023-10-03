using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public class Hand
    {
        Cards cardHand = new Cards(CardFace.A, CardSuit.Club);
        protected List<ICard> _cards = new List<ICard>();
        public virtual void AddCard(ICard card)
        {
            _cards.Add(card);
        }
        public virtual void Draw(int x, int y)
        {
            for (int i = 0; i < _cards.Count; i++)
            { 
                cardHand.DrawMethod(x, y);
                x++;  
            }
        }
    }
}
