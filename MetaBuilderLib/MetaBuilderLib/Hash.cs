using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace MetaBuilderLib
{
    public class Hash
    {
        static public string GetMD5Hash(string Message)
        {
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            byte[] Hash;

            Hash = MD5.ComputeHash(Encoding.UTF8.GetBytes(Message));

            return BitConverter.ToString(Hash).Replace("-", "");
        }

        static public string GetMD5Hash(byte[] Data)
        {
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            byte[] Hash;

            Hash = MD5.ComputeHash(Data);

            return BitConverter.ToString(Hash).Replace("-", "");
        }
    }
}
