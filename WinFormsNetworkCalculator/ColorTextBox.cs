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
            Clear();
            int cidr = subnet.Cidr;
            // host ID length in the binary-octet string. Also get the additional chars
            // used by the dot separators.
            int hostBits = 32 - cidr;
            int hostLength = hostBits + ((hostBits - 1) / 8);

            // marker for invalid subnet configurations
            int hostsColor    = (cidr >= 31) ? 2 : 0;
            int broadNetColor = (cidr == 32) ? 2 : 0;

            // fill richTextBox
            WriteLine("CIDR:",       cidr.ToString(),  "Network prefix              Host ID", 8, 1, 1);
            WriteLine("IP Address:", subnet.IP,        hostLength);             
            WriteLine("Netmask:",    subnet.Netmask,   hostLength, 1, 1);       // -> IP4Netmask derives from IP4Address, so it can be used here as IP4Address type
            WriteLine("Wildcard:",   subnet.Wildcard,  hostLength, 2, 2);
            WriteLine("NetAddress:", subnet.NetId,     hostLength, 0, broadNetColor);
            WriteLine("Host min:",   subnet.HostMin,   hostLength, 0, hostsColor);
            WriteLine("Host max:",   subnet.HostMax,   hostLength, 0, hostsColor);
            WriteLine("Broadcast:",  subnet.Broadcast, hostLength, 0, broadNetColor);
            WriteLine("Hosts:", subnet.Hosts.ToString("N0"), "", 0, hostsColor, hostsColor);
        }

        public void WriteLine(
                string description, 
                string dezOctet = "", 
                string binOctet = "", 
                int hostLength = 0,
                int column1Color = 0,
                int column2Color = 0)
        {

            Color[] colors = [ Color.Black, Color.DarkBlue, Color.DarkRed ];
            
            // description / 1. column
            SelectionColor = colors[column1Color];
            AppendText($"\n  {description,11}");

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
                Select(TextLength, 0);    // reset selection + set position to the end
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
