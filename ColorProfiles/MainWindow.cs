using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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

        public MainWindow()
        {
            InitializeComponent();

            sourcePictureBox.Image = Image.FromFile(defaultPicturePath);

            // Initialize picturebox with default picture
            InitializePictureBox(defaultPicturePath, sourcePictureBox);
            InitializePictureBox(defaultPicturePath, targetPictureBox);

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
            using (SaveFileDialog dlg = new SaveFileDialog() { Filter = @"Images (*.jpg,*.png,*.jpeg)|*.jpg;*.png;*.jpeg"})
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

        private void gammaTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateGamma(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void xWhiteSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void xRedSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void yWhiteSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void xBlueSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void xGreenSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void yBlueSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void yGreenSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void yRedSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void xBlueTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void xGreenTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void xRedTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void xWhiteTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void yBlueTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void yGreenTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void yRedTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void yWhiteTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateXY(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }

        private void textBoxSourceGamma_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (ValidateGamma(textBox))
            {

                generateButton.Enabled = true;
            }
            else
                generateButton.Enabled = false;
        }
    }
}
