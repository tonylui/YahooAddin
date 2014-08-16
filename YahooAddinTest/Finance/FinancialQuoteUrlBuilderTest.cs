using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooAddin.Finance;

namespace YahooAddinTest.Finance
{
    [TestFixture]
    public class FinancialQuoteUrlBuilderTest
    {
        [Test]
        public void UrlBuilderShouldBuildProperYqlWithDummySymbolWhenOnlySingleSymbolIsGiven()
        {
            var expected = "select * from yahoo.finance.quote where symbol in (\"0005.HK\",\"DUMMY\")";
            Assert.AreEqual(expected, new FinancialQuoteUrlBuilder("0005.HK").Yql);
        }

        [Test]
        public void UrlBuilderShouldSupportDifferentSymbol()
        {
            var expected = "select * from yahoo.finance.quote where symbol in (\"2800.HK\",\"DUMMY\")";
            Assert.AreEqual(expected, new FinancialQuoteUrlBuilder("2800.HK").Yql);
        }

        [Test]
        public void UrlBuilderShouldAddDummySymbolEvenItIsListOfOneSymbol()
        {
            var expected = "select * from yahoo.finance.quote where symbol in (\"2800.HK\",\"DUMMY\")";
            Assert.AreEqual(expected, new FinancialQuoteUrlBuilder(new List<string>(){"2800.HK"}).Yql);
        }

        [Test]
        public void BuilderShouldSupportSymbolList()
        {
            var expected = "select * from yahoo.finance.quote where symbol in (\"0005.HK\",\"2800.HK\")";
            Assert.AreEqual(expected, new FinancialQuoteUrlBuilder(new List<string>(){ "0005.HK", "2800.HK" }).Yql);
        }

        [Test]
        public void BuilderShouldGetExpectedEnv()
        {
            string expected = "store://datatables.org/alltableswithkeys";
            Assert.AreEqual(expected, new FinancialQuoteUrlBuilder("dummy").Env);
        }

        [Test]
        public void BuilderShouldUseJsonFormat()
        {
            string expected = "json";
            Assert.AreEqual(expected, new FinancialQuoteUrlBuilder("dummy").Format);
        }

        [Test]
        public void BuilderShouldGetEncodedURL()
        {
            List<string> symbol = new List<string>() { "0005.HK", "2800.HK" };
            var expected = "https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.quote+where+symbol+in+(%220005.HK%22%2c%222800.HK%22)&format=json&env=store%3a%2f%2fdatatables.org%2falltableswithkeys";
            Assert.AreEqual(expected, new FinancialQuoteUrlBuilder(symbol).ToUrl());
        }
    }
}
