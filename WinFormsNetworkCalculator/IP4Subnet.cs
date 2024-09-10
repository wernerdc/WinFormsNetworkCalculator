using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsNetworkCalculator
{
    internal class IP4Subnet : IP4Address
    {
        public IP4Subnet(string ipDezOctet, int cidr) : base(ipDezOctet)
        {
            Netmask = new IP4Netmask(cidr);
            Wildcard = new IP4Address(GetWildcardDez());
            NetId = new IP4Address(GetNetIdDez());
            Broadcast = new IP4Address(GetBroadcastDez());
            HostMin = new IP4Address(GetHostMin(cidr));
            HostMax = new IP4Address(GetHostMax(cidr));
            //Hosts = GetHosts(cidr);
        }
        // constructor with 1 parameter
        public IP4Subnet(int cidr) : this("0.0.0.0", cidr) 
        { 
        }

        //public int Cidr { get; }
        public IP4Netmask Netmask { get; }
        //public IP4Address Netmask { get; }
        public IP4Address Wildcard { get; }
        public IP4Address NetId { get; }
        public IP4Address Broadcast { get; }
        public IP4Address HostMin { get; }
        public IP4Address HostMax { get; }
        //public uint Hosts { get; }

/*
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
*/
        private uint GetWildcardDez()
        {
            // Bitwise complement operator ~
            // The ~ operator produces a bitwise complement of its operand by reversing each bit
            // unsigned integer (uint) to avoid negative value from ~ operator
            return ~Netmask.Address;
        }

        private uint GetNetIdDez()
        {
            // Logical AND operator &
            // The & operator computes the bitwise logical AND of its integral operands:
            return this.Address & Netmask.Address;
        }

        private uint GetBroadcastDez()
        {
            // Logical OR operator |
            // The | operator computes the bitwise logical OR of its integral operands:
            return this.Address | Wildcard.Address;
        }

        private uint GetHostMin(int cidr)
        {
            uint hostMin = NetId.Address + 1;
            if (cidr > 30)
                hostMin = 0;

            return hostMin;
        }
        
        private uint GetHostMax(int cidr)
        {
            uint hostMax = Broadcast.Address - 1;
            if (cidr > 30)
                hostMax = 0;

            return hostMax;
        }

        /*/// <summary>
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
        }*/
    }
}
