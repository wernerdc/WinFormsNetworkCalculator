namespace WinFormsNetworkCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // comboBox initialisieren:
            // dropDownStyle dropDownList
            comboBoxCidr.SelectedIndex = 8;
        }

        private void buttonCalculateNetwork_Click(object sender, EventArgs e)
        {
            string address = textBoxAddress.Text;
            int cidr = int.Parse(comboBoxCidr.Text);

            // check if address input is a valid IPv4 address
            if (!IP4Helper.CheckDezOctet(address)) {
                WriteString("Ungültige IPv4 Adresse!"); 
                return;
            }
            
            // ipv4 in decimal as base for folllowing calculations
            long ipv4 = IP4Helper.GetDez(address);

            // 1. address output
            string dezOctet = IP4Helper.GetDezOctet(ipv4);
            string binOctet = IP4Helper.GetBinOctet(ipv4);

            WriteString("GetDez", ipv4.ToString(), "");

            string stringBinOctet = "11111111";
            byte byteBinOctet = Convert.ToByte(stringBinOctet, 2);      // ToByte at base of "2"
            WriteString("binToDez", byteBinOctet.ToString(), "");

            WriteString("Address:", dezOctet, binOctet);

            // 2. netmask output
            long netmask = IP4Helper.GetNetmaskDez(cidr);
            string netmaskDezOctet = IP4Helper.GetDezOctet(netmask);
            string netmaskBinOctet = IP4Helper.GetBinOctet(netmask);

            WriteString("Netmask:", netmaskDezOctet, netmaskBinOctet);

            // 3. wildcard output
            long wildcard = IP4Helper.GetWildcardDez(cidr);
            string wildcardDezOctet = IP4Helper.GetDezOctet(wildcard);
            string wildcardBinOctet = IP4Helper.GetBinOctet(wildcard);

            WriteString("Wildcard:", wildcardDezOctet, wildcardBinOctet);

            // 4. network ID/address
            //string netIdAddress = "";
            //for (int i = 0; i < netmaskBinOctet.Length; i++)
            //{
            //    if (netmaskBinOctet[i].ToString() == ".")
            //    {
            //        netIdAddress += ".";
            //        continue;
            //    }
            //    bool netmaskChar = netmaskBinOctet[i].;
            //    string addressChar = binOctet[i].ToString();
            //    if (netmaskChar & addressChar == 1)
            //}

            // test bin to dez/octet
            string netAddress = IP4Helper.GetDezOctetFromBin(wildcardBinOctet);
            long tempDezFromBin = IP4Helper.GetDezFromBin(wildcardBinOctet);

            WriteString("octet from bin", netAddress, wildcardBinOctet);
            WriteString("dez from bin  ", netAddress, IP4Helper.GetDezOctet(tempDezFromBin));

        }

        // write new line into listBox
        private void WriteString(string description, string dezOctet="", string binOctet="")
        {
            string row = $"   {description,11}   {dezOctet,-15}   {binOctet}";
            listBoxResults.Items.Add(row);
        }
    }
}
