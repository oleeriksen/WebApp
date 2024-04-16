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
            if ('0' <= ch && ch <= '9')
            {
                key = key % 10;
                var y = ((ch - '0') + key);
                if (y < '0') y += 10;
                return (char)(y % 10 + (int)'0');
            }
            if ('a' <= ch && ch <= 'z')
            {
                key = key % 26;
                var y = ((ch - 'a') + key);
                if (y < 'a') y += 26;
                return (char)(y % 26 + (int)'a');
            }
            if ('A' <= ch && ch <= 'Z')
            {
                key = key % 26;
                var y = ((ch - 'A') + key);
                if (y < 'A') y += 26;
                return (char)(y % 26 + (int)'A');
            }
            return ch;
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

