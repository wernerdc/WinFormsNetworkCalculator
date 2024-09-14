using System.Net;

namespace WinFormsNetworkCalculator
{
    public partial class Form1 : Form
    {
        // list to save/load the items later (XML/DB)
        private List<IP4Subnet> _addresses = new();
        // tempoary ip calculation for cidr updates
        private IP4Subnet _currentSubnet;

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
            _addresses.Add(_currentSubnet);
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

        private void buttonCopyClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbResults.Text);
        }

        private void buttonCopySelected_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbResults.SelectedText);
        }
    }
}
