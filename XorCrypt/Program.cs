using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkavenCrypt
{
    public class XOR
    {
static void Main(string[] args)
{
    if (args.Length < 4)
    {
        Console.WriteLine("Usage: XorCrypt <encrypt|decrypt> <input file> <output file> <keyword>");
        return;
    }

    string operation = args[0];
    string inputFile = args[1];
    string outputFile = args[2];
    string keyword = args[3];

    switch (operation)
    {
        case "encrypt":
            XOR.EncryptXORFile(inputFile, keyword, outputFile);
            Console.WriteLine($"File '{inputFile}' encrypted with keyword '{keyword}' and saved to '{outputFile}'");
            break;

        case "decrypt":
            string decryptedFile = Path.GetFileNameWithoutExtension(outputFile);
            XOR.DecryptXORFile(inputFile, keyword, outputFile);
            Console.WriteLine($"File '{outputFile}' decrypted with keyword '{keyword}' and saved to '{decryptedFile}'");
            break;

        default:
            Console.WriteLine($"Invalid operation: {operation}");
            break;
    }
}



        public static byte[] xorEncDec(byte[] inputData, string keyword)
        {
            //byte[] keyBytes = Encoding.UTF8.GetBytes(keyPhrase);
            byte[] bufferBytes = new byte[inputData.Length];
            for (int i = 0; i < inputData.Length; i++)
            {
                bufferBytes[i] = (byte)(inputData[i] ^ Encoding.UTF8.GetBytes(keyword)[i % Encoding.UTF8.GetBytes(keyword).Length]);
            }
            return bufferBytes;
        }

        public static void EncryptXORFile(string inputFile, string keyword, string outputFile)
        {
            byte[] inputData = File.ReadAllBytes(inputFile);
            byte[] xorEncrypted = xorEncDec(inputData, keyword);
            File.WriteAllBytes(outputFile, xorEncrypted);
        }

        public static void DecryptXORFile(string inputFile, string keyword, string outputFile)
        {
            byte[] inputData = File.ReadAllBytes(inputFile);
            byte[] xorDecrypted = xorEncDec(inputData, keyword);
            File.WriteAllBytes(outputFile, xorDecrypted);
        }
    }
}
