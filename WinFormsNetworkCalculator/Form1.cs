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

            // check if address input is a valid IPv4 address
            if (!IP4Address.CheckDezOctet(ipAddress))
            {
                WriteRichText("Ungültige IPv4 Adresse!");
                return;
            }

            // new IP4Subnet instance
            IP4Subnet subnet = new IP4Subnet(ipAddress, nCidr);
            // add to list 
            _addresses.Add(subnet);

            // fill richTextBox
            richTextBoxResults.Clear();
            WriteRichText("", "", "Network prefix              Host ID", 24);
            WriteRichText("IP Address:", subnet, nCidr);            // -> IP4Subnet  derives from IP4Address, so it can be used here as IP4Address type
            WriteRichText("Netmask:",    subnet.Netmask, nCidr);    // -> IP4Netmask derives from IP4Address, so it can be used here as IP4Address type
            WriteRichText("Wildcard:",   subnet.Wildcard, nCidr);
            WriteRichText("NetAddress:", subnet.NetId, nCidr);
            WriteRichText("Host min:",   subnet.HostMin, nCidr);
            WriteRichText("Host max:",   subnet.HostMax, nCidr);
            WriteRichText("Broadcast:",  subnet.Broadcast, nCidr);
            WriteRichText("Hosts:",      subnet.Hosts.ToString("N0"));
        }

        private void WriteRichText(string description, string dezOctet = "", string binOctet = "", int cidr = -1)
        {
            // host ID length in the binary-octet string. calculate additional chars used by the dot separators.
            int hostBits = 32 - cidr;
            int hostBitsLength = hostBits + ((hostBits - 1) / 8);

            // description in black
            richTextBoxResults.SelectionColor = Color.Black;
            
            // colorize netmask + wildcard
            if (description == "Netmask:")
                richTextBoxResults.SelectionColor = Color.DarkBlue;
            if (description == "Wildcard:")
                richTextBoxResults.SelectionColor = Color.DarkRed;
            richTextBoxResults.AppendText($"\n   {description,11}");
            
            
            // decimal octet / 2. column
            richTextBoxResults.AppendText($"   {dezOctet,-15}");

            // binary octet / 3. column
            richTextBoxResults.SelectionColor = Color.DarkBlue;
            richTextBoxResults.AppendText($"   {binOctet}");

            if (cidr != -1)
            {
                // select host bits + set red color
                richTextBoxResults.Select(richTextBoxResults.TextLength - hostBitsLength, hostBitsLength);
                richTextBoxResults.SelectionColor = Color.DarkRed;
                richTextBoxResults.Select(richTextBoxResults.TextLength, 0);    // reset selection/position
            }
        }
        private void WriteRichText(string description, IP4Address address, int cidr)
        {
            WriteRichText(description, address.DezOctet, address.BinOctet, cidr);
        }

        
    }
}
