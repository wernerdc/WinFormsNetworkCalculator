namespace WinFormsNetworkCalculator
{
    public partial class Form1 : Form
    {
        // list to save/load the items later (XML/DB)
        private List<IP4Subnet> _addresses = new();

        public Form1()
        {
            InitializeComponent();

            // set netmask preview from numericalUpDown
            IP4Netmask cidr = new IP4Netmask(decimal.ToInt32(numericUpDownCidr.Value));
            textBoxSubnetmaskDez.Text = cidr.DezOctet;
            textBoxSubnetmaskBin.Text = cidr.BinOctet;
        }

        private void numericUpDownCidr_ValueChanged(object sender, EventArgs e)
        {
            // update netmask preview
            IP4Netmask cidr = new IP4Netmask(decimal.ToInt32(numericUpDownCidr.Value));
            textBoxSubnetmaskDez.Text = cidr.DezOctet;
            textBoxSubnetmaskBin.Text = cidr.BinOctet;
        }

        private void buttonCalculateNetwork_Click(object sender, EventArgs e)
        {
            string ipAddress = textBoxAddress.Text;
            int nCidr = decimal.ToInt32(numericUpDownCidr.Value);
            tbResults.Clear();

            // check if address input is a valid IPv4 address
            if (!IP4Address.CheckDezOctet(ipAddress))
            {
                //WriteRichText("Ungültige IPv4 Adresse!");
                tbResults.WriteLine("Ungültige IPv4 Adresse!");
                return;
            }

            // new IP4Subnet instance
            IP4Subnet subnet = new IP4Subnet(ipAddress, nCidr);
            // add to list 
            _addresses.Add(subnet);

            // display results in text box
            tbResults.ShowSubnet(subnet);
        }
    }
}
