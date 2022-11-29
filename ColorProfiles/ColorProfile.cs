using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorProfiles
{
    public class ColorProfile
    {
        public double Gamma { get; protected set; }

        public class ColorXY
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }

            public ColorXY(double x, double y)
            {
                X = x;
                Y = y;
                Z = 1 - x - y;
            }
        }

        public ColorXY White { get; protected set; }
        public ColorXY Red { get; protected set; }
        public ColorXY Green { get; protected set; }
        public ColorXY Blue { get; protected set; }

        public ColorProfile(ColorProfile colorProfile) 
            : this(colorProfile.Gamma, colorProfile.White, colorProfile.Red, 
                  colorProfile.Green, colorProfile.Blue)
        { }

        public ColorProfile(double gamma, ColorXY white, ColorXY red, ColorXY green, ColorXY blue)
        {
            Gamma = gamma;
            White = white;
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}
