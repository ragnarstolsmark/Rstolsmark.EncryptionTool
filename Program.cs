using System;
using Rstolsmark.EncryptionLib;
using static Rstolsmark.EncryptionLib.StringEncryptor;

namespace Rstolsmark.EncryptionTool
{
    public class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0){
                PrintUsage();
                return;
            }
            if(string.Equals(args[0], "encrypt", StringComparison.OrdinalIgnoreCase)){
                if(args.Length == 2){
                    var result = Encrypt(args[1]);
                    PrintEncryptionResult(result);
                    return;
                }
                if(args.Length == 3){
                    var result = Encrypt(args[1], args[2]);
                    PrintEncryptionResult(result);
                    return;
                }
            }else if(string.Equals(args[0], "decrypt", StringComparison.OrdinalIgnoreCase)){
                if(args.Length == 3){
                    var result = Decrypt(args[1], args[2]);
                    Console.WriteLine(result);
                    return;
                }
            }
            PrintUsage();

            void PrintEncryptionResult(EncryptionResult result){                
                Console.WriteLine("Keep the key secure and use it to decrypt the data.");
                Console.WriteLine("Key:");
                Console.WriteLine(result.Key);
                Console.WriteLine("Data:");
                Console.WriteLine(result.EncryptedData);
            }

            void PrintUsage(){
                Console.WriteLine("\nUsage:");
                Console.WriteLine("To encrypt a plaintext string and let the encryption tool generate a key:");
                Console.WriteLine("encryptiontool encrypt <plaintext>");
                Console.WriteLine("To encrypt a plaintext string with a specific key:");
                Console.WriteLine("encryptiontool encrypt <plaintext> <key>");
                Console.WriteLine("To decrypt an encrypted string:");
                Console.WriteLine("encryptiontool decrypt <encrypted data> <key>");
            }
        }

        
    }
}
