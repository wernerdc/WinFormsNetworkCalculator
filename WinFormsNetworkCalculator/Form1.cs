namespace WinFormsNetworkCalculator
{
    public partial class Form1 : Form
    {
        private List<IPv4Address> _addresses = new();
        private IPv4Address _cidrSubnet = new IPv4Address();

        public Form1()
        {
            InitializeComponent();

            // comboBox initialisieren:
            // dropDownStyle dropDownList
            comboBoxCidr.SelectedIndex = 8;         // =cidr 24 for default
            
            // set netmask preview
            _cidrSubnet.updateCidr(int.Parse(comboBoxCidr.Text));
            // [0]=description, [1]=dez-octet, [2]=bin-octet
            string[] netmask = _cidrSubnet.GetNetmaskStrings();
            textBoxSubnetmaskDez.Text = netmask[1];
            textBoxSubnetmaskBin.Text = netmask[2];
        }

        private void buttonCalculateNetwork_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();
            string address = textBoxAddress.Text;
            int cidr = int.Parse(comboBoxCidr.Text);

            // check if address input is a valid IPv4 address
            if (!IPv4Address.CheckDezOctet(address))
            {
                WriteString("Ungültige IPv4 Adresse");
                return;
            }

            // new IPv4Address instance
            IPv4Address ipAddress = new IPv4Address(address, cidr);
            // add to list 
            _addresses.Add(ipAddress);

            WriteString(ipAddress.GetIPv4Strings());
            WriteString(ipAddress.GetNetmaskStrings());
            WriteString(ipAddress.GetWildcardStrings());
            WriteString(ipAddress.GetNetIdStrings());
            WriteString(ipAddress.GetBroadcastStrings());
            WriteString(ipAddress.GetHostMinStrings());
            WriteString(ipAddress.GetHostMaxStrings());
            WriteString(ipAddress.GetHostsStrings());
        }

        // write new line into listBox
        private void WriteString(string description, string dezOctet = "", string binOctet = "")
        {
            string row = $"   {description,11}   {dezOctet,-15}   {binOctet}";
            listBoxResults.Items.Add(row);
        }

        private void WriteString(string[] ipStrings)
        {
            WriteString(ipStrings[0], ipStrings[1], ipStrings[2]);
        }

        private void comboBoxCidr_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update netmask preview
            _cidrSubnet.updateCidr(int.Parse(comboBoxCidr.Text));
            // [0]=description, [1]=dez-octet, [2]=bin-octet
            string[] netmask = _cidrSubnet.GetNetmaskStrings();
            textBoxSubnetmaskDez.Text = netmask[1];
            textBoxSubnetmaskBin.Text = netmask[2];
        }
    }
}
