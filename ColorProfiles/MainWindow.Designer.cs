namespace ColorProfiles
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainWindowTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.menuTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.generateButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.grayButton = new System.Windows.Forms.Button();
            this.loadPictureButton = new System.Windows.Forms.Button();
            this.profilesPanel = new System.Windows.Forms.Panel();
            this.profileTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.yBlueTargetTextBox = new System.Windows.Forms.TextBox();
            this.yGreenTargetTextBox = new System.Windows.Forms.TextBox();
            this.yRedTargetTextBox = new System.Windows.Forms.TextBox();
            this.yWhiteTargetTextBox = new System.Windows.Forms.TextBox();
            this.xBlueTargetTextBox = new System.Windows.Forms.TextBox();
            this.xGreenTargetTextBox = new System.Windows.Forms.TextBox();
            this.xRedTargetTextBox = new System.Windows.Forms.TextBox();
            this.xWhiteTargetTextBox = new System.Windows.Forms.TextBox();
            this.yBlueSourceTextBox = new System.Windows.Forms.TextBox();
            this.yGreenSourceTextBox = new System.Windows.Forms.TextBox();
            this.xRedSourceTextBox = new System.Windows.Forms.TextBox();
            this.yWhiteSourceTextBox = new System.Windows.Forms.TextBox();
            this.yRedSourceTextBox = new System.Windows.Forms.TextBox();
            this.xBlueSourceTextBox = new System.Windows.Forms.TextBox();
            this.xGreenSourceTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.redLabel2 = new System.Windows.Forms.Label();
            this.whiteLabel2 = new System.Windows.Forms.Label();
            this.yLabel2 = new System.Windows.Forms.Label();
            this.xLabel2 = new System.Windows.Forms.Label();
            this.gammaSourceLabel = new System.Windows.Forms.Label();
            this.profileTargetComboBox = new System.Windows.Forms.ComboBox();
            this.sourceProfileLabel = new System.Windows.Forms.Label();
            this.targetProfileLabel = new System.Windows.Forms.Label();
            this.profileSourceComboBox = new System.Windows.Forms.ComboBox();
            this.gammaLabel = new System.Windows.Forms.Label();
            this.gammaSourceTextBox = new System.Windows.Forms.TextBox();
            this.gammaTargetTextBox = new System.Windows.Forms.TextBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.whiteLabel = new System.Windows.Forms.Label();
            this.redLabel = new System.Windows.Forms.Label();
            this.greenLabel = new System.Windows.Forms.Label();
            this.blueLabel = new System.Windows.Forms.Label();
            this.xWhiteSourceTextBox = new System.Windows.Forms.TextBox();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.picturesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.targetPictureBox = new System.Windows.Forms.PictureBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainWindowTableLayoutPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.menuTableLayoutPanel.SuspendLayout();
            this.profilesPanel.SuspendLayout();
            this.profileTableLayoutPanel.SuspendLayout();
            this.picturePanel.SuspendLayout();
            this.picturesTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // mainWindowTableLayoutPanel
            // 
            this.mainWindowTableLayoutPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.mainWindowTableLayoutPanel.ColumnCount = 1;
            this.mainWindowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainWindowTableLayoutPanel.Controls.Add(this.menuPanel, 0, 0);
            this.mainWindowTableLayoutPanel.Controls.Add(this.profilesPanel, 0, 1);
            this.mainWindowTableLayoutPanel.Controls.Add(this.picturePanel, 0, 2);
            this.mainWindowTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWindowTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainWindowTableLayoutPanel.Name = "mainWindowTableLayoutPanel";
            this.mainWindowTableLayoutPanel.RowCount = 3;
            this.mainWindowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.mainWindowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.mainWindowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.mainWindowTableLayoutPanel.Size = new System.Drawing.Size(799, 451);
            this.mainWindowTableLayoutPanel.TabIndex = 0;
            // 
            // menuPanel
            // 
            this.menuPanel.AutoSize = true;
            this.menuPanel.Controls.Add(this.menuTableLayoutPanel);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuPanel.Location = new System.Drawing.Point(3, 3);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(793, 12);
            this.menuPanel.TabIndex = 0;
            // 
            // menuTableLayoutPanel
            // 
            this.menuTableLayoutPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuTableLayoutPanel.ColumnCount = 5;
            this.menuTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.menuTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.menuTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.menuTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.menuTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76F));
            this.menuTableLayoutPanel.Controls.Add(this.generateButton, 1, 0);
            this.menuTableLayoutPanel.Controls.Add(this.saveButton, 2, 0);
            this.menuTableLayoutPanel.Controls.Add(this.grayButton, 3, 0);
            this.menuTableLayoutPanel.Controls.Add(this.loadPictureButton, 0, 0);
            this.menuTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.menuTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.menuTableLayoutPanel.Name = "menuTableLayoutPanel";
            this.menuTableLayoutPanel.RowCount = 1;
            this.menuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuTableLayoutPanel.Size = new System.Drawing.Size(793, 12);
            this.menuTableLayoutPanel.TabIndex = 23;
            // 
            // generateButton
            // 
            this.generateButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.generateButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.generateButton.Location = new System.Drawing.Point(66, 3);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(41, 6);
            this.generateButton.TabIndex = 21;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveButton.Enabled = false;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveButton.Location = new System.Drawing.Point(113, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(33, 6);
            this.saveButton.TabIndex = 22;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // grayButton
            // 
            this.grayButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.grayButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grayButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grayButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grayButton.Location = new System.Drawing.Point(152, 3);
            this.grayButton.Name = "grayButton";
            this.grayButton.Size = new System.Drawing.Size(33, 6);
            this.grayButton.TabIndex = 22;
            this.grayButton.Text = "Gray";
            this.grayButton.UseVisualStyleBackColor = false;
            this.grayButton.Click += new System.EventHandler(this.grayButton_Click);
            // 
            // loadPictureButton
            // 
            this.loadPictureButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadPictureButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loadPictureButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadPictureButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loadPictureButton.Location = new System.Drawing.Point(3, 3);
            this.loadPictureButton.Name = "loadPictureButton";
            this.loadPictureButton.Size = new System.Drawing.Size(57, 6);
            this.loadPictureButton.TabIndex = 20;
            this.loadPictureButton.Text = "Load picture";
            this.loadPictureButton.UseVisualStyleBackColor = true;
            this.loadPictureButton.Click += new System.EventHandler(this.loadPictureButton_Click);
            // 
            // profilesPanel
            // 
            this.profilesPanel.Controls.Add(this.profileTableLayoutPanel);
            this.profilesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilesPanel.Location = new System.Drawing.Point(3, 21);
            this.profilesPanel.Name = "profilesPanel";
            this.profilesPanel.Size = new System.Drawing.Size(793, 66);
            this.profilesPanel.TabIndex = 1;
            // 
            // profileTableLayoutPanel
            // 
            this.profileTableLayoutPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.profileTableLayoutPanel.ColumnCount = 16;
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.profileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.profileTableLayoutPanel.Controls.Add(this.yBlueTargetTextBox, 14, 4);
            this.profileTableLayoutPanel.Controls.Add(this.yGreenTargetTextBox, 13, 3);
            this.profileTableLayoutPanel.Controls.Add(this.yRedTargetTextBox, 13, 2);
            this.profileTableLayoutPanel.Controls.Add(this.yWhiteTargetTextBox, 14, 1);
            this.profileTableLayoutPanel.Controls.Add(this.xBlueTargetTextBox, 13, 4);
            this.profileTableLayoutPanel.Controls.Add(this.xGreenTargetTextBox, 13, 3);
            this.profileTableLayoutPanel.Controls.Add(this.xRedTargetTextBox, 13, 2);
            this.profileTableLayoutPanel.Controls.Add(this.xWhiteTargetTextBox, 13, 1);
            this.profileTableLayoutPanel.Controls.Add(this.yBlueSourceTextBox, 6, 4);
            this.profileTableLayoutPanel.Controls.Add(this.yGreenSourceTextBox, 6, 3);
            this.profileTableLayoutPanel.Controls.Add(this.xRedSourceTextBox, 5, 2);
            this.profileTableLayoutPanel.Controls.Add(this.yWhiteSourceTextBox, 6, 1);
            this.profileTableLayoutPanel.Controls.Add(this.yRedSourceTextBox, 6, 2);
            this.profileTableLayoutPanel.Controls.Add(this.xBlueSourceTextBox, 5, 4);
            this.profileTableLayoutPanel.Controls.Add(this.xGreenSourceTextBox, 5, 3);
            this.profileTableLayoutPanel.Controls.Add(this.label2, 12, 4);
            this.profileTableLayoutPanel.Controls.Add(this.label1, 12, 3);
            this.profileTableLayoutPanel.Controls.Add(this.redLabel2, 12, 2);
            this.profileTableLayoutPanel.Controls.Add(this.whiteLabel2, 12, 1);
            this.profileTableLayoutPanel.Controls.Add(this.yLabel2, 14, 0);
            this.profileTableLayoutPanel.Controls.Add(this.xLabel2, 13, 0);
            this.profileTableLayoutPanel.Controls.Add(this.gammaSourceLabel, 8, 3);
            this.profileTableLayoutPanel.Controls.Add(this.profileTargetComboBox, 8, 1);
            this.profileTableLayoutPanel.Controls.Add(this.sourceProfileLabel, 0, 0);
            this.profileTableLayoutPanel.Controls.Add(this.targetProfileLabel, 8, 0);
            this.profileTableLayoutPanel.Controls.Add(this.profileSourceComboBox, 0, 1);
            this.profileTableLayoutPanel.Controls.Add(this.gammaLabel, 0, 3);
            this.profileTableLayoutPanel.Controls.Add(this.gammaSourceTextBox, 1, 3);
            this.profileTableLayoutPanel.Controls.Add(this.gammaTargetTextBox, 9, 3);
            this.profileTableLayoutPanel.Controls.Add(this.xLabel, 5, 0);
            this.profileTableLayoutPanel.Controls.Add(this.yLabel, 6, 0);
            this.profileTableLayoutPanel.Controls.Add(this.whiteLabel, 4, 1);
            this.profileTableLayoutPanel.Controls.Add(this.redLabel, 4, 2);
            this.profileTableLayoutPanel.Controls.Add(this.greenLabel, 4, 3);
            this.profileTableLayoutPanel.Controls.Add(this.blueLabel, 4, 4);
            this.profileTableLayoutPanel.Controls.Add(this.xWhiteSourceTextBox, 5, 1);
            this.profileTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profileTableLayoutPanel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.profileTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.profileTableLayoutPanel.Name = "profileTableLayoutPanel";
            this.profileTableLayoutPanel.RowCount = 5;
            this.profileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.profileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.profileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.profileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.profileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.profileTableLayoutPanel.Size = new System.Drawing.Size(793, 66);
            this.profileTableLayoutPanel.TabIndex = 0;
            // 
            // yBlueTargetTextBox
            // 
            this.yBlueTargetTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yBlueTargetTextBox.Location = new System.Drawing.Point(693, 55);
            this.yBlueTargetTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.yBlueTargetTextBox.Name = "yBlueTargetTextBox";
            this.yBlueTargetTextBox.Size = new System.Drawing.Size(30, 27);
            this.yBlueTargetTextBox.TabIndex = 19;
            this.yBlueTargetTextBox.TextChanged += new System.EventHandler(this.yBlueTargetTextBox_TextChanged);
            this.yBlueTargetTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // yGreenTargetTextBox
            // 
            this.yGreenTargetTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yGreenTargetTextBox.Location = new System.Drawing.Point(693, 42);
            this.yGreenTargetTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.yGreenTargetTextBox.Name = "yGreenTargetTextBox";
            this.yGreenTargetTextBox.Size = new System.Drawing.Size(30, 27);
            this.yGreenTargetTextBox.TabIndex = 18;
            this.yGreenTargetTextBox.TextChanged += new System.EventHandler(this.yGreenTargetTextBox_TextChanged);
            this.yGreenTargetTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // yRedTargetTextBox
            // 
            this.yRedTargetTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yRedTargetTextBox.Location = new System.Drawing.Point(693, 29);
            this.yRedTargetTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.yRedTargetTextBox.Name = "yRedTargetTextBox";
            this.yRedTargetTextBox.Size = new System.Drawing.Size(30, 27);
            this.yRedTargetTextBox.TabIndex = 17;
            this.yRedTargetTextBox.TextChanged += new System.EventHandler(this.yRedTargetTextBox_TextChanged);
            this.yRedTargetTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // yWhiteTargetTextBox
            // 
            this.yWhiteTargetTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yWhiteTargetTextBox.Location = new System.Drawing.Point(693, 16);
            this.yWhiteTargetTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.yWhiteTargetTextBox.Name = "yWhiteTargetTextBox";
            this.yWhiteTargetTextBox.Size = new System.Drawing.Size(30, 27);
            this.yWhiteTargetTextBox.TabIndex = 16;
            this.yWhiteTargetTextBox.TextChanged += new System.EventHandler(this.yWhiteTargetTextBox_TextChanged);
            this.yWhiteTargetTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // xBlueTargetTextBox
            // 
            this.xBlueTargetTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xBlueTargetTextBox.Location = new System.Drawing.Point(630, 55);
            this.xBlueTargetTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.xBlueTargetTextBox.Name = "xBlueTargetTextBox";
            this.xBlueTargetTextBox.Size = new System.Drawing.Size(30, 27);
            this.xBlueTargetTextBox.TabIndex = 15;
            this.xBlueTargetTextBox.TextChanged += new System.EventHandler(this.xBlueTargetTextBox_TextChanged);
            this.xBlueTargetTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // xGreenTargetTextBox
            // 
            this.xGreenTargetTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xGreenTargetTextBox.Location = new System.Drawing.Point(630, 42);
            this.xGreenTargetTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.xGreenTargetTextBox.Name = "xGreenTargetTextBox";
            this.xGreenTargetTextBox.Size = new System.Drawing.Size(30, 27);
            this.xGreenTargetTextBox.TabIndex = 14;
            this.xGreenTargetTextBox.TextChanged += new System.EventHandler(this.xGreenTargetTextBox_TextChanged);
            this.xGreenTargetTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // xRedTargetTextBox
            // 
            this.xRedTargetTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xRedTargetTextBox.Location = new System.Drawing.Point(630, 29);
            this.xRedTargetTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.xRedTargetTextBox.Name = "xRedTargetTextBox";
            this.xRedTargetTextBox.Size = new System.Drawing.Size(30, 27);
            this.xRedTargetTextBox.TabIndex = 13;
            this.xRedTargetTextBox.TextChanged += new System.EventHandler(this.xRedTargetTextBox_TextChanged);
            this.xRedTargetTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // xWhiteTargetTextBox
            // 
            this.xWhiteTargetTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xWhiteTargetTextBox.Location = new System.Drawing.Point(630, 16);
            this.xWhiteTargetTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.xWhiteTargetTextBox.Name = "xWhiteTargetTextBox";
            this.xWhiteTargetTextBox.Size = new System.Drawing.Size(30, 27);
            this.xWhiteTargetTextBox.TabIndex = 12;
            this.xWhiteTargetTextBox.TextChanged += new System.EventHandler(this.xWhiteTargetTextBox_TextChanged);
            this.xWhiteTargetTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // yBlueSourceTextBox
            // 
            this.yBlueSourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yBlueSourceTextBox.Location = new System.Drawing.Point(301, 55);
            this.yBlueSourceTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.yBlueSourceTextBox.Name = "yBlueSourceTextBox";
            this.yBlueSourceTextBox.Size = new System.Drawing.Size(30, 27);
            this.yBlueSourceTextBox.TabIndex = 9;
            this.yBlueSourceTextBox.TextChanged += new System.EventHandler(this.yBlueSourceTextBox_TextChanged);
            this.yBlueSourceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // yGreenSourceTextBox
            // 
            this.yGreenSourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yGreenSourceTextBox.Location = new System.Drawing.Point(301, 42);
            this.yGreenSourceTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.yGreenSourceTextBox.Name = "yGreenSourceTextBox";
            this.yGreenSourceTextBox.Size = new System.Drawing.Size(30, 27);
            this.yGreenSourceTextBox.TabIndex = 8;
            this.yGreenSourceTextBox.TextChanged += new System.EventHandler(this.yGreenSourceTextBox_TextChanged);
            this.yGreenSourceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // xRedSourceTextBox
            // 
            this.xRedSourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xRedSourceTextBox.Location = new System.Drawing.Point(238, 29);
            this.xRedSourceTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.xRedSourceTextBox.Name = "xRedSourceTextBox";
            this.xRedSourceTextBox.Size = new System.Drawing.Size(30, 27);
            this.xRedSourceTextBox.TabIndex = 3;
            this.xRedSourceTextBox.TextChanged += new System.EventHandler(this.xRedSourceTextBox_TextChanged);
            this.xRedSourceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // yWhiteSourceTextBox
            // 
            this.yWhiteSourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yWhiteSourceTextBox.Location = new System.Drawing.Point(301, 16);
            this.yWhiteSourceTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.yWhiteSourceTextBox.Name = "yWhiteSourceTextBox";
            this.yWhiteSourceTextBox.Size = new System.Drawing.Size(30, 27);
            this.yWhiteSourceTextBox.TabIndex = 6;
            this.yWhiteSourceTextBox.TextChanged += new System.EventHandler(this.yWhiteSourceTextBox_TextChanged);
            this.yWhiteSourceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // yRedSourceTextBox
            // 
            this.yRedSourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yRedSourceTextBox.Location = new System.Drawing.Point(301, 29);
            this.yRedSourceTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.yRedSourceTextBox.Name = "yRedSourceTextBox";
            this.yRedSourceTextBox.Size = new System.Drawing.Size(30, 27);
            this.yRedSourceTextBox.TabIndex = 7;
            this.yRedSourceTextBox.TextChanged += new System.EventHandler(this.yRedSourceTextBox_TextChanged);
            this.yRedSourceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // xBlueSourceTextBox
            // 
            this.xBlueSourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xBlueSourceTextBox.Location = new System.Drawing.Point(238, 55);
            this.xBlueSourceTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.xBlueSourceTextBox.Name = "xBlueSourceTextBox";
            this.xBlueSourceTextBox.Size = new System.Drawing.Size(30, 27);
            this.xBlueSourceTextBox.TabIndex = 5;
            this.xBlueSourceTextBox.TextChanged += new System.EventHandler(this.xBlueSourceTextBox_TextChanged);
            this.xBlueSourceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // xGreenSourceTextBox
            // 
            this.xGreenSourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xGreenSourceTextBox.Location = new System.Drawing.Point(238, 42);
            this.xGreenSourceTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.xGreenSourceTextBox.Name = "xGreenSourceTextBox";
            this.xGreenSourceTextBox.Size = new System.Drawing.Size(30, 27);
            this.xGreenSourceTextBox.TabIndex = 4;
            this.xGreenSourceTextBox.TextChanged += new System.EventHandler(this.xGreenSourceTextBox_TextChanged);
            this.xGreenSourceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(583, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Blue:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(583, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Green:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // redLabel2
            // 
            this.redLabel2.AutoSize = true;
            this.redLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redLabel2.Location = new System.Drawing.Point(583, 26);
            this.redLabel2.Name = "redLabel2";
            this.redLabel2.Size = new System.Drawing.Size(41, 13);
            this.redLabel2.TabIndex = 17;
            this.redLabel2.Text = "Red:";
            this.redLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // whiteLabel2
            // 
            this.whiteLabel2.AutoSize = true;
            this.whiteLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.whiteLabel2.Location = new System.Drawing.Point(583, 13);
            this.whiteLabel2.Name = "whiteLabel2";
            this.whiteLabel2.Size = new System.Drawing.Size(41, 13);
            this.whiteLabel2.TabIndex = 16;
            this.whiteLabel2.Text = "White:";
            this.whiteLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yLabel2
            // 
            this.yLabel2.AutoSize = true;
            this.yLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yLabel2.Location = new System.Drawing.Point(693, 0);
            this.yLabel2.Margin = new System.Windows.Forms.Padding(3, 0, 20, 0);
            this.yLabel2.Name = "yLabel2";
            this.yLabel2.Size = new System.Drawing.Size(40, 13);
            this.yLabel2.TabIndex = 11;
            this.yLabel2.Text = "y";
            this.yLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel2
            // 
            this.xLabel2.AutoSize = true;
            this.xLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xLabel2.Location = new System.Drawing.Point(630, 0);
            this.xLabel2.Margin = new System.Windows.Forms.Padding(3, 0, 30, 0);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(30, 13);
            this.xLabel2.TabIndex = 10;
            this.xLabel2.Text = "x";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gammaSourceLabel
            // 
            this.gammaSourceLabel.AutoSize = true;
            this.gammaSourceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gammaSourceLabel.Location = new System.Drawing.Point(395, 39);
            this.gammaSourceLabel.Name = "gammaSourceLabel";
            this.gammaSourceLabel.Size = new System.Drawing.Size(41, 13);
            this.gammaSourceLabel.TabIndex = 6;
            this.gammaSourceLabel.Text = "Gamma:";
            // 
            // profileTargetComboBox
            // 
            this.profileTableLayoutPanel.SetColumnSpan(this.profileTargetComboBox, 3);
            this.profileTargetComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profileTargetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileTargetComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.profileTargetComboBox.FormattingEnabled = true;
            this.profileTargetComboBox.Items.AddRange(new object[] {
            "sRGB",
            "Adobe RGB",
            "Apple RGB",
            "CIE RGB",
            "Wide Gamut",
            "New"});
            this.profileTargetComboBox.Location = new System.Drawing.Point(395, 16);
            this.profileTargetComboBox.Name = "profileTargetComboBox";
            this.profileTargetComboBox.Size = new System.Drawing.Size(135, 28);
            this.profileTargetComboBox.TabIndex = 10;
            this.profileTargetComboBox.SelectedIndexChanged += new System.EventHandler(this.profileTargetComboBox_SelectedIndexChanged);
            // 
            // sourceProfileLabel
            // 
            this.sourceProfileLabel.AutoSize = true;
            this.profileTableLayoutPanel.SetColumnSpan(this.sourceProfileLabel, 2);
            this.sourceProfileLabel.Location = new System.Drawing.Point(3, 0);
            this.sourceProfileLabel.Name = "sourceProfileLabel";
            this.sourceProfileLabel.Size = new System.Drawing.Size(58, 13);
            this.sourceProfileLabel.TabIndex = 0;
            this.sourceProfileLabel.Text = "Source profile:";
            // 
            // targetProfileLabel
            // 
            this.targetProfileLabel.AutoSize = true;
            this.profileTableLayoutPanel.SetColumnSpan(this.targetProfileLabel, 2);
            this.targetProfileLabel.Location = new System.Drawing.Point(395, 0);
            this.targetProfileLabel.Name = "targetProfileLabel";
            this.targetProfileLabel.Size = new System.Drawing.Size(56, 13);
            this.targetProfileLabel.TabIndex = 1;
            this.targetProfileLabel.Text = "Target profile:";
            // 
            // profileSourceComboBox
            // 
            this.profileTableLayoutPanel.SetColumnSpan(this.profileSourceComboBox, 3);
            this.profileSourceComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profileSourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileSourceComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.profileSourceComboBox.FormattingEnabled = true;
            this.profileSourceComboBox.Items.AddRange(new object[] {
            "sRGB",
            "Adobe RGB",
            "Apple RGB",
            "CIE RGB",
            "Wide Gamut",
            "New"});
            this.profileSourceComboBox.Location = new System.Drawing.Point(3, 16);
            this.profileSourceComboBox.Name = "profileSourceComboBox";
            this.profileSourceComboBox.Size = new System.Drawing.Size(135, 28);
            this.profileSourceComboBox.TabIndex = 0;
            this.profileSourceComboBox.SelectedIndexChanged += new System.EventHandler(this.profileSourceComboBox_SelectedIndexChanged);
            // 
            // gammaLabel
            // 
            this.gammaLabel.AutoSize = true;
            this.gammaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gammaLabel.Location = new System.Drawing.Point(3, 39);
            this.gammaLabel.Name = "gammaLabel";
            this.gammaLabel.Size = new System.Drawing.Size(41, 13);
            this.gammaLabel.TabIndex = 4;
            this.gammaLabel.Text = "Gamma:";
            // 
            // gammaSourceTextBox
            // 
            this.gammaSourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gammaSourceTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gammaSourceTextBox.Location = new System.Drawing.Point(50, 42);
            this.gammaSourceTextBox.Name = "gammaSourceTextBox";
            this.gammaSourceTextBox.Size = new System.Drawing.Size(41, 27);
            this.gammaSourceTextBox.TabIndex = 1;
            this.gammaSourceTextBox.TextChanged += new System.EventHandler(this.gammaSourceTextBox_TextChanged);
            this.gammaSourceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // gammaTargetTextBox
            // 
            this.gammaTargetTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gammaTargetTextBox.Location = new System.Drawing.Point(442, 42);
            this.gammaTargetTextBox.Name = "gammaTargetTextBox";
            this.gammaTargetTextBox.Size = new System.Drawing.Size(41, 27);
            this.gammaTargetTextBox.TabIndex = 11;
            this.gammaTargetTextBox.TextChanged += new System.EventHandler(this.gammaTargetTextBox_TextChanged);
            this.gammaTargetTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xLabel.Location = new System.Drawing.Point(238, 0);
            this.xLabel.Margin = new System.Windows.Forms.Padding(3, 0, 30, 0);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(30, 13);
            this.xLabel.TabIndex = 8;
            this.xLabel.Text = "x";
            this.xLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yLabel.Location = new System.Drawing.Point(301, 0);
            this.yLabel.Margin = new System.Windows.Forms.Padding(3, 0, 30, 0);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(30, 13);
            this.yLabel.TabIndex = 9;
            this.yLabel.Text = "y";
            this.yLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // whiteLabel
            // 
            this.whiteLabel.AutoSize = true;
            this.whiteLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.whiteLabel.Location = new System.Drawing.Point(191, 13);
            this.whiteLabel.Name = "whiteLabel";
            this.whiteLabel.Size = new System.Drawing.Size(41, 13);
            this.whiteLabel.TabIndex = 12;
            this.whiteLabel.Text = "White:";
            this.whiteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // redLabel
            // 
            this.redLabel.AutoSize = true;
            this.redLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redLabel.Location = new System.Drawing.Point(191, 26);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(41, 13);
            this.redLabel.TabIndex = 13;
            this.redLabel.Text = "Red:";
            this.redLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // greenLabel
            // 
            this.greenLabel.AutoSize = true;
            this.greenLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.greenLabel.Location = new System.Drawing.Point(191, 39);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(41, 13);
            this.greenLabel.TabIndex = 14;
            this.greenLabel.Text = "Green:";
            this.greenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blueLabel
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blueLabel.Location = new System.Drawing.Point(191, 52);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(41, 14);
            this.blueLabel.TabIndex = 15;
            this.blueLabel.Text = "Blue:";
            this.blueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xWhiteSourceTextBox
            // 
            this.xWhiteSourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xWhiteSourceTextBox.Location = new System.Drawing.Point(238, 16);
            this.xWhiteSourceTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.xWhiteSourceTextBox.Name = "xWhiteSourceTextBox";
            this.xWhiteSourceTextBox.Size = new System.Drawing.Size(30, 27);
            this.xWhiteSourceTextBox.TabIndex = 2;
            this.xWhiteSourceTextBox.TextChanged += new System.EventHandler(this.xWhiteSourceTextBox_TextChanged);
            this.xWhiteSourceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // picturePanel
            // 
            this.picturePanel.Controls.Add(this.picturesTableLayoutPanel);
            this.picturePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturePanel.Location = new System.Drawing.Point(3, 93);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(793, 355);
            this.picturePanel.TabIndex = 2;
            // 
            // picturesTableLayoutPanel
            // 
            this.picturesTableLayoutPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.picturesTableLayoutPanel.ColumnCount = 2;
            this.picturesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.picturesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.picturesTableLayoutPanel.Controls.Add(this.sourcePictureBox, 0, 0);
            this.picturesTableLayoutPanel.Controls.Add(this.targetPictureBox, 1, 0);
            this.picturesTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturesTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.picturesTableLayoutPanel.Name = "picturesTableLayoutPanel";
            this.picturesTableLayoutPanel.RowCount = 1;
            this.picturesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.picturesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.picturesTableLayoutPanel.Size = new System.Drawing.Size(793, 355);
            this.picturesTableLayoutPanel.TabIndex = 0;
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.sourcePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourcePictureBox.Location = new System.Drawing.Point(50, 100);
            this.sourcePictureBox.Margin = new System.Windows.Forms.Padding(50, 100, 50, 150);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(296, 210);
            this.sourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            // 
            // targetPictureBox
            // 
            this.targetPictureBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.targetPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetPictureBox.Location = new System.Drawing.Point(446, 100);
            this.targetPictureBox.Margin = new System.Windows.Forms.Padding(50, 100, 50, 150);
            this.targetPictureBox.Name = "targetPictureBox";
            this.targetPictureBox.Size = new System.Drawing.Size(297, 210);
            this.targetPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.targetPictureBox.TabIndex = 1;
            this.targetPictureBox.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 451);
            this.Controls.Add(this.mainWindowTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Color Profiles Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainWindowTableLayoutPanel.ResumeLayout(false);
            this.mainWindowTableLayoutPanel.PerformLayout();
            this.menuPanel.ResumeLayout(false);
            this.menuTableLayoutPanel.ResumeLayout(false);
            this.profilesPanel.ResumeLayout(false);
            this.profileTableLayoutPanel.ResumeLayout(false);
            this.profileTableLayoutPanel.PerformLayout();
            this.picturePanel.ResumeLayout(false);
            this.picturesTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainWindowTableLayoutPanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.TableLayoutPanel menuTableLayoutPanel;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button grayButton;
        private System.Windows.Forms.Panel profilesPanel;
        private System.Windows.Forms.TableLayoutPanel profileTableLayoutPanel;
        private System.Windows.Forms.Label sourceProfileLabel;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.Label targetProfileLabel;
        private System.Windows.Forms.ComboBox profileSourceComboBox;
        private System.Windows.Forms.ComboBox profileTargetComboBox;
        private System.Windows.Forms.Label gammaLabel;
        private System.Windows.Forms.TextBox gammaSourceTextBox;
        private System.Windows.Forms.Label gammaSourceLabel;
        private System.Windows.Forms.TextBox gammaTargetTextBox;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label yLabel2;
        private System.Windows.Forms.Label xLabel2;
        private System.Windows.Forms.Label whiteLabel;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label redLabel2;
        private System.Windows.Forms.Label whiteLabel2;
        private System.Windows.Forms.TextBox xBlueSourceTextBox;
        private System.Windows.Forms.TextBox xGreenSourceTextBox;
        private System.Windows.Forms.TextBox xWhiteSourceTextBox;
        private System.Windows.Forms.TextBox yRedSourceTextBox;
        private System.Windows.Forms.TextBox yBlueSourceTextBox;
        private System.Windows.Forms.TextBox yGreenSourceTextBox;
        private System.Windows.Forms.TextBox xRedSourceTextBox;
        private System.Windows.Forms.TextBox yWhiteSourceTextBox;
        private System.Windows.Forms.TextBox yBlueTargetTextBox;
        private System.Windows.Forms.TextBox yGreenTargetTextBox;
        private System.Windows.Forms.TextBox yRedTargetTextBox;
        private System.Windows.Forms.TextBox yWhiteTargetTextBox;
        private System.Windows.Forms.TextBox xBlueTargetTextBox;
        private System.Windows.Forms.TextBox xGreenTargetTextBox;
        private System.Windows.Forms.TextBox xRedTargetTextBox;
        private System.Windows.Forms.TextBox xWhiteTargetTextBox;
        private System.Windows.Forms.TableLayoutPanel picturesTableLayoutPanel;
        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.PictureBox targetPictureBox;
        private System.Windows.Forms.Button loadPictureButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}

