using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardKottansTests
{
    [TestFixture]
    public class Task3Tests
    {
        [TestCase("343434343434343", "343434343434350")]
        public void GenerateNextCreditCardNumber_ResultsWithNextNumber(string original, string next)
        {
            Assert.AreEqual(next, CreditCardUtility.GenerateNextCreditCardNumber(original));
        }
    }
}
