using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stockfighter.HttpModels
{
    internal class StocksResponse
    {
        public bool ok { get; set; }
        public Stock[] symbols { get; set; }
    }
}
