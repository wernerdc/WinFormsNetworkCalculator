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
            uint lDez = 0;
            for (int i = 0; i < 32; i++)
            {
                if (i < cidr)
                    lDez = lDez * 2 + 1;
                else
                    lDez = lDez * 2;
            }
            return lDez;
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
    }

}
