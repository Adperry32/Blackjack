using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public interface ICard
    {
        CardFace Face { get; }
        CardSuit Suit { get; }
        void DrawMethod(int x, int y); 
    }
}
