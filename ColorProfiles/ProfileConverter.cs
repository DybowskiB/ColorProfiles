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
        // Convert sourceProfile => targetProfile
        private ColorProfile sourceProfile;
        private ColorProfile targetProfile;

        // SrSgSb vectors
        private Vector<double> SrSgSbSrc;
        private Vector<double> SrSgSbTrg;

        // Matrices used during conversion
        private Matrix<double> toXYZMatrix;
        private Matrix<double> toRGBMatrix;

        // Bradford Matrix
        private Matrix<double> BradfordMatrix;
        public ProfileConverter(ColorProfile sourceProfile, ColorProfile targetProfile)
        {
            // Initialize profiles
            this.sourceProfile = sourceProfile;
            this.targetProfile = targetProfile;

            // Comute SrSgSb vectors from profiles
            SrSgSbSrc = GetSrSgSb(sourceProfile);
            SrSgSbTrg = GetSrSgSb(targetProfile);

            // Compute conversion matrices
            // RGB => XYZ
            toXYZMatrix = Matrix<double>.Build.DenseOfArray(new double[,] {
                { sourceProfile.Red.X * SrSgSbSrc[0], sourceProfile.Green.X * SrSgSbSrc[1], sourceProfile.Blue.X * SrSgSbSrc[2]},
                { sourceProfile.Red.Y * SrSgSbSrc[0], sourceProfile.Green.Y * SrSgSbSrc[1], sourceProfile.Blue.Y * SrSgSbSrc[2]},
                { sourceProfile.Red.Z * SrSgSbSrc[0], sourceProfile.Green.Z * SrSgSbSrc[1], sourceProfile.Blue.Z * SrSgSbSrc[2]}
            });
            // XYZ => RGB
            toRGBMatrix = Matrix<double>.Build.DenseOfArray(new double[,] {
                { targetProfile.Red.X * SrSgSbTrg[0], targetProfile.Green.X * SrSgSbTrg[1], targetProfile.Blue.X * SrSgSbTrg[2]},
                { targetProfile.Red.Y * SrSgSbTrg[0], targetProfile.Green.Y * SrSgSbTrg[1], targetProfile.Blue.Y * SrSgSbTrg[2]},
                { targetProfile.Red.Z * SrSgSbTrg[0], targetProfile.Green.Z * SrSgSbTrg[1], targetProfile.Blue.Z * SrSgSbTrg[2]}
            }).Inverse();

            // Compute Bradford matrix if necessary
            if (sourceProfile.White != targetProfile.White)
                BradfordMatrix = ComputeBradfordMatrix();
        }
        public Color Convert(Color color)
        {
            return ConvertToRGB(ConvertToXYZ(color));
        }

        private Vector<double> ConvertToXYZ(Color color)
        {
            var RGB = Vector<double>.Build.Dense(new double[] {
                Math.Pow((double) color.R / 255, sourceProfile.Gamma),
                Math.Pow((double) color.G / 255, sourceProfile.Gamma),
                Math.Pow((double) color.B / 255, sourceProfile.Gamma) });

            // Exclude special cases
            Vector<double> XYZ;
            if (RGB[0] == 1 && RGB[1] == 0 && RGB[2] == 0)
                return Vector<double>.Build.Dense(new double[] { sourceProfile.Red.X, sourceProfile.Red.Y, sourceProfile.Red.Z });
            else if (RGB[0] == 0 && RGB[1] == 1 && RGB[2] == 0)
                return Vector<double>.Build.Dense(new double[] { sourceProfile.Green.X, sourceProfile.Green.Y, sourceProfile.Green.Z });
            else if (RGB[0] == 0 && RGB[1] == 0 && RGB[2] == 1)
                return Vector<double>.Build.Dense(new double[] { sourceProfile.Blue.X, sourceProfile.Blue.Y, sourceProfile.Blue.Z });
            else if (RGB[0] == 1 && RGB[1] == 1 && RGB[0] == 1)
                return Vector<double>.Build.Dense(new double[] { sourceProfile.White.X * (1 / sourceProfile.White.Y),
                    1, sourceProfile.White.Z * (1 / sourceProfile.White.Y) });

            // Multiply matrix and vector
            XYZ = toXYZMatrix * RGB;
            return Vector<double>.Build.Dense(new double[] { XYZ[0], XYZ[1], XYZ[2] });
        }

        private Color ConvertToRGB(Vector<double> XYZ)
        {
            if (sourceProfile.White != targetProfile.White)
            {
                // Compute XYZ measured with other iluminant
                XYZ = BradfordMatrix * XYZ;
            }

            // Get RGB values
            var RGB = toRGBMatrix * XYZ;

            // Include gamma correction
            RGB = Vector<double>.Build.Dense(new double[] {
                Math.Pow((double) RGB[0], 1 / targetProfile.Gamma),
                Math.Pow((double) RGB[1], 1 / targetProfile.Gamma),
                Math.Pow((double) RGB[2], 1 / targetProfile.Gamma) });
            int R = RGB[0] >= 0 ? Math.Min((int)(RGB[0] * 255), 255) : 0;
            int G = RGB[1] >= 0 ? Math.Min((int)(RGB[1] * 255), 255) : 0;
            int B = RGB[2] >= 0 ? Math.Min((int)(RGB[2] * 255), 255) : 0;
            var color = Color.FromArgb(R, G, B);

            return color;
        }

        private Vector<double> GetSrSgSb(ColorProfile colorProfile)
        {
            // Get white point X,Y,Z 
            double Yw = 1;
            double Xw = colorProfile.White.X * (Yw / colorProfile.White.Y);
            double Zw = colorProfile.White.Z * (Yw / colorProfile.White.Y);

            // Solve equation system to get Sr, SG, Sb
            var A = Matrix<double>.Build.DenseOfArray(new double[,] {
                { colorProfile.Red.X, colorProfile.Green.X, colorProfile.Blue.X},
                { colorProfile.Red.Y, colorProfile.Green.Y, colorProfile.Blue.Y},
                { colorProfile.Red.Z, colorProfile.Green.Z, colorProfile.Blue.Z}
            });
            var XwYwZw = Vector<double>.Build.Dense(new double[] { Xw / Yw, Yw, Zw / Yw });
            return A.SolveIterative(XwYwZw, new MlkBiCgStab());
        }

        private Matrix<double> ComputeBradfordMatrix()
        {
            // Coordinates of destination and source white
            var XYZdw = Vector<double>.Build.Dense(new double[] { targetProfile.White.X * (1 / targetProfile.White.Y), 1, 
                                                                  targetProfile.White.Z * (1 / targetProfile.White.Y) });
            var XYZsw = Vector<double>.Build.Dense(new double[] { sourceProfile.White.X * (1 / sourceProfile.White.Y), 1, 
                                                                  sourceProfile.White.Z * (1 / sourceProfile.White.Y) });
            // Cone response matrix
            var ConResMatrix = Matrix<double>.Build.DenseOfArray(new double[,] {
                { 0.8951, 0.2664, -0.1614},
                { -0.7502, 1.7135, 0.0367},
                { 0.0389, -0.0685, 1.0296}
                });
            // Inverse cone response matrix
            var InvConResMatrix = Matrix<double>.Build.DenseOfArray(new double[,] {
                { 0.9870, -0.1471, 0.1600},
                { 0.4323, 0.5184, 0.0493},
                { -0.0085, 0.0400, 0.9685}
                });

            // Destination white RGB
            var RGBdw = ConResMatrix * XYZdw;
            // Source white RGB
            var RGBsw = ConResMatrix * XYZsw;
            // Diagonal matrix
            var diagMatrix = Matrix<double>.Build.DenseOfArray(new double[,] {
                { RGBdw[0] / RGBsw[0], 0, 0},
                { 0, RGBdw[1] / RGBsw[1], 0},
                { 0, 0, RGBdw[2] / RGBsw[2]}
            });
            //// Compute Bradford matrix
            var BradfordMatrix = InvConResMatrix * diagMatrix * ConResMatrix;

            return BradfordMatrix;
        }
    }
}
