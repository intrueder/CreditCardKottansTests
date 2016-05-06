using System;
using System.Linq;
using System.Text;

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
        //public static bool IsValid(string id)
        //{

        //    int idLength = id.Length;
        //    int currentDigit;
        //    int idSum = 0;
        //    int currentProcNum = 0; //the current process number (to calc odd/even proc)

        //    for (int i = idLength - 1; i >= 0; i--)
        //    {
        //        //get the current rightmost digit from the string
        //        string idCurrentRightmostDigit = id.Substring(i, 1);

        //        //parse to int the current rightmost digit, if fail return false (not-valid id)
        //        if (!int.TryParse(idCurrentRightmostDigit, out currentDigit))
        //            return false;

        //        //bouble value of every 2nd rightmost digit (odd)
        //        //if value 2 digits (can be 18 at the current case),
        //        //then sumarize the digits (made it easy the by remove 9)
        //        if (currentProcNum % 2 != 0)
        //        {
        //            if ((currentDigit *= 2) > 9)
        //                currentDigit -= 9;
        //        }
        //        currentProcNum++; //increase the proc number

        //        //summarize the processed digits
        //        idSum += currentDigit;
        //    }

        //    //if digits sum is exactly divisible by 10, return true (valid), else false (not-valid)
        //    return (idSum % 10 == 0);
        //}

        #region bizmonto@gmail.com - https://github.com/BIZMONT/KottansTask

        //private static readonly Dictionary<string, string> vendors = new Dictionary<string, string>
        //{
        //    {@"^3[4,7]\d{13}", "American Express"},
        //    {@"^5[1-5]\d{14}$", "MasterCard"},
        //    {@"^35(?:2[8,9]|[3-8]\d)\d{12}$", "JCB"},
        //    {@"^4\d{12}(?:\d{3}|\d{6})?$", "VISA"},
        //    {@"^(?:5[0,6-9]|6\d)\d{10,17}$", "Maestro"},
        //};

        //private static readonly List<string> formats = new List<string>()
        //{
        //    @"\d{12,19}$",
        //    @"^\d{4}\s\d{4}\s\d{4}$",
        //    @"^\d{4}\s\d{5}\s\d{4}$",
        //    @"^(?:\d{4}\s){3}\d{3}",
        //    @"^\d{4}\s\d{6}\s\d{5}$",
        //    @"^\d{4}(?:\s\d{4}){3}$"
        //};

        //private static bool IsFormatCorrect(string creditCardNumber)
        //{
        //    foreach (var format in formats)
        //    {
        //        if (Regex.IsMatch(creditCardNumber, format))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //private static string RemoveAllWhitespaces(string creditCardNumber)
        //{
        //    return creditCardNumber.Replace(" ", string.Empty);
        //}

        //public static string GetCreditCardVendor(string creditCardNumber)
        //{
        //    if (!IsFormatCorrect(creditCardNumber))
        //    {
        //        throw new FormatException("Credit card number has an incorrect format!");
        //    }
        //    creditCardNumber = RemoveAllWhitespaces(creditCardNumber);

        //    foreach (var vendor in vendors)
        //    {
        //        if (Regex.IsMatch(creditCardNumber, vendor.Key))
        //        {
        //            return vendor.Value;
        //        }
        //    }

        //    return "Unknown";
        //}

        //public static bool IsCreditCardNumberValid(string creditCardNumber)
        //{
        //    int sum = 0;

        //    if (!IsFormatCorrect(creditCardNumber))
        //    {
        //        throw new FormatException("Credit card number has an incorrect format!");
        //    }
        //    creditCardNumber = RemoveAllWhitespaces(creditCardNumber);
        //    if (GetCreditCardVendor(creditCardNumber) == "Unknown" && creditCardNumber.Length != 16)
        //    {
        //        throw new FormatException("Credit card number has an incorrect format!");
        //    }

        //    try
        //    {
        //        sum = creditCardNumber.Reverse().Select((digitCharacter, digitPosition) =>
        //        {
        //            int digit = int.Parse(digitCharacter.ToString());
        //            if (digitPosition%2 == 1)
        //            {
        //                digit *= 2;
        //                if (digit > 9)
        //                {
        //                    digit -= 9;
        //                }
        //            }
        //            return digit;
        //        }).Sum();
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    if (sum != 0)
        //    {
        //        return sum%10 == 0;
        //    }
        //    return false;
        //}

        //public static string GenerateNextCreditCardNumber(string sourceCardNumber)
        //{
        //    if (!IsFormatCorrect(sourceCardNumber))
        //    {
        //        throw new FormatException("Credit card number has an incorrect format!");
        //    }

        //    sourceCardNumber = RemoveAllWhitespaces(sourceCardNumber);
        //    string sourceVendor = GetCreditCardVendor(sourceCardNumber);

        //    if (!IsCreditCardNumberValid(sourceCardNumber))
        //    {
        //        throw new ArgumentException("Input credit card number is not valid!");
        //    }

        //    ulong resultCardNumber = ulong.Parse(sourceCardNumber);


        //    for (int i = 0; i < 30; i++)
        //    {
        //        if (IsCreditCardNumberValid((++resultCardNumber).ToString()) &&
        //            GetCreditCardVendor((++resultCardNumber).ToString()) == sourceVendor)
        //            return resultCardNumber.ToString();
        //    }
        //    throw new Exception("Next card number is not found!");
        //}

        #endregion

        #region julia.hrytsyk@gmail.com - https://github.com/julia-hrytsyk/CardValidator.git

        //public const int VisaNumberLow = 4000;

        //public const int VisaNumberHigh = 4999;
        //public const int AExpressNumberLow1 = 3400;
        //public const int AExpressNumberHigh1 = 3499;
        //public const int AExpressNumberLow2 = 3700;
        //public const int AExpressNumberHigh2 = 3799;
        //public const int MaestroNumberLow1 = 5000;
        //public const int MaestroNumberHigh1 = 5099;
        //public const int MaestroNumberLow2 = 5600;
        //public const int MaestroNumberHigh2 = 6999;
        //public const int MCardNumberLow1 = 2221;
        //public const int MCardNumberHigh1 = 2720;
        //public const int MCardNumberLow2 = 5100;
        //public const int MCardNumberHigh2 = 5599;
        //public const int JcbNumberLow = 3528;
        //public const int JcbNumberHigh = 3589;

        //public enum Vendor
        //{
        //    AmericanExpress,
        //    Maestro,
        //    MasterCard,
        //    Visa,
        //    Jcb,
        //    Unknown
        //}

        //public static Vendor GetCreditCardVendor(string number)
        //{
        //    int numberConverted = Convert.ToInt32(number.Substring(0, 4));

        //    if (numberConverted >= VisaNumberLow & numberConverted <= VisaNumberHigh)
        //    {
        //        return Vendor.Visa;
        //    }

        //    else if ((numberConverted >= AExpressNumberLow1 & numberConverted <= AExpressNumberHigh1) ||
        //             (numberConverted >= AExpressNumberLow2 & numberConverted <= AExpressNumberHigh2))
        //    {
        //        return Vendor.AmericanExpress;
        //    }

        //    else if ((numberConverted >= MaestroNumberLow1 & numberConverted <= MaestroNumberHigh1) ||
        //             (numberConverted >= MaestroNumberLow2 & numberConverted <= MaestroNumberHigh2))
        //    {
        //        return Vendor.Maestro;
        //    }

        //    else if ((numberConverted >= MCardNumberLow1 & numberConverted <= MCardNumberHigh1) ||
        //             (numberConverted >= MCardNumberLow2 & numberConverted <= MCardNumberHigh2))
        //    {
        //        return Vendor.MasterCard;
        //    }

        //    else if (numberConverted >= JcbNumberLow & numberConverted <= JcbNumberHigh)
        //    {
        //        return Vendor.Jcb;
        //    }

        //    return Vendor.Unknown;
        //}

        //public static bool IsCreditCardNumberValid(string number)
        //{
        //    return GetLuhnSumOfDigits(number)%10 == 0;
        //}

        //public static string GenerateNextCreditCardNumber(string number)
        //{
        //    StringBuilder incNumber = new StringBuilder(IncrementNumber(number));
        //    incNumber[incNumber.Length - 1] = '0';
        //    int luhnSum = GetLuhnSumOfDigits(incNumber.ToString());
        //    int num = (luhnSum/10 == 0) ? 0 : 10 - luhnSum%10;
        //    incNumber[incNumber.Length - 1] = Convert.ToChar('0' + num);
        //    return incNumber.ToString();
        //}

        //private static string IncrementNumber(string number)
        //{
        //    var array = number.Select(v => Convert.ToInt32(v) - '0').ToArray();
        //    int sum = array[array.Length - 2] + 1;

        //    int i = array.Length - 2;

        //    while (sum > 9 && i > 0)
        //    {
        //        array[i] = sum - 10;
        //        sum = array[i + 1] + 1;
        //        i--;
        //    }

        //    array[i] = (sum < 10) ? sum : sum - 10;

        //    var incrementedNumber = array.Aggregate(string.Empty, (s, v) => s + v.ToString());

        //    return (sum > 10 && i == 0) ? "1" + incrementedNumber : incrementedNumber;
        //}

        //private static int GetLuhnSumOfDigits(string number)
        //{
        //    return number.Reverse().
        //        Select((v, i) => new {value = Convert.ToInt32(v) - '0', index = i}).
        //        Sum(g => (g.index%2 == 0) ? g.value : GetSumOfDigits(g.value*2));
        //}

        //private static int GetSumOfDigits(int number)
        //{
        //    int sum = 0;
        //    int buf = number;

        //    do
        //    {
        //        while (buf > 0)
        //        {
        //            sum += buf%10;
        //            buf = buf/10;
        //        }

        //        buf = sum;
        //    } while (buf > 9);

        //    return sum;
        //}

        #endregion
    }
}
