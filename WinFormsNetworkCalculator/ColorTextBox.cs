using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsNetworkCalculator
{
    internal class ColorTextBox : RichTextBox
    {
        public ColorTextBox()
        {
        }

        public void ShowSubnet(IP4Subnet subnet)
        {
            int cidr = subnet.Cidr;
            // host ID length in the binary-octet string. calculate additional chars used by the dot separators.
            int hostBits = 32 - cidr;
            int hostLength = hostBits + ((hostBits - 1) / 8);

            // fill richTextBox
            WriteLine("", "", "Network prefix              Host ID", 8);
            WriteLine("IP Address:", subnet, hostLength);            // -> IP4Subnet  derives from IP4Address, so it can be used here as IP4Address type
            WriteLine("Netmask:", subnet.Netmask, hostLength);       // -> IP4Netmask derives from IP4Address, so it can be used here as IP4Address type
            WriteLine("Wildcard:", subnet.Wildcard, hostLength);
            WriteLine("NetAddress:", subnet.NetId, hostLength);
            WriteLine("Host min:", subnet.HostMin, hostLength);
            WriteLine("Host max:", subnet.HostMax, hostLength);
            WriteLine("Broadcast:", subnet.Broadcast, hostLength);
            WriteLine("Hosts:", subnet.Hosts.ToString("N0"));
        }

        public void WriteLine(string description, string dezOctet = "", string binOctet = "", int hostLength = 0)
        {
            

            // description / 1. column
            SelectionColor = Color.Black;
            // colorize netmask + wildcard
            if (description == "Netmask:")
                SelectionColor = Color.DarkBlue;
            if (description == "Wildcard:")
                SelectionColor = Color.DarkRed;
            AppendText($"\n   {description,11}");

            // decimal octet / 2. column
            AppendText($"   {dezOctet,-15}");

            // binary octet / 3. column
            SelectionColor = Color.DarkBlue;
            AppendText($"   {binOctet}");

            if (hostLength > 0)
            {
                // select host bits + set to red color
                Select(TextLength - hostLength, hostLength);
                SelectionColor = Color.DarkRed;
                Select(TextLength, 0);    // reset selection / position at end
            }
        }
        public void WriteLine(string description, IP4Address address, int hostLength)
        {
            WriteLine(description, address.DezOctet, address.BinOctet, hostLength);
        }
    }
}
