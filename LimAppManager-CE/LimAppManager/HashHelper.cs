using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace LimAppManager
{
    class HashHelper
    {
        static public string GetMD5Hash(string Message)
        {
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            byte[] Hash;
            
            Hash = MD5.ComputeHash(Encoding.UTF8.GetBytes(Message));

            return Convert.ToBase64String(Hash);
        }

        static public string GetMD5Hash(byte[] Data)
        {
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            byte[] Hash;

            Hash = MD5.ComputeHash(Data);

            return Convert.ToBase64String(Hash);
        }
    }
}
