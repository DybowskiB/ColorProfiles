using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorProfiles
{
    public class sRGB : ColorProfile
    {
        public sRGB() : base(2.2, new ColorXY(0.312730, 0.329020), new ColorXY(0.64, 0.33),
                new ColorXY(0.3, 0.6), new ColorXY(0.15, 0.06))
        { }
    }

    public class AdobeRGB : ColorProfile
    {
        public AdobeRGB() : base(2.2, new ColorXY(0.312730, 0.329020), new ColorXY(0.64, 0.33),
                new ColorXY(0.21, 0.71), new ColorXY(0.15, 0.6))
        { }
    }

    public class AppleRGB : ColorProfile
    {
        public AppleRGB() : base(1.8, new ColorXY(0.312730, 0.329020), new ColorXY(0.625, 0.34),
                new ColorXY(0.28, 0.595), new ColorXY(0.155, 0.7))
        { }
    }

    public class CIERGB : ColorProfile
    {
        public CIERGB() : base(2.2, new ColorXY(0.333333, 0.333333), new ColorXY(0.64, 0.33),
                new ColorXY(0.3, 0.6), new ColorXY(0.15, 0.6))
        { }
    }

    public class WideGamut : ColorProfile
    {
        public WideGamut() : base(2.2, new ColorXY(0.345670, 0.358500), new ColorXY(0.735, 0.265),
                new ColorXY(0.274, 0.717), new ColorXY(0.167, 0.007))
        { }
    }

    public class NewColorProfile : ColorProfile
    {
        private const double GammaDefault = 1;
        private const double XYColorDefault = 0.5;

        public NewColorProfile()
            : this(GammaDefault, XYColorDefault, XYColorDefault, XYColorDefault, XYColorDefault,
                  XYColorDefault, XYColorDefault, XYColorDefault, XYColorDefault)
        { }

        public NewColorProfile(ColorProfile colorProfile)
            : base(colorProfile)
        { }

        public NewColorProfile(double gamma, double xw, double yw, double xr, double yr, double xg, double yg,
            double xb, double yb) 
            : base(gamma, new ColorXY(xw, yw), new ColorXY(xr, yr), new ColorXY(xg, yg), new ColorXY(xb, yb))
        { }

        public void SetGamma(double gamma) => this.Gamma = gamma;

        public void SetWhiteX(double x) => this.White.X = x;
        public void SetWhiteY(double y) => this.White.Y = y;

        public void SetRedX(double x) => this.Red.X = x;
        public void SetRedY(double y) => this.Red.Y = y;
        public void SetGreenX(double x) => this.Green.X = x;
        public void SetGreenY(double y) => this.Green.Y = y;
        public void SetBlueX(double x) => this.Blue.X = x;
        public void SetBlueY(double y) => this.Blue.Y = y;
    }
}
