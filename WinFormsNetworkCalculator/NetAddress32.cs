﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsNetworkCalculator
{
    internal class NetAddress32
    {
        public uint Address {  get;  set; }
        public string DezOctet { get; set; }
        public string BinOctet { get; set; }

        // constructor for 32 bit decimal address
        public NetAddress32(uint address)
        { 
            Address = address;
            DezOctet = GetDezOctet(address);
            BinOctet = GetBinOctet(address);
        }
        // constructor for decimal-octet notation
        public NetAddress32(string dezOctet)
        {
            Address = GetDezFromOctet(dezOctet);
            DezOctet = dezOctet;
            BinOctet = GetBinOctet(Address);
        }
        // constructor without parameters, initialized with "0"
        public NetAddress32() : this(0) { }

        /// <summary>
        /// Berechnet aus der IP4-Oktett-Darstellung die interne 32Bit-Zahl in
        /// Dezimaldarstellung. Diese dient als Grundlage für weitere Berechnungen.
        /// </summary>
        /// <param name="strDezOctet"></param>
        /// <returns></returns>
        protected uint GetDezFromOctet(string strDezOctet)
        {
            uint ip4 = 0;
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
        /// Bestimme aus der 32Bit-Zahl die IP4 Oktett-Darstellung
        /// </summary>
        /// <param name="ip4"></param>
        /// <returns></returns>
        protected string GetDezOctet(uint ip4)
        {
            string strDezOctet = "";
            uint lMod = 0;
            uint lDiv = ip4;
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
        protected string GetBinOctet(uint ip4)
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

        // static methods
        //°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°

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
