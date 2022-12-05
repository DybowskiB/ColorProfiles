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

        // Block generate
        private Dictionary<(int, TextBox), bool> blockGenerateHashSet;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize picturebox with default picture
            sourcePictureBox.Image = new Bitmap(Image.FromFile(defaultPicturePath),
                        sourcePictureBox.Width, sourcePictureBox.Height);

            // Initialize Picture objects
            sourceColorProfile = new sRGB();
            targetColorProfile = new sRGB();

            // Initialize selected profiles
            profileSourceComboBox.SelectedIndex = 0;
            profileTargetComboBox.SelectedIndex = 0;

            // Initialize set required to validation
            InitializeValidationSet();
        }

        // Validation

        private void InitializeValidationSet()
        {
            blockGenerateHashSet = new Dictionary<(int, TextBox), bool>();
            blockGenerateHashSet.Add((0, xWhiteSourceTextBox), false);
            blockGenerateHashSet.Add((0, yWhiteSourceTextBox), false);
            blockGenerateHashSet.Add((0, xRedSourceTextBox), false);
            blockGenerateHashSet.Add((0, yRedSourceTextBox), false);
            blockGenerateHashSet.Add((0, xGreenSourceTextBox), false);
            blockGenerateHashSet.Add((0, yGreenSourceTextBox), false);
            blockGenerateHashSet.Add((0, xBlueSourceTextBox), false);
            blockGenerateHashSet.Add((0, yBlueSourceTextBox), false);
            blockGenerateHashSet.Add((0, xWhiteTargetTextBox), false);
            blockGenerateHashSet.Add((0, yWhiteTargetTextBox), false);
            blockGenerateHashSet.Add((0, xRedTargetTextBox), false);
            blockGenerateHashSet.Add((0, yRedTargetTextBox), false);
            blockGenerateHashSet.Add((0, xGreenTargetTextBox), false);
            blockGenerateHashSet.Add((0, yGreenTargetTextBox), false);
            blockGenerateHashSet.Add((0, xBlueTargetTextBox), false);
            blockGenerateHashSet.Add((0, yBlueTargetTextBox), false);
            blockGenerateHashSet.Add((1, xWhiteSourceTextBox), false);
            blockGenerateHashSet.Add((1, yWhiteSourceTextBox), false);
            blockGenerateHashSet.Add((1, xRedSourceTextBox), false);
            blockGenerateHashSet.Add((1, yRedSourceTextBox), false);
            blockGenerateHashSet.Add((1, xGreenSourceTextBox), false);
            blockGenerateHashSet.Add((1, yGreenSourceTextBox), false);
            blockGenerateHashSet.Add((1, xBlueSourceTextBox), false);
            blockGenerateHashSet.Add((1, yBlueSourceTextBox), false);
            blockGenerateHashSet.Add((1, xWhiteTargetTextBox), false);
            blockGenerateHashSet.Add((1, yWhiteTargetTextBox), false);
            blockGenerateHashSet.Add((1, xRedTargetTextBox), false);
            blockGenerateHashSet.Add((1, yRedTargetTextBox), false);
            blockGenerateHashSet.Add((1, xGreenTargetTextBox), false);
            blockGenerateHashSet.Add((1, yGreenTargetTextBox), false);
            blockGenerateHashSet.Add((1, xBlueTargetTextBox), false);
            blockGenerateHashSet.Add((1, yBlueTargetTextBox), false);
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
            Regex regex = new Regex("^[0-9]+[,]*[0-9]*$");
            if (!regex.IsMatch(textBox.Text))
            {
                errorProvider.SetError(textBox, "It has to be a number!");
                return false;
            }
            else
                errorProvider.SetError(textBox, "");
            return true;
        }

        private bool ValidateSum(TextBox textBox, TextBox textBox2)
        {
            try
            {
                double val1 = double.Parse(textBox.Text);
                double val2 = double.Parse(textBox2.Text);

                if (val1 + val2 < 0 || val1 + val2 > 1)
                {
                    errorProvider.SetError(textBox, "0 <= x + y <= 1 condition must be held!");
                    errorProvider.SetError(textBox2, "0 <= x + y <= 1 condition must be held!");
                    return false;
                }
                else
                {
                    errorProvider.SetError(textBox, "");
                    errorProvider.SetError(textBox2, "");
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
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
                HandleTextChanged((TextBox)sender, (sourceColorProfile as NewColorProfile).SetGamma,
                    profileSourceComboBox, ValidateGamma);
            }
        }

        private void gammaTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, (targetColorProfile as NewColorProfile).SetGamma,
                    profileTargetComboBox, ValidateGamma);
            }
        }

        private void xWhiteSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, (sourceColorProfile as NewColorProfile).SetWhiteX,
                    profileSourceComboBox, ValidateXY, yWhiteSourceTextBox);
            }
        }

        private void xRedSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, (sourceColorProfile as NewColorProfile).SetRedX,
                    profileSourceComboBox, ValidateXY, yRedSourceTextBox);
            }
        }

        private void yWhiteSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, (sourceColorProfile as NewColorProfile).SetWhiteY,
                    profileSourceComboBox, ValidateXY, xWhiteSourceTextBox);
            }
        }

        private void xBlueSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, (sourceColorProfile as NewColorProfile).SetBlueX,
                    profileSourceComboBox, ValidateXY, yBlueSourceTextBox);
            }
        }

        private void xGreenSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, (sourceColorProfile as NewColorProfile).SetGreenX,
                    profileSourceComboBox, ValidateXY, yGreenSourceTextBox);
            }
        }

        private void yBlueSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, (sourceColorProfile as NewColorProfile).SetBlueY,
                    profileSourceComboBox, ValidateXY, xBlueSourceTextBox);
            }
        }

        private void yGreenSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, (sourceColorProfile as NewColorProfile).SetGreenY,
                    profileSourceComboBox, ValidateXY, xGreenSourceTextBox);
            }
        }

        private void yRedSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                sourceColorProfile = new NewColorProfile(sourceColorProfile);
                HandleTextChanged((TextBox)sender, (sourceColorProfile as NewColorProfile).SetRedY,
                    profileSourceComboBox, ValidateXY, xRedSourceTextBox);
            }
        }

        private void xBlueTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, (targetColorProfile as NewColorProfile).SetBlueX,
                    profileTargetComboBox, ValidateXY, yBlueTargetTextBox);
            }
        }

        private void xGreenTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, (targetColorProfile as NewColorProfile).SetGreenX,
                    profileTargetComboBox, ValidateXY, yGreenTargetTextBox);
            }
        }

        private void xRedTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, (targetColorProfile as NewColorProfile).SetRedX,
                    profileTargetComboBox, ValidateXY, yRedTargetTextBox);
            }
        }

        private void xWhiteTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, (targetColorProfile as NewColorProfile).SetWhiteX,
                    profileTargetComboBox, ValidateXY, yWhiteTargetTextBox);
            }
        }

        private void yBlueTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, (targetColorProfile as NewColorProfile).SetBlueY,
                    profileTargetComboBox, ValidateXY, xBlueTargetTextBox);
            }
        }

        private void yGreenTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, (targetColorProfile as NewColorProfile).SetGreenY,
                    profileTargetComboBox, ValidateXY, xGreenTargetTextBox);
            }
        }

        private void yRedTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, (targetColorProfile as NewColorProfile).SetRedY,
                    profileTargetComboBox, ValidateXY, xRedTargetTextBox);
            }
        }

        private void yWhiteTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (textChangedFlag)
            {
                targetColorProfile = new NewColorProfile(targetColorProfile);
                HandleTextChanged((TextBox)sender, (targetColorProfile as NewColorProfile).SetWhiteY,
                    profileTargetComboBox, ValidateXY, xWhiteTargetTextBox);
            }
        }

        private void HandleTextChanged(TextBox textBox, Action<double> func, ComboBox comboBox,
            Func<TextBox, bool> validation, TextBox textBox2 = null)
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
                blockGenerateHashSet[(0, textBox)] = false;
                if (!blockGenerateHashSet.ContainsValue(true))
                    generateButton.Enabled = true;
            }
            else
            {
                blockGenerateHashSet[(0, textBox)] = true;
                generateButton.Enabled = false;
            }

            if (textBox2 != null && !ValidateSum(textBox, textBox2))
            {
                blockGenerateHashSet[(0, textBox)] = true;
                generateButton.Enabled = false;
            }
            else if (textBox2 != null)
            {
                if (!blockGenerateHashSet.ContainsValue(true))
                    generateButton.Enabled = true;
            }
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

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            sourcePictureBox.Image = new Bitmap(Image.FromFile(defaultPicturePath),
                        sourcePictureBox.Width, sourcePictureBox.Height);
            targetPictureBox.Size = sourcePictureBox.Size;
        }
    }
}
