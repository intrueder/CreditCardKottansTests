using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardKottansTests
{
    [TestFixture]
    public class Task1Tests
    {
        private const string AmericanExpress = "American Express";
        private const string Maestro = "Maestro";
        private const string MasterCard = "MasterCard";
        private const string VISA = "VISA";
        private const string JCB = "JCB";
        private const string Unknown = "Unknown";

        [TestCase("343434343434343")]
        [TestCase("3434 3434 3434 343")]
        [TestCase("341134113411347")]
        [TestCase("3411 3411 3411 347")]
        [TestCase("378282246310005")]
        [TestCase("3782 8224 6310 005")]
        [TestCase("371449635398431")]
        [TestCase("3714 4963 5398 431")]
        public void GetCreditCardVendor_AmericanExpress(string number)
        {
            var vendor = CreditCardUtility.GetCreditCardVendor(number);
            StringAssert.AreEqualIgnoringCase(AmericanExpress, vendor);
        }

        [TestCase("5000000000000611")]
        [TestCase("5000 0000 0000 0611")]
        public void GetCreditCardVendor_Maestro(string number)
        {
            var vendor = CreditCardUtility.GetCreditCardVendor(number);
            StringAssert.AreEqualIgnoringCase(Maestro, vendor);
        }

        [TestCase("5555555555554444")]
        [TestCase("5555 5555 5555 4444")]
        [TestCase("5105105105105100")]
        [TestCase("5105 1051 0510 5100")]
        public void GetCreditCardVendor_MasterCard(string number)
        {
            var vendor = CreditCardUtility.GetCreditCardVendor(number);
            StringAssert.AreEqualIgnoringCase(MasterCard, vendor);
        }

        [TestCase("4111111111111111")]
        [TestCase("4111 1111 1111 1111")]
        [TestCase("4012888888881881")]
        [TestCase("4012 8888 8888 1881")]
        [TestCase("4222222222222")]
        [TestCase("4222 2222 222 22")]
        [TestCase("4917610000000000003")]
        [TestCase("4911830000000")]
        public void GetCreditCardVendor_VISA(string number)
        {
            var vendor = CreditCardUtility.GetCreditCardVendor(number);
            StringAssert.AreEqualIgnoringCase(VISA, vendor);
        }

        [TestCase("3530111333300000")]
        [TestCase("3530 1113 3330 0000")]
        [TestCase("3566002020360505")]
        [TestCase("3566 0020 2036 0505")]
        public void GetCreditCardVendor_JCB(string number)
        {
            var vendor = CreditCardUtility.GetCreditCardVendor(number);
            StringAssert.AreEqualIgnoringCase(JCB, vendor);
        }

        [TestCase("35301113333000001")]
        [TestCase("41111111111111112")]
        [TestCase("3434343434343433")]
        [TestCase("50000000000006114")]
        public void GetCreditCardVendor_Unknown(string number)
        {
            var vendor = CreditCardUtility.GetCreditCardVendor(number);
            StringAssert.AreEqualIgnoringCase(Unknown, vendor);
        }
    }
}
