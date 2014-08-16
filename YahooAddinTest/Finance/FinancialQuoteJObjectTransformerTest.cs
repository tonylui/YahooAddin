using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooAddin.Finance;

namespace YahooAddinTest.Finance
{
    [TestFixture]
    class FinancialQuoteJObjectTransformerTest
    {
        [Test]
        public void PrepareJObjectFromFileShouldWorkProperlyAndCreateJObjectAsExpectedFromTheMockFile()
        {
            JObject expected = prepareJObjectFromFile();
            Assert.AreEqual(expected["query"]["count"].ToString(), "2");
        }

        [Test]
        public void QuoteReaderShouldReadQuoteProperlyWhenMultiSymbolsAreQuoted()
        {
            var dictionary = FinancialQuoteJObjectTransformer.Transform(prepareJObjectFromFile());

            Assert.AreEqual("0005.HK", dictionary["0005.HK"]["symbol"]);
            Assert.AreEqual("10959700", dictionary["0005.HK"]["AverageDailyVolume"]);
            Assert.AreEqual("HSBC HOLDINGS", dictionary["0005.HK"]["Name"]);

            Assert.AreEqual("24.75", dictionary["2800.HK"]["DaysLow"]);
            Assert.AreEqual("24.95", dictionary["2800.HK"]["DaysHigh"]);
            Assert.AreEqual("TRACKER FUND", dictionary["2800.HK"]["Name"]);
        }

        private JObject prepareJObjectFromFile()
        {
            return JObject.Parse(File.ReadAllText("../../resources/mockResponse01.txt"));
        }

    }
}
