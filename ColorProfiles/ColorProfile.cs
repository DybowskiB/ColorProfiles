using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
                Z = 1 - (x + y);
            }

            public ColorXY(ColorXY color)
                : this(color.X, color.Y)
            { }

            public static bool operator==(ColorXY color1, ColorXY color2)
            {
                return color1.X == color2.X && color1.Y == color2.Y;
            }

            public static bool operator!=(ColorXY color1, ColorXY color2)
            {
                return !(color1 == color2);
            }

            public override bool Equals(object obj)
            {
                return this == (ColorXY)obj;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
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
            White = new ColorXY(white);
            Red = new ColorXY(red);
            Green = new ColorXY(green);
            Blue = new ColorXY(blue);
        }
    }
}
