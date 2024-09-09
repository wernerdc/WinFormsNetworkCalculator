namespace WinFormsNetworkCalculator
{
    public partial class Form1 : Form
    {
        // list to save/load the items later (XML/DB)
        private List<IP4Subnet> _addresses = new();

        public Form1()
        {
            InitializeComponent();


            // set netmask preview from numericalUpDown input
            IP4Subnet cidr = new IP4Subnet(decimal.ToInt32(numericUpDownCidr.Value));
            textBoxSubnetmaskDez.Text = cidr.Netmask.DezOctet;
            textBoxSubnetmaskBin.Text = cidr.Netmask.BinOctet;
/*
            // comboBox initialisieren:
            // dropDownStyle dropDownList = predefined values only
            comboBoxCidr.SelectedIndex = 8;         // =nCidr 24 for default
            //set netmask preview
            IP4Subnet cidr = new IP4Subnet(int.Parse(comboBoxCidr.Text));
*/
        }

        private void buttonCalculateNetwork_Click(object sender, EventArgs e)
        {
            //listBoxResults.Items.Clear();
            string address = textBoxAddress.Text;
            //int nCidr = int.Parse(comboBoxCidr.Text);
            int nCidr = decimal.ToInt32(numericUpDownCidr.Value);

            // check if address input is a valid IPv4 address
            if (!IP4Address.CheckDezOctet(address))
            {
                WriteString("Ungültige IPv4 Adresse!");
                return;
            }

            // new IP4Subnet instance
            IP4Subnet subnet = new IP4Subnet(address, nCidr);
            // add to list 
            _addresses.Add(subnet);
/*
            // fill listBox
            WriteString("Address:", subnet);            // -> IP4Subnet inherited from IP4Address, so it can be used here as IP4Address type
            WriteString("Netmask:", subnet.Netmask);
            WriteString("Wildcard:", subnet.Wildcard);
            WriteString("NetAddress:", subnet.NetId);
            WriteString("Host min:", subnet.HostMin);
            WriteString("Host max:", subnet.HostMax);
            WriteString("Broadcast:", subnet.Broadcast);
            WriteString("Hosts:", subnet.Hosts.ToString());
*/
            // fill richTextBox
            richTextBoxResults.Clear();
            WriteRichText("", "", "Network prefix              Host ID", 24);
            WriteRichText("Address:", subnet, nCidr);            // -> IP4Subnet inherited from IP4Address, so it can be used here as IP4Address type
            WriteRichText("Netmask:", subnet.Netmask, nCidr);
            WriteRichText("Wildcard:", subnet.Wildcard, nCidr);
            WriteRichText("NetAddress:", subnet.NetId, nCidr);
            WriteRichText("Host min:", subnet.HostMin, nCidr);
            WriteRichText("Host max:", subnet.HostMax, nCidr);
            WriteRichText("Broadcast:", subnet.Broadcast, nCidr);
            WriteRichText("Hosts:", subnet.Hosts.ToString("N0"));
        }

        private void WriteRichText(string description, string dezOctet = "", string binOctet = "", int cidr = -1)
        {
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
                // select host bits + colorize them red
                richTextBoxResults.Select(richTextBoxResults.TextLength - hostBitsLength, hostBitsLength);
                richTextBoxResults.SelectionColor = Color.DarkRed;
                richTextBoxResults.Select(richTextBoxResults.TextLength, 0);    // reset selection/position
            }
        }
        private void WriteRichText(string description, IP4Address address, int cidr)
        {
            WriteRichText(description, address.DezOctet, address.BinOctet, cidr);
        }


        // write new line into listBox
        private void WriteString(string description, string dezOctet = "", string binOctet = "")
        {
            string row = $"  {description,11}   {dezOctet,-15}   {binOctet}";
            //listBoxResults.Items.Add(row);
        }
        // overload with 2 parameters
        private void WriteString(string description, IP4Address address)
        {
            WriteString(description, address.DezOctet, address.BinOctet);
        }
        private void numericUpDownCidr_ValueChanged(object sender, EventArgs e)
        {
            // update netmask preview
            IP4Subnet cidr = new IP4Subnet(decimal.ToInt32(numericUpDownCidr.Value));
            textBoxSubnetmaskDez.Text = cidr.Netmask.DezOctet;
            textBoxSubnetmaskBin.Text = cidr.Netmask.BinOctet;
        }
/*
        private void comboBoxCidr_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update netmask preview
            IP4Subnet cidr = new IP4Subnet(int.Parse(comboBoxCidr.Text));
            textBoxSubnetmaskDez.Text = cidr.Netmask.DezOctet;
            textBoxSubnetmaskBin.Text = cidr.Netmask.BinOctet;
        }
*/
    }
}
