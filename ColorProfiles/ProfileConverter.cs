using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double.Solvers;

namespace ColorProfiles
{
    public class ProfileConverter
    {
        private ColorProfile sourceProfile;
        private ColorProfile targetProfile;
        public ProfileConverter(ColorProfile sourceProfile, ColorProfile targetProfile)
        {
            this.sourceProfile = sourceProfile;
            this.targetProfile = targetProfile;
        }
        public Color Convert(Color color)
        {
            return ConvertToRGB(ConvertToXYZ(color));
        }

        private (double X, double Y, double Z) ConvertToXYZ(Color color)
        {
            // Get white point X,Y,Z 
            double Yw = 1;
            double Xw = sourceProfile.White.X * (Yw / sourceProfile.White.Y);
            double Zw = (1 - sourceProfile.White.X - sourceProfile.White.Y) * (Yw / sourceProfile.White.Y);

            // Solve equation system to get Sr, SG, Sb
            var A = Matrix<double>.Build.DenseOfArray(new double[,] {
                { sourceProfile.Red.X, sourceProfile.Green.X, sourceProfile.Blue.X},
                { sourceProfile.Red.Y, sourceProfile.Green.Y, sourceProfile.Blue.Y},
                { sourceProfile.Red.Z, sourceProfile.Green.Z, sourceProfile.Blue.Z}
            });
            var XwYwZw = Vector<double>.Build.Dense(new double[] { Xw / Yw, Yw, Zw / Yw });
            var SrSgSb = A.SolveIterative(XwYwZw, new MlkBiCgStab());

            var RGB = Vector<double>.Build.Dense(new double[] {
                Math.Pow((double) color.R / 255, sourceProfile.Gamma),
                Math.Pow((double) color.G / 255, sourceProfile.Gamma),
                Math.Pow((double) color.B / 255, sourceProfile.Gamma) });

            // Exclude special cases
            Vector<double> XYZ;
            if (RGB[0] == 1 && RGB[1] == 0 && RGB[2] == 0)
                return (sourceProfile.Red.X, sourceProfile.Red.Y, sourceProfile.Red.Z);
            else if (RGB[0] == 0 && RGB[1] == 1 && RGB[2] == 0)
                return (sourceProfile.Green.X, sourceProfile.Green.Y, sourceProfile.Green.Z);
            else if (RGB[0] == 0 && RGB[1] == 0 && RGB[2] == 1)
                return (sourceProfile.Blue.X, sourceProfile.Blue.Y, sourceProfile.Blue.Z);
            else if (RGB[0] == 1 && RGB[1] == 1 && RGB[0] == 1)
                return (Xw, 1, Zw);

            // Multiply matrix and vector
            var B = Matrix<double>.Build.DenseOfArray(new double[,] {
                { sourceProfile.Red.X * SrSgSb[0], sourceProfile.Green.X * SrSgSb[1], sourceProfile.Blue.X * SrSgSb[2]},
                { sourceProfile.Red.Y * SrSgSb[0], sourceProfile.Green.Y * SrSgSb[1], sourceProfile.Blue.Y * SrSgSb[2]},
                { sourceProfile.Red.Z * SrSgSb[0], sourceProfile.Green.Z * SrSgSb[1], sourceProfile.Blue.Z * SrSgSb[2]}
            });
            XYZ = B * RGB;
            return (XYZ[0], XYZ[1], XYZ[2]);
        }

        private Color ConvertToRGB((double X, double Y, double Z) XYZ)
        {
            return Color.White;
        }
    }
}
