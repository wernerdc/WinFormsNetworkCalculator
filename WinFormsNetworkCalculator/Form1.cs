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

            // set netmask preview from numericalUpDown
            IP4Netmask cidr = new IP4Netmask(decimal.ToInt32(numericUpDownCidr.Value));
            textBoxSubnetmaskDez.Text = cidr.DezOctet;
            textBoxSubnetmaskBin.Text = cidr.BinOctet;

            // set tbResults preview from textBoxAddress
            string ipAddress = textBoxAddress.Text;
            _currentSubnet = new IP4Subnet(ipAddress, cidr.Cidr);
            tbResults.ShowSubnet(_currentSubnet);
        }

        private void numericUpDownCidr_ValueChanged(object sender, EventArgs e)
        {
            // update netmask preview
            IP4Netmask cidr = new IP4Netmask(decimal.ToInt32(numericUpDownCidr.Value));
            textBoxSubnetmaskDez.Text = cidr.DezOctet;
            textBoxSubnetmaskBin.Text = cidr.BinOctet;

            // update tbResults
            string ipAddress = textBoxAddress.Text;
            // check if IPv4 address is invalid -> exit method
            if (!IP4Address.CheckDezOctet(ipAddress))
                return;

            _currentSubnet = new IP4Subnet(ipAddress, cidr.Cidr);
            tbResults.Clear();
            tbResults.ShowSubnet(_currentSubnet);
        }

        private void buttonCalculateNetwork_Click(object sender, EventArgs e)
        {
            string ipAddress = textBoxAddress.Text;
            int nCidr = decimal.ToInt32(numericUpDownCidr.Value);
            tbResults.Clear();

            // check if IPv4 address is invalid -> exit method
            if (!IP4Address.CheckDezOctet(ipAddress))
            {
                tbResults.WriteLine("Ungültige IPv4 Adresse!");
                return;
            }

            // new IP4Subnet instance
            IP4Subnet subnet = new IP4Subnet(ipAddress, nCidr);
            // add to list 
            _addresses.Add(subnet);
            _currentSubnet = subnet;

            // display results in text box
            tbResults.ShowSubnet(subnet);
        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {
            // update tbResults
            string ipAddress = textBoxAddress.Text;
            // check if IPv4 address is invalid -> exit method
            if (!IP4Address.CheckDezOctet(ipAddress))
                return;

            int cidr = decimal.ToInt32(numericUpDownCidr.Value);
            _currentSubnet = new IP4Subnet(ipAddress, cidr);
            tbResults.Clear();
            tbResults.ShowSubnet(_currentSubnet);
        }
    }
}
