﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;

namespace ColorProfiles
{
    public partial class MainWindow : Form
    {
        // Default picture
        // Path: "ColorProfiles\ColorProfiles\Resources\picture1.jpg"
        private const string defaultPicturePath = "..\\..\\Resources\\picture1.jpg";

        // Profiles
        private ColorProfile sourceColorProfile;
        private ColorProfile targetColorProfile;

        // Auxiliry flag
        private bool changeProfileFlag = false;
        private bool textChangedFlag = false;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize picturebox with default picture
            InitializePictureBox(defaultPicturePath, sourcePictureBox);

            // Initialize Picture objects
            sourceColorProfile = new sRGB();
            targetColorProfile = new sRGB();

            // Initialize selected profiles
            profileSourceComboBox.SelectedIndex = 0;
            profileTargetComboBox.SelectedIndex = 0;
        }


        // Resize pictureBox
        private void InitializePictureBox(string path, PictureBox pictureBox)
        {
            Image myImage = Image.FromFile(path, true);
            int width = 500;
            double ratio = (double)myImage.Width / (double)myImage.Height;
            int height = Convert.ToInt32(width / ratio);

            if (height > width)
            {
                ratio = (double)myImage.Height / (double)myImage.Width;
                height = width;
                width = Convert.ToInt32(height / ratio);
            }
            pictureBox.Image = ResizeImage(myImage, width, height);
        }

        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
                }
            }

            return destImage;
        }


        // Events
        private void loadPictureButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Load picture";
                dlg.Filter = "Images (*.jpg,*.png,*.jpeg)|*.jpg;*.png;*.jpeg";
                dlg.InitialDirectory = "..\\..\\Resources";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    sourcePictureBox.Image = new Bitmap(Image.FromFile(dlg.FileName),
                        sourcePictureBox.Width, sourcePictureBox.Height);
                    targetPictureBox.Image = null;

                    // Disable saving (targetPictureBox is empty)
                    saveButton.Enabled = false;
                }
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            Bitmap sourceBitmap = new Bitmap(sourcePictureBox.Image);
            Bitmap targetBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            ProfileConverter converter = new ProfileConverter(sourceColorProfile, targetColorProfile);
            for(int x = 0; x < sourceBitmap.Width; ++x)
            {
                for(int y = 0; y < sourceBitmap.Height; ++y)
                {
                    Color sourceColor = sourceBitmap.GetPixel(x, y);
                    targetBitmap.SetPixel(x, y, converter.Convert(sourceColor));
                }
            }

            targetPictureBox.Image = targetBitmap;
            sourceBitmap.Dispose();

            // Enable saving
            saveButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog() { Filter = @"Images (*.jpg,*.png,*.jpeg)|*.jpg;*.png;*.jpeg" })
            {
                dlg.Title = "Save file";
                dlg.ValidateNames = true;
                dlg.CheckPathExists = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    targetPictureBox.Image.Save(dlg.FileName);
                }
            }
        }

        private void grayButton_Click(object sender, EventArgs e)
        {
            Bitmap sourceBitmap;
            if (targetPictureBox.Image == null)
                sourceBitmap = new Bitmap(sourcePictureBox.Image);
            else
                sourceBitmap = new Bitmap(targetPictureBox.Image);
            Bitmap targetBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            for (int x = 0; x < sourceBitmap.Width; ++x)
            {
                for (int y = 0; y < sourceBitmap.Height; ++y)
                {
                    Color sourceColor = sourceBitmap.GetPixel(x, y);
                    // Grayscale weighted average, Y = 0.299 * R + 0.587 * G + 0.114 * B
                    int Y = (int)Math.Round(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
                    targetBitmap.SetPixel(x, y, Color.FromArgb(Y, Y, Y));
                }
            }
            targetPictureBox.Image = targetBitmap;
            sourceBitmap.Dispose();

            // Enable saving
            saveButton.Enabled = true;
        }

        private bool ValidateXY(TextBox textBox)
        {
            return CheckIfNumber(textBox) && CheckIfNumberIsBetweenRange(textBox, 0, 1);
        }

        private bool ValidateGamma(TextBox textBox)
        {
            return CheckIfNumber(textBox) && CheckIfNumberIsBetweenRange(textBox, 0, double.PositiveInfinity);
        }

        private bool CheckIfNumber(TextBox textBox)
        {
            Regex regex = new Regex("^[0-9][,]*[0-9]*$");
            if (!regex.IsMatch(textBox.Text))
            {
                errorProvider.SetError(textBox, "It has to be a number!");
                return false;
            }
            else
                errorProvider.SetError(textBox, "");
            return true;
        }

        private bool CheckIfNumberIsBetweenRange(TextBox textBox, double a, double b)
        {
            double number = double.Parse(textBox.Text);
            if (a > number || number > b)
            {
                errorProvider.SetError(textBox, "It has to be a [" + a + ";" + b + " number!");
                return false;
            }
            else
                errorProvider.SetError(textBox, "");
            return true;
        }

        private void gammaSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetGamma,
                    profileSourceComboBox, ValidateGamma);
            }
        }

        private void gammaTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetGamma,
                    profileTargetComboBox, ValidateGamma);
            }
        }

        private void xWhiteSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetWhiteX,
                    profileSourceComboBox, ValidateXY);
            }
        }

        private void xRedSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetRedX,
                    profileSourceComboBox, ValidateXY);
            }
        }

        private void yWhiteSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetWhiteY,
                    profileSourceComboBox, ValidateXY);
            }
        }

        private void xBlueSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetBlueX,
                    profileSourceComboBox, ValidateXY);
            }
        }

        private void xGreenSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetGreenX,
                    profileSourceComboBox, ValidateXY);
            }
        }

        private void yBlueSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetBlueY,
                    profileSourceComboBox, ValidateXY);
            }
        }

        private void yGreenSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetGreenY,
                    profileSourceComboBox, ValidateXY);
            }
        }

        private void yRedSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetRedY,
                    profileSourceComboBox, ValidateXY);
            }
        }

        private void xBlueTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetBlueX,
                    profileTargetComboBox, ValidateXY);
            }
        }

        private void xGreenTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetGreenX,
                    profileTargetComboBox, ValidateXY);
            }
        }

        private void xRedTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetRedX,
                    profileTargetComboBox, ValidateXY);
            }
        }

        private void xWhiteTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetWhiteX,
                    profileTargetComboBox, ValidateXY);
            }
        }

        private void yBlueTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetBlueY,
                    profileTargetComboBox, ValidateXY);
            }
        }

        private void yGreenTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetGreenY,
                    profileTargetComboBox, ValidateXY);
            }
        }

        private void yRedTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetRedY,
                    profileTargetComboBox, ValidateXY);
            }
        }

        private void yWhiteTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetWhiteY,
                    profileTargetComboBox, ValidateXY);
            }
        }

        private void HandleTextChanged(TextBox textBox, ColorProfile colorProfile, Action<double> func, 
            ComboBox comboBox, Func<TextBox, bool> validation)
        {
            if (validation(textBox))
            {
                double val = double.Parse(textBox.Text);
                func(val);
                if (changeProfileFlag)
                {
                    comboBox.SelectedItem = "New";
                    changeProfileFlag = false;
                }
                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void profileSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeProfile(gammaSourceTextBox, xWhiteSourceTextBox, yWhiteSourceTextBox,
                xRedSourceTextBox, yRedSourceTextBox, xGreenSourceTextBox, yGreenSourceTextBox,
                xBlueSourceTextBox, yBlueSourceTextBox, ref sourceColorProfile, profileSourceComboBox);
        }

        private void profileTargetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeProfile(gammaTargetTextBox, xWhiteTargetTextBox, yWhiteTargetTextBox,
                xRedTargetTextBox, yRedTargetTextBox, xGreenTargetTextBox, yGreenTargetTextBox,
                xBlueTargetTextBox, yBlueTargetTextBox, ref targetColorProfile, profileTargetComboBox);
        }

        private void ChangeProfile(TextBox gamma, TextBox xW, TextBox yW, TextBox xR, TextBox yR,
            TextBox xG, TextBox yG, TextBox xB, TextBox yB, ref ColorProfile profile, ComboBox comboBox)
        {
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    profile = new sRGB();
                    break;
                case 1:
                    profile = new AdobeRGB();
                    break;
                case 2:
                    profile = new AppleRGB();
                    break;
                case 3:
                    profile = new CIERGB();
                    break;
                case 4:
                    profile = new WideGamut();
                    break;
                case 5:
                    profile = new NewColorProfile(profile);
                    break;
            }
            textChangedFlag = false;
            gamma.Text = profile.Gamma.ToString();
            xW.Text = profile.White.X.ToString();
            yW.Text = profile.White.Y.ToString();
            xR.Text = profile.Red.X.ToString();
            yR.Text = profile.Red.Y.ToString();
            xG.Text = profile.Green.X.ToString();
            yG.Text = profile.Green.Y.ToString();
            xB.Text = profile.Blue.X.ToString();
            yB.Text = profile.Blue.Y.ToString();
            textChangedFlag = true;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            changeProfileFlag = true;
        }
    }
}
