using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooAddin.Finance
{
    public class FinancialQuoteJObjectTransformer
    {
        public static Dictionary<string, Dictionary<string, string>> Transform(JObject quoteResults)
        {
            var result = new Dictionary<string,Dictionary<string,string>>();
            var query = from q in quoteResults["query"]["results"]["quote"] select (JObject)q;

            foreach(var item in query){
                Dictionary<string, string> itemResult = new Dictionary<string, string>();

                foreach (var pair in query.Properties())
                {
                    var fieldName = pair.Name.ToString();
                    if(!itemResult.ContainsKey(fieldName)){
                        itemResult.Add(fieldName, item[fieldName].ToString());
                    }
                }

                result.Add(item["symbol"].ToString(), itemResult);
            }

            return result;
        }

    }
}
