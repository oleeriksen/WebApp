using System;
using System.Text;

namespace Core.Crypto
{
    public class SimpleEncryption
    {
        private int mKey;
        public SimpleEncryption(int key)
        {
            mKey = key;
        }

        public string Encrypt(string message)
        {
            StringBuilder sb = new();
            foreach (var ch in message)
            {
                sb.Append(Next(ch, mKey));
            }
            return sb.ToString();
        }

        private char Next(char ch, int key)
        {
            var x = ch + key;

            return (char)x;

        }

        public string Decrypt(string chiperText)
        {
            StringBuilder sb = new();
            foreach (var ch in chiperText)
            {
                sb.Append(Next(ch, -mKey));
            }
            return sb.ToString();
        }
        public void Run()
        {

            var msg = "abcdefghijklmnopqrstuvwxyzæøå";

            Console.WriteLine($"Message: <{msg}>");
            var enc = Encrypt(msg);
            Console.WriteLine($"Encrypt: <{enc}>");
            Console.WriteLine($"Decrypt: <{Decrypt(enc)}>");
            Console.ReadKey();

        }
    }
}

