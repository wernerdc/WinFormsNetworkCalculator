using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsNetworkCalculator
{
    public class IPv4Address
    {
        long IPv4 { get; }
        int Cidr { get; }
        long Netmask { get; }
        long Wildcard { get; }
        long NetId { get; }
        long Broadcast { get; }

        public IPv4Address(string ipV4, string cidr)
        {
            IPv4 = GetDez(ipV4);
            Cidr = int.Parse(cidr);
            Netmask = GetNetmaskDez(Cidr);
            Wildcard = GetWildcardDez();
            NetId = GetNetIdDez();
            Broadcast = GetBroadcastDez();
        }


        /// <summary>
        /// Berechnet aus der IP4-Oktett-Darstellung die interne 32Bit-Zahl in
        /// Dezimaldarstellung. Diese dient als Grundlage für weitere Berechnungen.
        /// </summary>
        /// <param name="strDezOctet"></param>
        /// <returns></returns>
        private long GetDez(string strDezOctet)
        {
            long ip4 = 0;
            string[] strParts = strDezOctet.Split(new string[] { "." },
                    StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < 4; i++)
            {
                string strDez = strParts[i];
                strDez = strDez.Trim();
                byte byteOctet = 0;
                if (Byte.TryParse(strDez, out byteOctet))
                    ip4 = ip4 * 256 + byteOctet;
            }
            return ip4;
        }

        /// <summary>
        /// Bestimme die Netzmaske aus dem CIDR-Suffix
        /// </summary>
        /// <param name="cidr"></param>
        /// <returns></returns>
        private long GetNetmaskDez(int cidr)
        {
            long lDez = 0;
            for (int i = 0; i < 32; i++)
            {
                if (i < cidr)
                    lDez = lDez * 2 + 1;
                else
                    lDez = lDez * 2;
            }
            return lDez;
        }

        private long GetWildcardDez()
        {
            // Bitwise complement operator ~
            // The ~ operator produces a bitwise complement of its operand by reversing each bit
            uint wildcard = Convert.ToUInt32(Netmask);      // unsigned integer (uint) to avoid negative value from ~ operator
            
            return ~wildcard;
        }

        private long GetNetIdDez()
        {
            // Logical AND operator &
            // The & operator computes the bitwise logical AND of its integral operands:
            return IPv4 & Netmask;
        }
        
        private long GetBroadcastDez()
        {
            // Logical OR operator |
            // The | operator computes the bitwise logical OR of its integral operands:
            return IPv4 | Wildcard;
        }

        public string[] GetIPv4Strings()
        {
            return CalcAddressStrings("Address:", IPv4);
        }
        
        public string[] GetNetmaskStrings()
        {
            return CalcAddressStrings("Netmask:", Netmask);
        }
        
        public string[] GetWildcardStrings()
        {
            return CalcAddressStrings("Wildcard:", Wildcard);
        }
        
        public string[] GetNetIdStrings()
        {
            return CalcAddressStrings("NetAddress:", NetId);
        }

        public string[] GetBroadcastStrings()
        {
            return CalcAddressStrings("Broadcast:", Broadcast);
        }

        public string[] GetHostMinStrings()
        {
            return CalcAddressStrings("Host min:", NetId + 1);
        }

        public string[] GetHostMaxStrings()
        {
            return CalcAddressStrings("Host max:", Broadcast - 1);
        }

        private string[] CalcAddressStrings(string description, long ipAddress)
        {
            string[] ipStrings = [ description,
                                   GetDezOctet(ipAddress),
                                   GetBinOctet(ipAddress) ];
            return ipStrings;
        }

        /// <summary>
        /// Bestimme die Anzahl der Hosts aus dem CIDR-Suffix
        /// </summary>
        /// <param name="cidr"></param>
        /// <returns></returns>
        public string[] GetHostsStrings()
        {
            long lhosts = 0;
            if (Cidr < 32)
                lhosts = Convert.ToInt64(Math.Pow(2, 32 - Cidr) - 2);
            return new string[] { "Hosts:", lhosts.ToString(), "" };
        }

        /// <summary>
        /// Bestimme aus der 32Bit-Zahl die IP4 Oktett-Darstellung
        /// </summary>
        /// <param name="ip4"></param>
        /// <returns></returns>
        private string GetDezOctet(long ip4)
        {
            string strDezOctet = "";
            long lMod = 0;
            long lDiv = ip4;
            for (int i = 0; i < 4; i++)
            {
                lMod = lDiv % 256;
                lDiv = lDiv / 256;
                strDezOctet = $"{lMod,3}{strDezOctet}";     // string format {lMod,3} align 3 digits to the right
                if (i < 3)
                    strDezOctet = "." + strDezOctet;
            }
            return strDezOctet;
        }

        /// <summary>
        /// Bestimme aus der 32Bit-Zahl die binäre Oktett-Darstellung
        /// </summary>
        /// <param name="ip4"></param>
        /// <returns></returns>
        private string GetBinOctet(long ip4)
        {
            // :B32 -> String Format, Binärdarstellung mit 32 Stellen
            string strBin = $"{ip4:B32}";
            string binOctet = "";
            for (int i = 0; i < 4; i++)
            {
                binOctet += strBin.Substring(i * 8, 8);
                if (i < 3)
                    binOctet += ".";
            }
            return binOctet;
        }

        /// <summary>
        /// Prüft ob die Zeichenkette eine gültige IP4-Adresse
        /// in Oktett-Darstellung ist.
        /// </summary>
        /// <param name="strDezOctet"></param>
        /// <returns></returns>
        public static bool CheckDezOctet(string strDezOctet)
        {
            if (!strDezOctet.Contains("."))
                return false;
            string[] strParts = strDezOctet.Split(new string[] { "." },
                    StringSplitOptions.RemoveEmptyEntries);
            if (strParts.Length != 4)
                return false;
            for (int i = 0; i < strParts.Length; i++)
            {
                string strDez = strParts[i];
                strDez = strDez.Trim();
                byte bTest;
                if (!Byte.TryParse(strDez, out bTest))
                    return false;
            }
            return true;
        }
    }
}
