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
        [TestCase("343434343434392", "343434343434400")]
        [TestCase("343434343434590", "343434343434608")]
        public void GenerateNextCreditCardNumber_ResultsWithNextNumber(string original, string next)
        {
            Assert.AreEqual(next, CreditCardUtility.GenerateNextCreditCardNumber(original));
        }

        [TestCase("4999999999999999993", "5000000000000000005")]
        public void GenerateNextCreditCardNumber_WithBoundNumber_ResultsWithError(string original, string next)
        {
            try
            {
                string generatedNext = CreditCardUtility.GenerateNextCreditCardNumber(original);
                Assert.AreNotEqual(next, generatedNext);
                // to be shure, that code does not generate number less than original
                Assert.Greater(StringComparer.OrdinalIgnoreCase.Compare(generatedNext, original), 0);
            }
            catch (Exception e) when (!(e is AssertionException))
            {
                Assert.Pass();
            }
        }
    }
}
