using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooAddin.Utils;

namespace YahooAddinTest.Utils
{
    [TestFixture]
    class StringUtilsTest
    {

        [Test]
        public void StringUtilsShouldConvertSingleStringWithQuotes()
        {
            string input = "test";
            string expected = "\"test\"";

            Assert.AreEqual(expected, StringUtils.withDoubleQuotes(input));
        }

        [Test]
        public void StringUtilsShouldConvertArrayOfStringWithQuotes()
        {
            List<string> input = new List<string>(){ "test01", "test02"};
            List<string> expected = new List<string>(){ "\"test01\"", "\"test02\""};

            Assert.AreEqual(expected.ElementAt(0), StringUtils.withDoubleQuotes(input).ElementAt(0));
            Assert.AreEqual(expected.ElementAt(1), StringUtils.withDoubleQuotes(input).ElementAt(1));
        }

    }
}
