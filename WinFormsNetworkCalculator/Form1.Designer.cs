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
            listBoxResults = new ListBox();
            label2 = new Label();
            label1 = new Label();
            buttonCalculateNetwork = new Button();
            comboBoxCidr = new ComboBox();
            textBoxAddress = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(listBoxResults);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buttonCalculateNetwork);
            panel1.Controls.Add(comboBoxCidr);
            panel1.Controls.Add(textBoxAddress);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(545, 310);
            panel1.TabIndex = 0;
            // 
            // listBoxResults
            // 
            listBoxResults.Dock = DockStyle.Bottom;
            listBoxResults.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxResults.FormattingEnabled = true;
            listBoxResults.ItemHeight = 15;
            listBoxResults.Location = new Point(0, 126);
            listBoxResults.Name = "listBoxResults";
            listBoxResults.Size = new Size(545, 184);
            listBoxResults.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(210, 30);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 5;
            label2.Text = "CIDR";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 30);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 4;
            label1.Text = "Address";
            // 
            // buttonCalculateNetwork
            // 
            buttonCalculateNetwork.Location = new Point(259, 48);
            buttonCalculateNetwork.Name = "buttonCalculateNetwork";
            buttonCalculateNetwork.Size = new Size(164, 23);
            buttonCalculateNetwork.TabIndex = 3;
            buttonCalculateNetwork.Text = "Netzwerk berechnen";
            buttonCalculateNetwork.UseVisualStyleBackColor = true;
            buttonCalculateNetwork.Click += buttonCalculateNetwork_Click;
            // 
            // comboBoxCidr
            // 
            comboBoxCidr.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCidr.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCidr.FormattingEnabled = true;
            comboBoxCidr.Items.AddRange(new object[] { "32", "31", "30", "29", "28", "27", "26", "25", "24", "23", "22", "21", "20", "19", "18", "17", "16", "15", "14", "13", "12", "11", "10", "9", "8", "7", "6", "5", "4", "3", "2", "1", "0" });
            comboBoxCidr.Location = new Point(210, 48);
            comboBoxCidr.Name = "comboBoxCidr";
            comboBoxCidr.Size = new Size(43, 23);
            comboBoxCidr.TabIndex = 2;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(97, 48);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(107, 23);
            textBoxAddress.TabIndex = 1;
            textBoxAddress.Text = "192.168.87.85";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 310);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "WinFormsNetworkCalculator";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Button buttonCalculateNetwork;
        private ComboBox comboBoxCidr;
        private TextBox textBoxAddress;
        private ListBox listBoxResults;
    }
}
