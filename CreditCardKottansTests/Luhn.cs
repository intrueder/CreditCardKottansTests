using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardKottansTests
{
    // https://bitbucket.org/multipetros/validation/src/e8f43334e067/Validation/Luhn.cs?fileviewer=file-view-default
    public static class Luhn
    {

        /// <summary>
        /// The greek social id, uses the Luhn formula.<br />
        /// The last digit is the validation digit using the Luhn check digit algorithm.<ul><li>
        ///  1 - Counting from the check digit, which is the rightmost, and moving left, double the value of every second digit.</li><li>
        ///  2 - Sum the digits of the products (e.g., 10: 1 + 0 = 1, 14: 1 + 4 = 5) together with the undoubled digits from the original number.</li><li>
        ///  3 - If the total modulo 10 is equal to 0 (if the total ends in zero) then the number is valid according to the Luhn formula; else it is not valid.</li></ul>
        /// </summary>
        /// <param name="sidNum">The social id number in string</param>
        /// <returns>True if pass the Luhn validation, else false</returns>
        public static bool IsValid(string id)
        {

            int idLength = id.Length;
            int currentDigit;
            int idSum = 0;
            int currentProcNum = 0; //the current process number (to calc odd/even proc)

            for (int i = idLength - 1; i >= 0; i--)
            {
                //get the current rightmost digit from the string
                string idCurrentRightmostDigit = id.Substring(i, 1);

                //parse to int the current rightmost digit, if fail return false (not-valid id)
                if (!int.TryParse(idCurrentRightmostDigit, out currentDigit))
                    return false;

                //bouble value of every 2nd rightmost digit (odd)
                //if value 2 digits (can be 18 at the current case),
                //then sumarize the digits (made it easy the by remove 9)
                if (currentProcNum % 2 != 0)
                {
                    if ((currentDigit *= 2) > 9)
                        currentDigit -= 9;
                }
                currentProcNum++; //increase the proc number

                //summarize the processed digits
                idSum += currentDigit;
            }

            //if digits sum is exactly divisible by 10, return true (valid), else false (not-valid)
            return (idSum % 10 == 0);
        }
    }
}
