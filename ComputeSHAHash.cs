using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.WebUtilities;

namespace csharpUtilites
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //ppWC0qOwzVqU6iLxNxqGWA
            string accesstoken = "3b190870002628afd2a4bea919da7f993ff92e08";
            string alg = "RS256";
            string toHash = "SHA" + 256;
            byte[] byteArray = ComputeSha256HashArray(accesstoken,1);
            
            string finalValue = WebEncoders.Base64UrlEncode(byteArray.Take(16).ToArray());

        }


        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        static byte[] ComputeSha256HashArray(string rawData,int SHAAlgoType)
        {
            byte[] bytes = null;
            // Create a SHA256  
            switch (SHAAlgoType)
            {
                case 1:
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        // ComputeHash - returns byte array  
                        bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                    }
                    break;
                case 2:
                    using (SHA384 sha384Hash = SHA384.Create())
                    {
                        // ComputeHash - returns byte array  
                        bytes = sha384Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                    }
                    break;
                case 3:
                    using (SHA512 sha512Hash = SHA512.Create())
                    {
                        // ComputeHash - returns byte array  
                        bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));           
                    }
                    break;                
                default:
                    throw new Exception("UnSupported Hash Algorithm");                    
            }


            
            return bytes;
        }
    }
}
