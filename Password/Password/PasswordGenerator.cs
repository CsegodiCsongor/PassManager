using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password
{
    public class PasswordGenerator
    {
        public static char[] Numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        public static char[] Lowercase;
        public static char[] Uppercase;
        public static char[] Symbols = new char[] { '@', '#', '$', '%', '^', '&', '*' };
        public static char[] Ambiguous_Characters = new char[] { '{', '}', '(', ')', '[', ']', '/', '\\', '\'', '\"', '~', ',', ';', ':', '.', '<', '>' };
        public string[] Password;
        public static Random rnd = new Random();
        List<int> InUse = new List<int>();

        public PasswordGenerator(int lenght, bool HasNumber, bool HasLowercase, bool HasUppercase,bool HasSymbols,bool HasAmbiguous )
        {
            Password = new string[lenght];
            PopulateInUseList(HasNumber, HasLowercase, HasUppercase, HasSymbols, HasAmbiguous);
            GeneratePass();
            Shuffle();
        }

        public void GeneratePass()
        {
            if (InUse.Count != 0)
            {
                int position = InUse.Count;
                for (int i = 0; i < position && i<Password.Length; i++)
                {
                    Password[i] = GetRandomValueFromVector(InUse[i]);
                }
                for (int i = position; i < Password.Length; i++)
                {
                    Password[i] = GetRandomValueFromVector(InUse[rnd.Next(InUse.Count)]);
                }
            }
            else
            {
                for(int i=0;i<Password.Length;i++)
                {
                    Password[i] = (i+1).ToString();
                }
            }
        }

        public string GetRandomValueFromVector(int VectorNumber)
        {
            if(VectorNumber==0)
            {
                return Numbers[rnd.Next(Numbers.Length)].ToString();
            }
            else if (VectorNumber == 1)
            {
                return Lowercase[rnd.Next(Lowercase.Length)].ToString();
            }
            else if (VectorNumber == 2)
            {
                return Uppercase[rnd.Next(Uppercase.Length)].ToString();
            }
            else if (VectorNumber == 3)
            {
                return Symbols[rnd.Next(Symbols.Length)].ToString();
            }
            else
            {
                return Ambiguous_Characters[rnd.Next(Ambiguous_Characters.Length)].ToString();
            }
        }

        public void PopulateInUseList(bool HasNumber, bool HasLowercase, bool HasUppercase, bool HasSymbols, bool HasAmbiguous)
        {
            if(HasNumber==true)
            {
                InUse.Add(0);
            }
            if (HasLowercase == true)
            {
                InUse.Add(1);
            }
            if (HasUppercase == true)
            {
                InUse.Add(2);
            }
            if (HasSymbols == true)
            {
                InUse.Add(3);
            }
            if (HasAmbiguous == true)
            {
                InUse.Add(4);
            }
        }

        public void Shuffle()
        {
            for(int i=Password.Length-1;i>0;i--)
            {
                int j = rnd.Next(0, i + 1);
                string aux = Password[i];
                Password[i] = Password[j];
                Password[j] = aux;
            }
        }

        public string GetPass()
        {
            string p = "";
            for(int i=0;i<Password.Length;i++)
            {
                p += Password[i].ToString();
            }
            return p;
        }

    }
}
