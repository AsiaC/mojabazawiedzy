using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalText = "My secret data!";

            //AES symetryczny algorytm-jeden klucz do szyfr i odszyfrowywania
            EncryptSomeText(originalText);

            //RSA asymetryczny, - klucz publ do szyfrowania i pryw do odszyfrowania
            //you can create a new instance of the RSACryptoServiceProvider and export the public key to XML.
            //By passing true to the ToXmlString method, you also export the private part of your key.
            List<string> listOfKeys = RSA_listing3_18();
            byte[] zaszyfrowanyText = uzycie_RSA_zaszyfruj(originalText, listOfKeys[0]); //szyfrowanie 
            Console.WriteLine("zaszyfrowanyText: " + zaszyfrowanyText);
            string tekstOdszyfrowany = uzycie_RSA_odszyfruj(zaszyfrowanyText, listOfKeys[1]); //odszyfrowanie
            Console.WriteLine("tekstOdszyfrowany: " + tekstOdszyfrowany);

            Sha_funkcja_skrotu();

            Console.ReadKey();
        }
        public static void EncryptSomeText(string originalText)
        {
            using (SymmetricAlgorithm symmetricAlgorithm = new AesManaged())
            {
                Console.WriteLine("Original:   {0}", originalText);                // Displays: My secret data! 
                byte[] encrypted = Encrypt(symmetricAlgorithm, originalText);
                Console.WriteLine("Original:   {0}", encrypted);                // Displays: System.Byte[]             
                string roundtrip = Decrypt(symmetricAlgorithm, encrypted);
                Console.WriteLine("Round Trip: {0}", roundtrip);                 // Displays: My secret data! 
            }
        }
        static byte[] Encrypt(SymmetricAlgorithm aesAlg, string plainText)
        {
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }
        static string Decrypt(SymmetricAlgorithm aesAlg, byte[] cipherText)
        {
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt =
                    new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
        public static List<string> RSA_listing3_18()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicKeyXML = rsa.ToXmlString(false); //wyeksportowanie klucza publicznego do XML, publ służy do zaszyfrowania
            string privateKeyXML = rsa.ToXmlString(true); //wyeksportowanie klucza prywatnego do XML
            List<string> listOfKeys = new List<string>();
            listOfKeys.Add(publicKeyXML);
            listOfKeys.Add(privateKeyXML);

            Console.WriteLine("klucz publiczny: " + publicKeyXML);
            Console.WriteLine("klucz prywatny: " + privateKeyXML);
            return listOfKeys;
            //klucz publiczny: <RSAKeyValue>
            //< Modulus > 59XNWwWPHGRIRkvaACtoC02icJnvgOmPXga2KYK7bcRKAFkT96gqHe + uwXCXGtD2Zw2VcV68BPRsU3wECjTE2hcPcblVqngXixgeUAMyt5YJmPlrFCKytdyVYXXmp + 6 / itlqJClQ9MV / h1CnKi3 / h + OW / xOXu1c6JT5u2iEsuQ0 =</ Modulus >
            //< Exponent > AQAB </ Exponent ></ RSAKeyValue >

            //klucz prywatny: < RSAKeyValue >
            //< Modulus > 59XNWwWPHGRIRkvaACtoC02icJnvgOmPXga2KYK7bcRKAFkT96gqHe + uwXCXGtD2Zw2VcV68BPRsU3wECjTE2hcPcblVqngXixgeUAMyt5YJmPlrFCKytdyVYXXmp + 6 / itlqJClQ9MV / h1CnKi3 / h + OW / xOXu1c6JT5u2iEsuQ0 =</ Modulus >
            //< Exponent > AQAB </ Exponent >
            //< P > 6NVvjD36eo2h7nciVEB70BPY6dLKP9GeSM / ymFXGR + kxa + z9MZq1CwhnGYOnHneFr31RAWj4MP4Jq7nA2GJ + kw ==</ P >
            //< Q >/ ubugORNsG + 2CwHS6rDC + R1GRbUSPGt80J / +m1u8kmxZ4mP9X13xRLZwnAWx5uJQ3k67UnZO74m6nktZpiEN3w ==</ Q >
            //< DP > qHkP / t016gmju0Yu6 + HA9R33XbGtsKH / s1XshvfBwnTk0uAnkQYNrA8HcvnFKhF4BTRbMfb / Z4vZ + Y0uEiSqyw ==</ DP >
            //< DQ > h4wB1CSTc3lUErJbmFV6uMHqdnL9SYfXDZGm8LJtqmdXvN1zBN2NyP5DD5Svr5k1a6HuVsF25EYXKMnk2ETHfQ ==</ DQ >
            //< InverseQ > OXYwOTanZ2Fq8VFByKoP1PDyERiYKQ3ydkw / eFx1vPJ7++FanVKDaDhSofYkda2xBErakvlNmzL3WsDxqMKR2Q ==</ InverseQ >
            //< D > V00cuqT6Qj / FM6uGmT +/ O1ptzCc7mHjbQxYV7MXNHMWo9D6XFVCfI4zJaxCh5jhAQYhM + VcqSFden4V44 / sBEUOo7iSPaPoN3qgwrmBvIzVIY3xR8vfdG31XENHtv1vTmqZfwFkdD9apy7cG4GeFFaVv + j + WDzU1sOr5E3AGcsU =</ D >
            //</ RSAKeyValue >
        }
        public static byte[] uzycie_RSA_zaszyfruj(string originalText, string kluczPubliczny)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes(originalText);
            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(kluczPubliczny);
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
            }
            return encryptedData;

        }
        public static string uzycie_RSA_odszyfruj(byte[] encryptedData, string kluczPrywatny)
        {
            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(kluczPrywatny);
                decryptedData = RSA.Decrypt(encryptedData, false);
            }
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            string decryptedString = ByteConverter.GetString(decryptedData);
            Console.WriteLine(decryptedString); // Displays: My Secret Data!}
            return decryptedString;
        }
        
        public static void Sha_funkcja_skrotu()
        {
        UnicodeEncoding byteConverter = new UnicodeEncoding();
        SHA256 sha256 = SHA256.Create();
        string data = "A paragraph of text";
        byte[] hashA = sha256.ComputeHash(byteConverter.GetBytes(data));
        data = "A paragraph of changed text";
        byte[] hashB = sha256.ComputeHash(byteConverter.GetBytes(data));
        data = "A paragraph of text";
        byte[] hashC = sha256.ComputeHash(byteConverter.GetBytes(data));
        Console.WriteLine(hashA.SequenceEqual(hashB)); // Displays: false
        Console.WriteLine(hashA.SequenceEqual(hashC)); // Displays: true
//As you can see, different strings give a different hash code and the same string gives the exact same hash code.

        }
    }
}
