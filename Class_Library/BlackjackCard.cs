using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public class BlackjackCard : Cards
    {
        public int Value
        {
            get
            { return (int)Face; }
            set
            { Value = value; }
        }

        public BlackjackCard(CardFace face, CardSuit suit) : base(face, suit)
        {
            int num = 0;
            switch(num)
            {
                case (int)CardFace.K:
                    Value = 10; 
                    break;
                case (int)CardFace.Q:
                    Value = 10;
                    break;
                case (int)CardFace.J:
                    Value = 10;
                    break;
                case (int)CardFace.Ten:
                    Value = 10;
                    break;
                case (int)CardFace.Nine:
                    Value = 9;
                    break;
                case (int)CardFace.Eight:
                    Value = 8;
                    break;
                case (int)CardFace.Seven:
                    Value = 7;
                    break;
                case (int)CardFace.Six:
                    Value = 6;
                    break;
                case (int)CardFace.Five:
                    Value = 5;
                    break;
                case (int)CardFace.Four:
                    Value = 4;
                    break;
                case (int)CardFace.Three:
                    Value = 3;
                    break;
                case (int)CardFace.Two:
                    Value = 2;
                    break;
                case (int)CardFace.A:
                    Value = 1;
                    break;     
            }
        }

    }
}
