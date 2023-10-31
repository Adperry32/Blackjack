using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public class BlackjackCard : Cards
    {
        public int Value { get; set; }
      
        

        public BlackjackCard(CardFace face, CardSuit suit) : base(face, suit)
        {
           
            switch(face)
            {
                case CardFace.K:
                case CardFace.Q:
                case CardFace.J:   
                case CardFace.Ten:
                    Value = 10;
                    break;

                case CardFace.Nine:
                    Value = 9;
                    break;
                case CardFace.Eight:
                    Value = 8;
                    break;
                case CardFace.Seven:
                    Value = 7;
                    break;
                case CardFace.Six:
                    Value = 6;
                    break;
                case CardFace.Five:
                    Value = 5;
                    break;
                case CardFace.Four:
                    Value = 4;
                    break;
                case CardFace.Three:
                    Value = 3;
                    break;
                case CardFace.Two:
                    Value = 2;
                    break;
                case CardFace.A:
                    Value = 1;
                    break;     
            }
        }

    }
}
