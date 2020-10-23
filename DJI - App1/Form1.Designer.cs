namespace DJI___App1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dropdown_pal = new Bunifu.UI.WinForms.BunifuDropdown();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_browse = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.debug = new System.Windows.Forms.Button();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
            this.Textbox_ScaleHigh = new MetroFramework.Controls.MetroTextBox();
            this.Textbox_ScaleLow = new MetroFramework.Controls.MetroTextBox();
            this.Button_ApplyDisplay = new MetroFramework.Controls.MetroButton();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel5 = new Bunifu.UI.WinForms.BunifuLabel();
            this.Textbox_Emissivity = new MetroFramework.Controls.MetroTextBox();
            this.Textbox_ReflTemp = new MetroFramework.Controls.MetroTextBox();
            this.bunifuLabel6 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel7 = new Bunifu.UI.WinForms.BunifuLabel();
            this.Textbox_Distance = new MetroFramework.Controls.MetroTextBox();
            this.Textbox_Humidity = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dropdown_pal
            // 
            this.dropdown_pal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dropdown_pal.BackgroundColor = System.Drawing.Color.White;
            this.dropdown_pal.BorderColor = System.Drawing.Color.Silver;
            this.dropdown_pal.BorderRadius = 1;
            this.dropdown_pal.Color = System.Drawing.Color.Silver;
            this.dropdown_pal.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.dropdown_pal.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dropdown_pal.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.dropdown_pal.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dropdown_pal.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.dropdown_pal.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.dropdown_pal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dropdown_pal.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.dropdown_pal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdown_pal.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dropdown_pal.FillDropDown = true;
            this.dropdown_pal.FillIndicator = false;
            this.dropdown_pal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdown_pal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dropdown_pal.ForeColor = System.Drawing.Color.Black;
            this.dropdown_pal.FormattingEnabled = true;
            this.dropdown_pal.Icon = null;
            this.dropdown_pal.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dropdown_pal.IndicatorColor = System.Drawing.Color.Gray;
            this.dropdown_pal.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dropdown_pal.ItemBackColor = System.Drawing.Color.White;
            this.dropdown_pal.ItemBorderColor = System.Drawing.Color.White;
            this.dropdown_pal.ItemForeColor = System.Drawing.Color.Black;
            this.dropdown_pal.ItemHeight = 20;
            this.dropdown_pal.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.dropdown_pal.ItemHighLightForeColor = System.Drawing.Color.White;
            this.dropdown_pal.Items.AddRange(new object[] {
            "Iron Red",
            "Hot Iron",
            "Fulgurite",
            "Medical",
            "Arctic",
            "Rainbow 1",
            "Rainbow 2",
            "White Hot",
            "Black Hot",
            "Tint"});
            this.dropdown_pal.ItemTopMargin = 3;
            this.dropdown_pal.Location = new System.Drawing.Point(102, 29);
            this.dropdown_pal.Name = "dropdown_pal";
            this.dropdown_pal.Size = new System.Drawing.Size(92, 26);
            this.dropdown_pal.TabIndex = 0;
            this.dropdown_pal.Text = null;
            this.dropdown_pal.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dropdown_pal.TextLeftMargin = 5;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(23, 87);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(220, 173);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(168, 58);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(75, 23);
            this.button_browse.TabIndex = 2;
            this.button_browse.Text = "Browse";
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(259, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(590, 472);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Button_ApplyDisplay);
            this.groupBox1.Controls.Add(this.Textbox_Humidity);
            this.groupBox1.Controls.Add(this.Textbox_Distance);
            this.groupBox1.Controls.Add(this.Textbox_ReflTemp);
            this.groupBox1.Controls.Add(this.Textbox_Emissivity);
            this.groupBox1.Controls.Add(this.bunifuLabel7);
            this.groupBox1.Controls.Add(this.Textbox_ScaleLow);
            this.groupBox1.Controls.Add(this.bunifuLabel5);
            this.groupBox1.Controls.Add(this.bunifuLabel6);
            this.groupBox1.Controls.Add(this.Textbox_ScaleHigh);
            this.groupBox1.Controls.Add(this.bunifuLabel1);
            this.groupBox1.Controls.Add(this.bunifuLabel4);
            this.groupBox1.Controls.Add(this.bunifuLabel3);
            this.groupBox1.Controls.Add(this.bunifuLabel2);
            this.groupBox1.Controls.Add(this.dropdown_pal);
            this.groupBox1.Location = new System.Drawing.Point(28, 276);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 320);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameter Update";
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AllowParentOverrides = false;
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLabel2.Location = new System.Drawing.Point(8, 36);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(36, 15);
            this.bunifuLabel2.TabIndex = 5;
            this.bunifuLabel2.Text = "Palette";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // debug
            // 
            this.debug.Location = new System.Drawing.Point(259, 558);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(75, 23);
            this.debug.TabIndex = 9;
            this.debug.Text = "DEBUG";
            this.debug.UseVisualStyleBackColor = true;
            this.debug.Click += new System.EventHandler(this.debug_Click);
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AllowParentOverrides = false;
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.CursorType = null;
            this.bunifuLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLabel3.Location = new System.Drawing.Point(8, 65);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(56, 15);
            this.bunifuLabel3.TabIndex = 5;
            this.bunifuLabel3.Text = "Scale High";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel4
            // 
            this.bunifuLabel4.AllowParentOverrides = false;
            this.bunifuLabel4.AutoEllipsis = false;
            this.bunifuLabel4.CursorType = null;
            this.bunifuLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLabel4.Location = new System.Drawing.Point(8, 94);
            this.bunifuLabel4.Name = "bunifuLabel4";
            this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel4.Size = new System.Drawing.Size(52, 15);
            this.bunifuLabel4.TabIndex = 5;
            this.bunifuLabel4.Text = "Scale Low";
            this.bunifuLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Textbox_ScaleHigh
            // 
            this.Textbox_ScaleHigh.Location = new System.Drawing.Point(102, 61);
            this.Textbox_ScaleHigh.Name = "Textbox_ScaleHigh";
            this.Textbox_ScaleHigh.Size = new System.Drawing.Size(51, 23);
            this.Textbox_ScaleHigh.TabIndex = 10;
            this.Textbox_ScaleHigh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_ScaleHigh_KeyPress);
            // 
            // Textbox_ScaleLow
            // 
            this.Textbox_ScaleLow.Location = new System.Drawing.Point(102, 90);
            this.Textbox_ScaleLow.Name = "Textbox_ScaleLow";
            this.Textbox_ScaleLow.Size = new System.Drawing.Size(51, 23);
            this.Textbox_ScaleLow.TabIndex = 10;
            this.Textbox_ScaleLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_ScaleHigh_KeyPress);
            // 
            // Button_ApplyDisplay
            // 
            this.Button_ApplyDisplay.Location = new System.Drawing.Point(60, 282);
            this.Button_ApplyDisplay.Name = "Button_ApplyDisplay";
            this.Button_ApplyDisplay.Size = new System.Drawing.Size(75, 23);
            this.Button_ApplyDisplay.TabIndex = 10;
            this.Button_ApplyDisplay.Text = "Apply";
            this.Button_ApplyDisplay.Click += new System.EventHandler(this.Button_ApplyDisplay_Click);
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLabel1.Location = new System.Drawing.Point(8, 123);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(52, 15);
            this.bunifuLabel1.TabIndex = 5;
            this.bunifuLabel1.Text = "Emissivity";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel5
            // 
            this.bunifuLabel5.AllowParentOverrides = false;
            this.bunifuLabel5.AutoEllipsis = false;
            this.bunifuLabel5.CursorType = null;
            this.bunifuLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLabel5.Location = new System.Drawing.Point(8, 152);
            this.bunifuLabel5.Name = "bunifuLabel5";
            this.bunifuLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel5.Size = new System.Drawing.Size(59, 15);
            this.bunifuLabel5.TabIndex = 5;
            this.bunifuLabel5.Text = "Refl. Temp.";
            this.bunifuLabel5.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel5.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Textbox_Emissivity
            // 
            this.Textbox_Emissivity.Location = new System.Drawing.Point(102, 119);
            this.Textbox_Emissivity.Name = "Textbox_Emissivity";
            this.Textbox_Emissivity.Size = new System.Drawing.Size(51, 23);
            this.Textbox_Emissivity.TabIndex = 10;
            this.Textbox_Emissivity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_ScaleHigh_KeyPress);
            // 
            // Textbox_ReflTemp
            // 
            this.Textbox_ReflTemp.Location = new System.Drawing.Point(102, 148);
            this.Textbox_ReflTemp.Name = "Textbox_ReflTemp";
            this.Textbox_ReflTemp.Size = new System.Drawing.Size(51, 23);
            this.Textbox_ReflTemp.TabIndex = 10;
            this.Textbox_ReflTemp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_ScaleHigh_KeyPress);
            // 
            // bunifuLabel6
            // 
            this.bunifuLabel6.AllowParentOverrides = false;
            this.bunifuLabel6.AutoEllipsis = false;
            this.bunifuLabel6.CursorType = null;
            this.bunifuLabel6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLabel6.Location = new System.Drawing.Point(8, 181);
            this.bunifuLabel6.Name = "bunifuLabel6";
            this.bunifuLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel6.Size = new System.Drawing.Size(45, 15);
            this.bunifuLabel6.TabIndex = 5;
            this.bunifuLabel6.Text = "Distance";
            this.bunifuLabel6.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel6.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel7
            // 
            this.bunifuLabel7.AllowParentOverrides = false;
            this.bunifuLabel7.AutoEllipsis = false;
            this.bunifuLabel7.CursorType = null;
            this.bunifuLabel7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLabel7.Location = new System.Drawing.Point(8, 210);
            this.bunifuLabel7.Name = "bunifuLabel7";
            this.bunifuLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel7.Size = new System.Drawing.Size(50, 15);
            this.bunifuLabel7.TabIndex = 5;
            this.bunifuLabel7.Text = "Humidity";
            this.bunifuLabel7.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel7.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Textbox_Distance
            // 
            this.Textbox_Distance.Location = new System.Drawing.Point(102, 177);
            this.Textbox_Distance.Name = "Textbox_Distance";
            this.Textbox_Distance.Size = new System.Drawing.Size(51, 23);
            this.Textbox_Distance.TabIndex = 10;
            this.Textbox_Distance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_ScaleHigh_KeyPress);
            // 
            // Textbox_Humidity
            // 
            this.Textbox_Humidity.Location = new System.Drawing.Point(102, 206);
            this.Textbox_Humidity.Name = "Textbox_Humidity";
            this.Textbox_Humidity.Size = new System.Drawing.Size(51, 23);
            this.Textbox_Humidity.TabIndex = 10;
            this.Textbox_Humidity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_ScaleHigh_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 619);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_browse);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "DJI App 1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuDropdown dropdown_pal;
        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroButton button_browse;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private System.Windows.Forms.Button debug;
        private MetroFramework.Controls.MetroTextBox Textbox_ScaleLow;
        private MetroFramework.Controls.MetroTextBox Textbox_ScaleHigh;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel4;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private MetroFramework.Controls.MetroButton Button_ApplyDisplay;
        private MetroFramework.Controls.MetroTextBox Textbox_Humidity;
        private MetroFramework.Controls.MetroTextBox Textbox_Distance;
        private MetroFramework.Controls.MetroTextBox Textbox_ReflTemp;
        private MetroFramework.Controls.MetroTextBox Textbox_Emissivity;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel7;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel5;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel6;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
    }
}

