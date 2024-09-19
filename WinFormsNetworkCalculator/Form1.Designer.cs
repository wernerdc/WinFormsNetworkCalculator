namespace WinFormsNetworkCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            labelVersion = new Label();
            buttonSaveFile = new Button();
            buttonCopySelected = new Button();
            buttonCopyClipboard = new Button();
            tbResults = new ColorTextBox();
            numericUpDownCidr = new NumericUpDown();
            textBoxSubnetmaskBin = new TextBox();
            labelSubnet = new Label();
            textBoxSubnetmaskDez = new TextBox();
            labelCidr = new Label();
            labelAddress = new Label();
            buttonCalculateNetwork = new Button();
            textBoxAddress = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCidr).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(labelVersion);
            panel1.Controls.Add(buttonSaveFile);
            panel1.Controls.Add(buttonCopySelected);
            panel1.Controls.Add(buttonCopyClipboard);
            panel1.Controls.Add(tbResults);
            panel1.Controls.Add(numericUpDownCidr);
            panel1.Controls.Add(textBoxSubnetmaskBin);
            panel1.Controls.Add(labelSubnet);
            panel1.Controls.Add(textBoxSubnetmaskDez);
            panel1.Controls.Add(labelCidr);
            panel1.Controls.Add(labelAddress);
            panel1.Controls.Add(buttonCalculateNetwork);
            panel1.Controls.Add(textBoxAddress);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(644, 328);
            panel1.TabIndex = 0;
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.BackColor = SystemColors.Window;
            labelVersion.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelVersion.ForeColor = SystemColors.ScrollBar;
            labelVersion.Location = new Point(617, 312);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(27, 13);
            labelVersion.TabIndex = 17;
            labelVersion.Text = "v0.2";
            // 
            // buttonSaveFile
            // 
            buttonSaveFile.Location = new Point(531, 85);
            buttonSaveFile.Name = "buttonSaveFile";
            buttonSaveFile.Size = new Size(101, 23);
            buttonSaveFile.TabIndex = 7;
            buttonSaveFile.Text = "Save as...";
            buttonSaveFile.UseVisualStyleBackColor = true;
            buttonSaveFile.Click += buttonSaveFile_Click;
            // 
            // buttonCopySelected
            // 
            buttonCopySelected.Location = new Point(531, 56);
            buttonCopySelected.Name = "buttonCopySelected";
            buttonCopySelected.Size = new Size(101, 23);
            buttonCopySelected.TabIndex = 6;
            buttonCopySelected.Text = "Copy selected";
            buttonCopySelected.UseVisualStyleBackColor = true;
            buttonCopySelected.Click += buttonCopySelected_Click;
            // 
            // buttonCopyClipboard
            // 
            buttonCopyClipboard.Location = new Point(531, 27);
            buttonCopyClipboard.Name = "buttonCopyClipboard";
            buttonCopyClipboard.Size = new Size(101, 23);
            buttonCopyClipboard.TabIndex = 5;
            buttonCopyClipboard.Text = "Copy text";
            buttonCopyClipboard.UseVisualStyleBackColor = true;
            buttonCopyClipboard.Click += buttonCopyClipboard_Click;
            // 
            // tbResults
            // 
            tbResults.BackColor = SystemColors.Window;
            tbResults.BorderStyle = BorderStyle.None;
            tbResults.Dock = DockStyle.Bottom;
            tbResults.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbResults.Location = new Point(0, 120);
            tbResults.Name = "tbResults";
            tbResults.ReadOnly = true;
            tbResults.Size = new Size(644, 208);
            tbResults.TabIndex = 8;
            tbResults.Text = "";
            // 
            // numericUpDownCidr
            // 
            numericUpDownCidr.Font = new Font("Consolas", 9F);
            numericUpDownCidr.Location = new Point(136, 27);
            numericUpDownCidr.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDownCidr.Name = "numericUpDownCidr";
            numericUpDownCidr.Size = new Size(43, 22);
            numericUpDownCidr.TabIndex = 2;
            numericUpDownCidr.Value = new decimal(new int[] { 24, 0, 0, 0 });
            numericUpDownCidr.ValueChanged += numericUpDownCidr_ValueChanged;
            // 
            // textBoxSubnetmaskBin
            // 
            textBoxSubnetmaskBin.BackColor = Color.FromArgb(248, 248, 248);
            textBoxSubnetmaskBin.Enabled = false;
            textBoxSubnetmaskBin.Font = new Font("Consolas", 9F);
            textBoxSubnetmaskBin.Location = new Point(136, 85);
            textBoxSubnetmaskBin.Name = "textBoxSubnetmaskBin";
            textBoxSubnetmaskBin.ReadOnly = true;
            textBoxSubnetmaskBin.Size = new Size(260, 22);
            textBoxSubnetmaskBin.TabIndex = 9;
            // 
            // labelSubnet
            // 
            labelSubnet.AutoSize = true;
            labelSubnet.Location = new Point(12, 67);
            labelSubnet.Name = "labelSubnet";
            labelSubnet.Size = new Size(72, 15);
            labelSubnet.TabIndex = 18;
            labelSubnet.Text = "Subnetmask";
            // 
            // textBoxSubnetmaskDez
            // 
            textBoxSubnetmaskDez.Font = new Font("Consolas", 9F);
            textBoxSubnetmaskDez.Location = new Point(12, 85);
            textBoxSubnetmaskDez.Name = "textBoxSubnetmaskDez";
            textBoxSubnetmaskDez.Size = new Size(118, 22);
            textBoxSubnetmaskDez.TabIndex = 4;
            textBoxSubnetmaskDez.TextChanged += textBoxSubnetmaskDez_TextChanged;
            // 
            // labelCidr
            // 
            labelCidr.AutoSize = true;
            labelCidr.Location = new Point(136, 9);
            labelCidr.Name = "labelCidr";
            labelCidr.Size = new Size(33, 15);
            labelCidr.TabIndex = 16;
            labelCidr.Text = "CIDR";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(12, 9);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(49, 15);
            labelAddress.TabIndex = 15;
            labelAddress.Text = "Address";
            // 
            // buttonCalculateNetwork
            // 
            buttonCalculateNetwork.Location = new Point(185, 27);
            buttonCalculateNetwork.Name = "buttonCalculateNetwork";
            buttonCalculateNetwork.Size = new Size(91, 23);
            buttonCalculateNetwork.TabIndex = 3;
            buttonCalculateNetwork.Text = "Calculate";
            buttonCalculateNetwork.UseVisualStyleBackColor = true;
            buttonCalculateNetwork.Click += buttonCalculateNetwork_Click;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAddress.Location = new Point(12, 27);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(118, 22);
            textBoxAddress.TabIndex = 1;
            textBoxAddress.Text = "192.168.87.85";
            textBoxAddress.TextChanged += textBoxAddress_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 328);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "IPv4 Network Calculator";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCidr).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label labelCidr;
        private Label labelAddress;
        private Button buttonCalculateNetwork;
        private TextBox textBoxAddress;
        private TextBox textBoxSubnetmaskDez;
        private Label labelSubnet;
        private TextBox textBoxSubnetmaskBin;
        private NumericUpDown numericUpDownCidr;
        private ColorTextBox tbResults;
        private Button buttonCopyClipboard;
        private Button buttonCopySelected;
        private Button buttonSaveFile;
        private Label labelVersion;
    }
}
