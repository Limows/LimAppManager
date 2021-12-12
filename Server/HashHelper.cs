using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace LimAppManagerServer
{
    class CredentialsHelper
    {
        static public string GetMD5Hash(string Message)
        {
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            byte[] Hash;
            
            Hash = MD5.ComputeHash(Encoding.UTF8.GetBytes(Message));

            return Convert.ToBase64String(Hash);
        }

        static public bool CreateRecord(string LoginHash, string PassHash, string Record)
        {
            return false;
        }

        static public bool FindRecord(string LoginHash, string PassHash)
        {
            return false;
        }

        static public string FetchRecord(string LoginHash, string PassHash)
        {
            string Record = "";

            return Record;
        }
    }
}