using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooAddin.Finance
{

    interface IUrlBuilder
    {
        string Prefix{get;}
        string Env { get; }
        string Format { get; }
        string Yql { get; }
        string ToUrl();
    }

}
