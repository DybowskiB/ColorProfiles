using System;
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

        public MainWindow()
        {
            InitializeComponent();

            sourcePictureBox.Image = Image.FromFile(defaultPicturePath);

            // Initialize picturebox with default picture
            InitializePictureBox(defaultPicturePath, sourcePictureBox);
            InitializePictureBox(defaultPicturePath, targetPictureBox);

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
                    targetPictureBox.Image = new Bitmap(Image.FromFile(dlg.FileName),
                        sourcePictureBox.Width, sourcePictureBox.Height);
                }
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {

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
            sourceColorProfile = new NewColorProfile(sourceColorProfile);
            HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetGamma,
                profileSourceComboBox, ValidateGamma);
        }

        private void gammaTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            targetColorProfile = new NewColorProfile(targetColorProfile);
            HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetGamma,
                profileTargetComboBox, ValidateGamma);
        }

        private void xWhiteSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            sourceColorProfile = new NewColorProfile(sourceColorProfile);
            HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetWhiteX,
                profileSourceComboBox, ValidateXY);
        }

        private void xRedSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            sourceColorProfile = new NewColorProfile(sourceColorProfile);
            HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetRedX,
                profileSourceComboBox, ValidateXY);
        }

        private void yWhiteSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            sourceColorProfile = new NewColorProfile(sourceColorProfile);
            HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetWhiteY,
                profileSourceComboBox, ValidateXY);
        }

        private void xBlueSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            sourceColorProfile = new NewColorProfile(sourceColorProfile);
            HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetBlueX,
                profileSourceComboBox, ValidateXY);
        }

        private void xGreenSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            sourceColorProfile = new NewColorProfile(sourceColorProfile);
            HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetGreenX,
                profileSourceComboBox, ValidateXY);
        }

        private void yBlueSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            sourceColorProfile = new NewColorProfile(sourceColorProfile);
            HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetBlueY,
                profileSourceComboBox, ValidateXY);
        }

        private void yGreenSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            sourceColorProfile = new NewColorProfile(sourceColorProfile);
            HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetGreenY,
                profileSourceComboBox, ValidateXY);
        }

        private void yRedSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            sourceColorProfile = new NewColorProfile(sourceColorProfile);
            HandleTextChanged((TextBox)sender, sourceColorProfile, (sourceColorProfile as NewColorProfile).SetRedY,
                profileSourceComboBox, ValidateXY);
        }

        private void xBlueTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            targetColorProfile = new NewColorProfile(targetColorProfile);
            HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetBlueX,
                profileTargetComboBox, ValidateXY);
        }

        private void xGreenTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            targetColorProfile = new NewColorProfile(targetColorProfile);
            HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetGreenX,
                profileTargetComboBox, ValidateXY);
        }

        private void xRedTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            targetColorProfile = new NewColorProfile(targetColorProfile);
            HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetRedX,
                profileTargetComboBox, ValidateXY);
        }

        private void xWhiteTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            targetColorProfile = new NewColorProfile(targetColorProfile);
            HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetWhiteX,
                profileTargetComboBox, ValidateXY);
        }

        private void yBlueTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            targetColorProfile = new NewColorProfile(targetColorProfile);
            HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetBlueY,
                profileTargetComboBox, ValidateXY);
        }

        private void yGreenTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            targetColorProfile = new NewColorProfile(targetColorProfile);
            HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetGreenY,
                profileTargetComboBox, ValidateXY);
        }

        private void yRedTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            targetColorProfile = new NewColorProfile(targetColorProfile);
            HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetRedY,
                profileTargetComboBox, ValidateXY);
        }

        private void yWhiteTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            targetColorProfile = new NewColorProfile(targetColorProfile);
            HandleTextChanged((TextBox)sender, targetColorProfile, (targetColorProfile as NewColorProfile).SetWhiteY,
                profileTargetComboBox, ValidateXY);
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
                xBlueSourceTextBox, yBlueSourceTextBox, sourceColorProfile, profileSourceComboBox);
        }

        private void profileTargetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeProfile(gammaTargetTextBox, xWhiteTargetTextBox, yWhiteTargetTextBox,
                xRedTargetTextBox, yRedTargetTextBox, xGreenTargetTextBox, yGreenTargetTextBox,
                xBlueTargetTextBox, yBlueTargetTextBox, targetColorProfile, profileTargetComboBox);
        }

        private void ChangeProfile(TextBox gamma, TextBox xW, TextBox yW, TextBox xR, TextBox yR,
            TextBox xG, TextBox yG, TextBox xB, TextBox yB, ColorProfile profile, ComboBox comboBox)
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
            gamma.Text = profile.Gamma.ToString();
            xW.Text = profile.White.X.ToString();
            yW.Text = profile.White.Y.ToString();
            xR.Text = profile.Red.X.ToString();
            yR.Text = profile.Red.Y.ToString();
            xG.Text = profile.Green.X.ToString();
            yG.Text = profile.Green.Y.ToString();
            xB.Text = profile.Blue.X.ToString();
            yB.Text = profile.Blue.Y.ToString();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            changeProfileFlag = true;
        }
    }
}
