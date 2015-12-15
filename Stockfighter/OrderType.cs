using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stockfighter
{
    public static class OrderType
    {
        public const string Limit = "limit";
        public const string Market = "market";
        public const string FillOrKill = "fill-or-kill";
        public const string ImmediateOrCancel = "immediate-or-cancel";
    }
}
