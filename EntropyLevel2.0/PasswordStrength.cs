using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntropyLevel2._0
{
    public class PasswordStrength
    {
        private StringBuilder Output = new StringBuilder();

        public StringBuilder ViewOutput
        {
            get
            {
                return Output;
            }
            set
            {
                Output = value;
            }
        }

        private static Double StrongEntropy;
        private static string GOOD = "GOOD";
        private static string STRONG = "STRONG";
        private static string WEAK = "WEAK";
        private static char[] Others = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };
        public PasswordStrength(double initiliazer)
        {
            StrongEntropy = initiliazer; //as a finger rule, this number represent a good Entropy. can be changed.
        }
        public void CheckEntropy(string input)
        {
            // initializations and definitions
            double Entropy = 0.0;
            int counterOfSmallLetters = 0;
            int counterOfCapitalLetters = 0;
            int counterOfSpecialChars = 0;
            int counterOfNumbers = 0;
            int counterOthers = 0;
            char userInputSingleChar = ' ';

            //load password into chars array
            char[] userInputCharArray = input.ToCharArray();

            //loop through array and count chars
            for (int i = 0; i < input.Length; i++)
            {
                userInputSingleChar = userInputCharArray[i];

                switch (userInputSingleChar)
                {
                    case var CharType when Char.IsUpper(userInputSingleChar):
                        counterOfCapitalLetters++;
                        break;
                    case var CharType when Char.IsLower(userInputSingleChar):
                        counterOfSmallLetters++;
                        break;
                    case var CharType when Char.IsNumber(userInputSingleChar):
                        counterOfNumbers++;
                        break;
                    case var CharType when Char.IsSymbol(userInputSingleChar):
                        counterOfSpecialChars++;
                        break;
                    case var indexOfAnyInString when input.IndexOfAny(Others) > 0:
                        counterOthers++;
                        break;
                }
            }

            //display information
            Output.Append("The password you entered is " + input);
            Output.Append("<br/>");
            Output.Append("The number of chars is " + input.Length.ToString());
            Output.Append("<br/>");
            Output.Append("There are " + counterOfSmallLetters + " small letters");
            Output.Append("<br/>");
            Output.Append("There are " + counterOfCapitalLetters + " capital letters");
            Output.Append("<br/>");
            Output.Append("There are " + counterOfNumbers + " numbers");
            Output.Append("<br/>");
            Output.Append("There are " + counterOfSpecialChars + " Special Chars");
            Output.Append("<br/>");
            Output.Append("There are " + counterOthers + " other Chars");
            Output.Append("<br/>");


            //calculate Entropy and display decision
            try
            {
                Entropy = Math.Log((counterOfSmallLetters > 0 ? 26 : 0) + (counterOfSmallLetters > 0 ? 26 : 0) + (counterOfSpecialChars > 0 ? 10 : 0) + (counterOthers > 0 ? 10 : 0) + (counterOfNumbers > 0 ? 10 : 0), 2) * input.Length;

                Output.Append("Entropy is " + Entropy.ToString());
                Output.Append("<br/>");
                Output.Append("<b>");

                switch (Entropy)
                {
                    case var decision when Entropy < StrongEntropy:
                        Output.Append("Entropy is " + WEAK);
                        break;
                    case var decision when Entropy > StrongEntropy:
                        Output.Append("Entropy is " + STRONG);
                        break;
                    case var decision when Entropy == StrongEntropy:
                        Output.Append("Entropy is " + GOOD);
                        break;
                    default:
                        Output.Append("Unknown");
                        break;
                }
                Output.Append("</b>");
                Output.Append("<br/>");
            }
            catch (Exception ex)
            {
                Output.Append("Exception occured " + ex.Message);
            }
        }
    }
}