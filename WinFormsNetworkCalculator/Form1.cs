using System.Net;

namespace WinFormsNetworkCalculator
{
    public partial class Form1 : Form
    {
        // list to save/load the items later (XML/DB)
        private List<IP4Subnet> _addresses = new();
        // temporary ip calculation for cidr/ip updates
        private IP4Subnet? _currentSubnet;

        public Form1()
        {
            InitializeComponent();
            textBoxAddress.Text = "192.168.87.85";
            numericUpDownCidr.Value = 24;

            // set netmask preview from numericalUpDown
            UpdateNetmaskPreview();

            // set tbResults preview from textBoxAddress
            UpdateResults();
        }

        private void buttonCalculateNetwork_Click(object sender, EventArgs e)
        {
            string ipAddress = textBoxAddress.Text;
            int cidr = decimal.ToInt32(numericUpDownCidr.Value);

            // check if IPv4 address is invalid -> exit method
            if (!UpdateResults())
            {
                tbResults.Clear();
                tbResults.WriteLine("Invalid IPv4 address!");
                return;
            }

            // add subnet to list
            _addresses.Add(_currentSubnet!);        // ! = _currentSubnet will never be null
        }

        private void numericUpDownCidr_ValueChanged(object sender, EventArgs e)
        {
            UpdateNetmaskPreview();
            UpdateResults();
        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {
            UpdateResults();
        }

        private void buttonCopyClipboard_Click(object sender, EventArgs e)
        {
            CopyToClipboard(tbResults.Text, tbResults.Rtf ?? "");        // ?? check for !null
        }

        private void buttonCopySelected_Click(object sender, EventArgs e)
        {
            CopyToClipboard(tbResults.SelectedText, tbResults.SelectedRtf);
        }

        private void UpdateNetmaskPreview()
        {
            IP4Netmask cidr = new IP4Netmask(decimal.ToInt32(numericUpDownCidr.Value));
            textBoxSubnetmaskDez.Text = cidr.DezOctet;
            textBoxSubnetmaskBin.Text = cidr.BinOctet;
        }

        private bool UpdateResults()
        {
            string ipAddress = textBoxAddress.Text;
            // check if IPv4 address is invalid -> exit method
            if (!IP4Address.CheckDezOctet(ipAddress))
            {
                //textBoxAddress.BackColor = Color.FromArgb(249, 206, 218);
                textBoxAddress.BackColor = ColorTranslator.FromHtml("#FFE1E8");
                return false;
            }

            int cidr = decimal.ToInt32(numericUpDownCidr.Value);
            _currentSubnet = new IP4Subnet(ipAddress, cidr);
            tbResults.ShowSubnet(_currentSubnet);

            textBoxAddress.BackColor = SystemColors.Window;
            return true;
        }


        private void CopyToClipboard(in string text, in string rtfText)
        {
            // Add the textBox data in various formats.
            DataObject dtoResults = new DataObject();
            dtoResults.SetData(DataFormats.Rtf, true, rtfText);
            dtoResults.SetData(DataFormats.Text, true, text);
            // put the data into the clipboard
            Clipboard.SetDataObject(dtoResults);
        }

        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            Stream fileStream;
            SaveFileDialog saveDialog = new();
            // list of file types, FilterIndex is starting here at 1
            saveDialog.Filter = "txt files (*.txt)|*.txt|Rich text files (*.rtf)|*.rtf|All files (*.*)|*.*";
            saveDialog.FilterIndex = 1;
            saveDialog.RestoreDirectory = true;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // try to use selected file(name), if successful it returns a data stream pointing to that file
                if ((fileStream = saveDialog.OpenFile()) != null)
                {
                    if (saveDialog.FilterIndex == 2)
                        tbResults.SaveFile(fileStream, RichTextBoxStreamType.RichText);
                    else
                        tbResults.SaveFile(fileStream, RichTextBoxStreamType.PlainText);

                    fileStream.Close();
                }
            }
        }
    }
}
