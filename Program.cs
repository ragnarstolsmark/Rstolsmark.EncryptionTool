using System;
using Rstolsmark.EncryptionLib;
using static Rstolsmark.EncryptionLib.StringEncryptor;
using XKCDPasswordGen;

namespace Rstolsmark.EncryptionTool
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintUsage();
                return;
            }
            if (string.Equals(args[0], "encrypt", StringComparison.OrdinalIgnoreCase))
            {
                if (args.Length == 2)
                {
                    string password = XkcdPasswordGen.Generate(4);
                    var result = Encrypt(args[1], password);
                    Console.WriteLine("Password:");
                    Console.WriteLine(password);
                    Console.WriteLine("Encrypted data:");
                    Console.WriteLine(result);
                    return;
                }
                if (args.Length == 3)
                {
                    var result = Encrypt(args[1], args[2]);
                    Console.WriteLine(result);
                    return;
                }
            }
            else if (string.Equals(args[0], "decrypt", StringComparison.OrdinalIgnoreCase))
            {
                if (args.Length == 3)
                {
                    var result = Decrypt(args[1], args[2]);
                    Console.WriteLine(result);
                    return;
                }
            }
            PrintUsage();

            void PrintUsage()
            {
                Console.WriteLine("\nUsage:");
                Console.WriteLine("To encrypt a plaintext string with a generated password:");
                Console.WriteLine("encryptiontool encrypt <plaintext>");
                Console.WriteLine("To encrypt a plaintext string with a specific password:");
                Console.WriteLine("encryptiontool encrypt <plaintext> <password>");
                Console.WriteLine("To decrypt an encrypted string:");
                Console.WriteLine("encryptiontool decrypt <encrypted data> <password>");
            }
        }


    }
}
