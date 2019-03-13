using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password
{
    public class CesarCrypt
    {
        public string message { get; set; }

        public CesarCrypt(string message)
        {
            this.message = message;
        }

        public string EnCrypt(int n)
        {
            message = message.ToLower();
            char[] MessageInLetters = message.ToCharArray();
            for (int i = 0; i < MessageInLetters.Length; i++)
            {
                MessageInLetters[i] = (char)(MessageInLetters[i] + n);
            }
            message = new string(MessageInLetters);
            return message;
        }

        public string DeCrypt(int n)
        {
            message = message.ToLower();
            char[] MessageInLetters = message.ToCharArray();
            for (int i = 0; i < MessageInLetters.Length; i++)
            {
                MessageInLetters[i] = (char)(MessageInLetters[i] - n);
            }
            message = new string(MessageInLetters);
            return message;
        }

        public string GetMessage()
        {
            return message;
        }
    }
}
