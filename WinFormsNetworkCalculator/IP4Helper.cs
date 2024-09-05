using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsNetworkCalculator
{
    public class IP4Helper
    {
        /// <summary>
        /// Prüft ob die Zeichenkette eine gültige IP4-Adresse
        /// in Oktett-Darstellung ist.
        /// </summary>
        /// <param name="strDezOctet"></param>
        /// <returns></returns>
        static public bool CheckDezOctet(string strDezOctet)
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
        /// <summary>
        /// Prüft ob die angegebene Zahl ein gültiges CIDR Suffix ist
        /// </summary>
        /// <param name="strCidr"></param>
        /// <returns></returns>
        static public bool CheckCidr(string strCidr)
        {
            if (String.IsNullOrEmpty(strCidr))
                return false;
            int nCidr;
            if (!Int32.TryParse(strCidr, out nCidr))
                return false;
            if ((nCidr < 0) || (nCidr > 32))
                return false;
            return true;
        }
        /// <summary>
        /// Berechnet aus der IP4-Oktett-Darstellung die interne 32Bit-Zahl in
        /// Dezimaldarstellung. Diese dient als Grundlage für weitere Berechnungen.
        /// </summary>
        /// <param name="strDezOctet"></param>
        /// <returns></returns>
        static public long GetDez(string strDezOctet)
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
        /// Berechnet aus der Binär-Oktett-Darstellung die interne 32Bit-Zahl in
        /// Dezimaldarstellung. Diese dient als Grundlage für weitere Berechnungen.
        /// </summary>
        /// <param name="strBinOctet"></param>
        /// <returns></returns>
        static public long GetDezFromBin(string strBinOctet)        // unused
        {
            long ip4 = 0;
            string[] strParts = strBinOctet.Split(new string[] { "." },
                    StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < 4; i++)
            {
                string strBin = strParts[i];
                strBin = strBin.Trim();
                byte byteOctet = Convert.ToByte(strBin, 2);
                ip4 = ip4 * 256 + byteOctet;
            }
            return ip4;
        }

        /// <summary>
        /// Bestimme aus der 32Bit-Zahl die binäre Oktett-Darstellung
        /// </summary>
        /// <param name="ip4"></param>
        /// <returns></returns>
        static public string GetBinOctet(long ip4)
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
        static public string GetBinOctet_alt(long ip4)
        {
            string strBin = "";
            long lMod = 0;
            long lDiv = ip4;
            //for Schleife notwendig für führende Nullen
            for (int i = 0; i < 32; i++)
                {
                    lMod = lDiv % 2;
                    lDiv = lDiv / 2;
                    strBin = lMod.ToString() + strBin;
                    // Oktettdarstellung -> Punkt einfügen
                    if (i % 8 == 7 && i > 0 && i < 31)
                        strBin = "." + strBin;
                }
            return strBin;
        }
        /// <summary>
        /// Bestimme die Wildcard aus dem CIDR-Suffix
        /// </summary>
        /// <param name="cidr"></param>
        /// <returns></returns>
        static public long GetWildcardDez(int cidr)
        {
            long lDez = 0;
            for (int i = 0; i < (32 - cidr); i++)
            {
                lDez = lDez * 2 + 1;
            }
            return lDez;
        }
        /// <summary>
        /// Bestimme aus der 32Bit-Zahl die IP4 Oktett-Darstellung
        /// </summary>
        /// <param name="ip4"></param>
        /// <returns></returns>
        static public string GetDezOctet(long ip4)
        {
            string strDezOctet = "";
            long lMod = 0;
            long lDiv = ip4;
            //while (uDiv > 0)
            for (int i = 0; i < 4; i++)
            {
                lMod = lDiv % 256;
                lDiv = lDiv / 256;
                strDezOctet = lMod.ToString() + strDezOctet;
                if (i < 3)
                    strDezOctet = "." + strDezOctet;
            }
            return strDezOctet;
        }

        /// <summary>
        /// Bestimme aus der Binär-Oktett-Darstellung die IP4 Oktett-Darstellung
        /// </summary>
        /// <param name="strBinOctet"></param>
        /// <returns></returns>
        static public string GetDezOctetFromBin(string strBinOctet)         // unused
        {
            string strDezOctet = "";
            string[] strParts = strBinOctet.Split(new string[] { "." },
                    StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < 4; i++)
            {
                strParts[i] = strParts[i].Trim();
                byte byteOctet = 0;
                byteOctet = Convert.ToByte(strParts[i], 2);
                strDezOctet += byteOctet.ToString();
                if (i < 3)
                    strDezOctet += ".";
            }
            return strDezOctet;
        }

        /// <summary>
        /// Bestimme die Anzahl der Hosts aus dem CIDR-Suffix
        /// </summary>
        /// <param name="cidr"></param>
        /// <returns></returns>
        static public long GetHosts(int cidr)
        {
            long lhosts = 0;
            if (cidr < 32)
                lhosts = Convert.ToInt64(Math.Pow(2, 32 - cidr) - 2);
            return lhosts;
        }
        /// <summary>
        /// Bestimme die Netzmaske aus dem CIDR-Suffix
        /// </summary>
        /// <param name="cidr"></param>
        /// <returns></returns>
        static public long GetNetmaskDez(int cidr)
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
    }

}

