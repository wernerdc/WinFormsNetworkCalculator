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

        private void buttonCalculateNetwork_Click(object sender, EventArgs e) {
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
            long networkIdAddress = netmask & ipv4;         // bitwise AND
            string netIdDezOctet = IP4Helper.GetDezOctet(networkIdAddress);
            string netIdBinOctet = IP4Helper.GetBinOctet(networkIdAddress);
            WriteString("NetAddress:", netIdDezOctet, netIdBinOctet);

            // 5. broadcast output
            long broadcast = wildcard | ipv4;               // bitwise OR
            string broadcastDezOctet = IP4Helper.GetDezOctet(broadcast);
            string broadcastBinOctet = IP4Helper.GetBinOctet(broadcast);
            WriteString("Broadcast:", broadcastDezOctet, broadcastBinOctet);

            // 6+7 min max host ip
            string minHostDezOctet = IP4Helper.GetDezOctet(networkIdAddress + 1);
            string minHostBinOctet = IP4Helper.GetBinOctet(networkIdAddress + 1);
            WriteString("Host min:", minHostDezOctet, minHostBinOctet);
            
            string maxHostDezOctet = IP4Helper.GetDezOctet(broadcast - 1);
            string maxHostBinOctet = IP4Helper.GetBinOctet(broadcast - 1);
            WriteString("Host max:", maxHostDezOctet, maxHostBinOctet);

            // number of available host ips
            long hosts = IP4Helper.GetHosts(cidr);
            WriteString("Hosts:", hosts.ToString());

            // Test & Debugging
            //°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°

            //WriteString("GetDez", ipv4.ToString(), "");

            //string stringBinOctet = "11111111";
            //byte byteBinOctet = Convert.ToByte(stringBinOctet, 2);      // ToByte at base of "2"
            //string testDezToBin = Convert.ToString(ipv4, 2);
            //WriteString("binToDez", byteBinOctet.ToString(), $"{ipv4:###\\.###\\.###\\.###}");
            //WriteString("binToDez", byteBinOctet.ToString(), $"{testDezToBin}");
            //WriteString("binToDez", byteBinOctet.ToString(), $"{testDezToBin:00000000\\.00000000\\.00000000\\.00000000}");

            //string netId = "";
            //string[] binNetmaskParts = netmaskBinOctet.Split(new string[] { "." },
            //        StringSplitOptions.RemoveEmptyEntries);
            //string[] binIpParts = binOctet.Split(new string[] { "." },
            //        StringSplitOptions.RemoveEmptyEntries);
            //for (int i = 0; i < 4; i++) {
            //    byte bNetmask = Convert.ToByte(binNetmaskParts[i], 2);
            //    byte bIp = Convert.ToByte(binIpParts[i], 2);
            //    int octet = bNetmask & bIp;

            //    //netId += $"{Convert.ToString(octet, 2),8:00000000}";
            //    netId += $"{octet:B8}";
            //    if (i < 3)
            //        netId += ".";
            //}
            //WriteString("NetworkID", IP4Helper.GetDezOctetFromBin(netId), netId);



            //string netIdAddress = "";
            //for (int i = 0; i < netmaskBinOctet.Length; i++)
            //{
            //    if (netmaskBinOctet[i] == '.')
            //    {
            //        netIdAddress += ".";
            //        continue;
            //    }
            //    char netmaskChar = netmaskBinOctet[i];
            //    char addressChar = binOctet[i];
            //    //if (netmaskChar & addressChar == 1)
            //}

            // test bin to dez/octet
            //string netAddress = IP4Helper.GetDezOctetFromBin(wildcardBinOctet);
            //long tempDezFromBin = IP4Helper.GetDezFromBin(wildcardBinOctet);

            //WriteString("octet from bin", netAddress, wildcardBinOctet);
            //WriteString("dez from bin  ", netAddress, IP4Helper.GetDezOctet(tempDezFromBin));

        }

        // write new line into listBox
        private void WriteString(string description, string dezOctet="", string binOctet="")
        {
            string row = $"   {description,11}   {dezOctet,-15}   {binOctet}";
            listBoxResults.Items.Add(row);
        }
    }
}
