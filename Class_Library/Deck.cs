using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Class_Library
{
    public class Deck
    {

        private List<ICard> _cards = new List<ICard>();
        public Deck()
        {
            _cards = FreshDeck();
        }
        public List<ICard> FreshDeck()
        {
            List<ICard> deck = new List<ICard>();
            for (int i = 1; i < 14; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    deck.Add(Factory.CreateBlackjackCard((CardFace)i, ((CardSuit)j)));
                }
            }
            return deck;
        }
        public List<ICard> Deal(int dealAmount)
        {
            List<ICard> deal = new List<ICard>();
            if (_cards.Count >= dealAmount)
            {
                if (dealAmount > 1)
                {
                    deal.Add(_cards[0]);
                    deal.Add(_cards[1]);
                    _cards.RemoveRange(0, 2);
                }
                else
                {
                    deal.Add(_cards[0]);
                    _cards.RemoveRange(0, 1);
                }

            }
            else
            {
                _cards = FreshDeck();
                Shuffle();
                Console.WriteLine(" Shuffling Deck");
                Thread.Sleep(1000);
            }

            return deal;
        }

        public void Shuffle()
        {
            Random rando = new Random();
            int i = _cards.Count;
            while (i > 1)
            {
                i--;
                int j = rando.Next(i + 1);
                ICard card = _cards[j];
                _cards[j] = _cards[i];
                _cards[i] = card;
            }

        }
        public List<ICard> GetShuffledDeck()
        {
            Shuffle();
            return _cards.ToList();
        }
    }
}
