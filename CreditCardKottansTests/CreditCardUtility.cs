using System;

namespace CreditCardKottansTests
{
    public class CreditCardUtility
    {
        public static string GetCreditCardVendor(string creditCardNumber)
        {
            throw new NotImplementedException();
            //return Luhn.GetCreditCardVendor(creditCardNumber).ToString();
        }

        public static bool IsCreditCardNumberValid(string creditCardNumber)
        {
            throw new NotImplementedException();
            //return Luhn.IsCreditCardNumberValid(creditCardNumber);
        }

        public static string GenerateNextCreditCardNumber(string sourceCardNumber)
        {
            throw new NotImplementedException();
            //return Luhn.GenerateNextCreditCardNumber(sourceCardNumber);
        }
    }
}
