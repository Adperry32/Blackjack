using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public static class Factory
    {
        public static ICard CreateCard(CardFace face, CardSuit suit)
        { 
            ICard build = new Cards(face,suit);
            return build;
        }
        public static ICard CreateBlackjackCard(CardFace face, CardSuit suit)
        {
            ICard blackJackBuild = new BlackjackCard(face, suit);
            return blackJackBuild;
        }
    }
}
