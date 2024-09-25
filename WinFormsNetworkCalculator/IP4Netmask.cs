using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsNetworkCalculator
{
    internal class IP4Netmask : IP4Address
    {
        public IP4Netmask(int cidr)
        {
            this.Address = GetNetmaskDez(cidr);
            this.DezOctet = GetDezOctet(this.Address);
            this.BinOctet = GetBinOctet(this.Address);
            Cidr = cidr;
            Hosts = GetHosts(cidr);
        }
        public IP4Netmask(string dezOctet) : base(dezOctet) {
            Cidr = GetCidrFromDez(this.Address);
            Hosts = GetHosts(Cidr);
        }

        // auto properties, getters only
        public int Cidr { get; }
        public uint Hosts { get; }

        /// <summary>
        /// Bestimme die Netzmaske aus dem CIDR-Suffix
        /// </summary>
        /// <param name="cidr"></param>
        /// <returns></returns>
        private uint GetNetmaskDez(int cidr)
        {
            uint dez = 0;
            for (int i = 0; i < 32; i++)
            {
                if (i < cidr)
                    dez = dez * 2 + 1;
                else
                    dez = dez * 2;
            }
            return dez;
        }

        /// <summary>
        /// Bestimme das CIDR-Suffix aus der 32 Bit Dezimal Adresse
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private int GetCidrFromDez(uint address)
        {
            string netmaskBin = $"{address:B32}";
            int cidr = (netmaskBin.Contains('0')) ? netmaskBin.IndexOf('0') : 32;
            return cidr;
        }

        /// <summary>
        /// Bestimme die Anzahl der Hosts aus dem CIDR-Suffix
        /// </summary>
        /// <param name="cidr"></param>
        /// <returns></returns>
        private uint GetHosts(int cidr)
        {
            uint hosts = 0;
            if (cidr < 32)
                hosts = Convert.ToUInt32(Math.Pow(2, 32 - cidr) - 2);
            return hosts;
        }

        // static methods
        //°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°

        /// <summary>
        /// Prüft ob die Zeichenkette eine gültige IP4-Adresse
        /// in dezimaler Oktett-Darstellung ist.
        /// </summary>
        /// <param name="strDezOctet"></param>
        /// <returns></returns>
        public static new bool CheckDezOctet(string strDezOctet)        // "new" hides derived member method from IP4Address
        {
            if (!strDezOctet.Contains('.'))
                return false;
            string[] strParts = strDezOctet.Split('.');
            if (strParts.Length != 4)
                return false;
            string strBin = "";
            for (int i = 0; i < strParts.Length; i++)
            {
                string strDez = strParts[i];
                strDez = strDez.Trim();
                byte bTest;
                if (!Byte.TryParse(strDez, out bTest))
                    return false;
                // concat binary netmask from byte-parts
                strBin += $"{bTest:B8}";            // String interpolation (:B8) converts a number/byte to
                                                    // binary notation with a length of 8 bits
            }
            // check if hostID has invalid bits set to 1
            return !strBin.Contains("01");
        }
    }
}
