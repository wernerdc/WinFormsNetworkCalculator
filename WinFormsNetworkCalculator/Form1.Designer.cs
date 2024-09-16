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
            panel1 = new Panel();
            buttonSaveFile = new Button();
            buttonCopySelected = new Button();
            buttonCopyClipboard = new Button();
            tbResults = new ColorTextBox();
            numericUpDownCidr = new NumericUpDown();
            textBoxSubnetmaskBin = new TextBox();
            label3 = new Label();
            textBoxSubnetmaskDez = new TextBox();
            label2 = new Label();
            label1 = new Label();
            buttonCalculateNetwork = new Button();
            textBoxAddress = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCidr).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(buttonSaveFile);
            panel1.Controls.Add(buttonCopySelected);
            panel1.Controls.Add(buttonCopyClipboard);
            panel1.Controls.Add(tbResults);
            panel1.Controls.Add(numericUpDownCidr);
            panel1.Controls.Add(textBoxSubnetmaskBin);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBoxSubnetmaskDez);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buttonCalculateNetwork);
            panel1.Controls.Add(textBoxAddress);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(515, 277);
            panel1.TabIndex = 0;
            // 
            // buttonSaveFile
            // 
            buttonSaveFile.Location = new Point(406, 85);
            buttonSaveFile.Name = "buttonSaveFile";
            buttonSaveFile.Size = new Size(97, 23);
            buttonSaveFile.TabIndex = 6;
            buttonSaveFile.Text = "Save as...";
            buttonSaveFile.UseVisualStyleBackColor = true;
            buttonSaveFile.Click += buttonSaveFile_Click;
            // 
            // buttonCopySelected
            // 
            buttonCopySelected.Location = new Point(406, 56);
            buttonCopySelected.Name = "buttonCopySelected";
            buttonCopySelected.Size = new Size(97, 23);
            buttonCopySelected.TabIndex = 5;
            buttonCopySelected.Text = "Copy selected";
            buttonCopySelected.UseVisualStyleBackColor = true;
            buttonCopySelected.Click += buttonCopySelected_Click;
            // 
            // buttonCopyClipboard
            // 
            buttonCopyClipboard.Location = new Point(406, 27);
            buttonCopyClipboard.Name = "buttonCopyClipboard";
            buttonCopyClipboard.Size = new Size(97, 23);
            buttonCopyClipboard.TabIndex = 4;
            buttonCopyClipboard.Text = "Copy text";
            buttonCopyClipboard.UseVisualStyleBackColor = true;
            buttonCopyClipboard.Click += buttonCopyClipboard_Click;
            // 
            // tbResults
            // 
            tbResults.BackColor = SystemColors.Window;
            tbResults.Dock = DockStyle.Bottom;
            tbResults.Font = new Font("Consolas", 9F);
            tbResults.Location = new Point(0, 118);
            tbResults.Name = "tbResults";
            tbResults.ReadOnly = true;
            tbResults.Size = new Size(515, 159);
            tbResults.TabIndex = 6;
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
            textBoxSubnetmaskBin.Size = new Size(260, 22);
            textBoxSubnetmaskBin.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 67);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 8;
            label3.Text = "Subnetmask";
            // 
            // textBoxSubnetmaskDez
            // 
            textBoxSubnetmaskDez.BackColor = Color.FromArgb(248, 248, 248);
            textBoxSubnetmaskDez.Enabled = false;
            textBoxSubnetmaskDez.Font = new Font("Consolas", 9F);
            textBoxSubnetmaskDez.Location = new Point(12, 85);
            textBoxSubnetmaskDez.Name = "textBoxSubnetmaskDez";
            textBoxSubnetmaskDez.Size = new Size(118, 22);
            textBoxSubnetmaskDez.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(136, 9);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 5;
            label2.Text = "CIDR";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 4;
            label1.Text = "Address";
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
            textBoxAddress.BackColor = SystemColors.Window;
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
            ClientSize = new Size(515, 277);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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
        private Label label2;
        private Label label1;
        private Button buttonCalculateNetwork;
        private TextBox textBoxAddress;
        private TextBox textBoxSubnetmaskDez;
        private Label label3;
        private TextBox textBoxSubnetmaskBin;
        private NumericUpDown numericUpDownCidr;
        private ColorTextBox tbResults;
        private Button buttonCopyClipboard;
        private Button buttonCopySelected;
        private Button buttonSaveFile;
    }
}
