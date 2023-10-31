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
        protected List<ICard> _cards = new List<ICard>();

        public virtual void AddCard(ICard card)
        {
            _cards.Add(card);
        }
        public virtual void Draw(int x, int y)
        {
         foreach (ICard card in _cards)
            {
                card.DrawMethod(x, y);
                x++;
            }
        }
    }
}
