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

            // mark invalid subnet configuration in red
            int hostsColor = 0;
            int broadNetColor = 0;
            if (cidr >= 31)
            {
                hostsColor = 2;
                if (cidr == 32)
                {
                    broadNetColor = 2;
                }
            }

            // fill richTextBox
            WriteLine("", "", "Network prefix              Host ID", 8);
            WriteLine("IP Address:", subnet,           hostLength);             // -> IP4Subnet  derives from IP4Address, so it can be used here as IP4Address type
            WriteLine("Netmask:",    subnet.Netmask,   hostLength, 1, 1);       // -> IP4Netmask derives from IP4Address, so it can be used here as IP4Address type
            WriteLine("Wildcard:",   subnet.Wildcard,  hostLength, 2, 2);
            WriteLine("NetAddress:", subnet.NetId,     hostLength, 0, broadNetColor);
            WriteLine("Host min:",   subnet.HostMin,   hostLength, 0, hostsColor);
            WriteLine("Host max:",   subnet.HostMax,   hostLength, 0, hostsColor);
            WriteLine("Broadcast:",  subnet.Broadcast, hostLength, 0, broadNetColor);
            WriteLine("Hosts:", subnet.Hosts.ToString("N0"), "", 0, hostsColor, hostsColor);
        }

        //public void WriteLine(string description, string dezOctet = "", string binOctet = "", int hostLength = 0)
        public void WriteLine(
                string description, 
                string dezOctet = "", 
                string binOctet = "", 
                int hostLength = 0,
                int column1Color = 0,
                int column2Color = 0)
        {

            Color[] colors = { Color.Black, Color.DarkBlue, Color.DarkRed };
            
            // description / 1. column
            SelectionColor = colors[column1Color];
            AppendText($"\n   {description,11}");

            // decimal octet / 2. column
            SelectionColor = colors[column2Color];
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
        public void WriteLine(
                string description, 
                IP4Address address, 
                int hostLength,
                int column1Color = 0,
                int column2Color = 0)
        {
            WriteLine(
                    description, 
                    address.DezOctet, 
                    address.BinOctet, 
                    hostLength,
                    column1Color,
                    column2Color);
        }
    }
}
