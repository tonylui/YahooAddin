using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using YahooAddin.Utils;


namespace YahooAddin.Finance
{
    public class FinancialQuoteUrlBuilder : IUrlBuilder
    {
        private readonly List<string> symbols;

        public string Prefix
        {
            get
            {
                return "https://query.yahooapis.com/v1/public/yql?q=";
            }
        }

        public string Format
        {
            get
            {
                return "json";
            }
        }

        public string Env {
            get 
            {
                return "store://datatables.org/alltableswithkeys";
            }  
        }

        public string Yql
        {
            get
            {
                return "select * from yahoo.finance.quote where symbol in (" + String.Join(",", StringUtils.withDoubleQuotes(symbols)) + ")";
            }
        }

        public FinancialQuoteUrlBuilder(string symbol): this(new List<string>() { symbol }){}

        public FinancialQuoteUrlBuilder(List<string> symbols)
        {
            this.symbols = symbols;

            if (this.symbols.Count == 1)
            {
                this.symbols.Add("DUMMY");
            }
        }

        public string ToUrl()
        {
            return Prefix + HttpUtility.UrlEncode(Yql) + "&format=" + Format + "&env=" + HttpUtility.UrlEncode(Env);
        }

    }
}
