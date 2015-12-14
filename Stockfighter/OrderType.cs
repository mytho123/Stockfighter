using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stockfighter
{
    public abstract class OrderType
    {
        public abstract string Identifier { get; }

        public static readonly OrderType Limit = new LimitOrder();
        public static readonly OrderType Market = new MarketOrder();
        public static readonly OrderType FillOrKill = new FillOrKillOrder();
        public static readonly OrderType ImmediateOrCancel = new ImmediateOrCancelOrder();


        private OrderType() { }

        private class LimitOrder : OrderType
        {
            public override string Identifier
            {
                get { return "limit"; }
            }
        }

        private class MarketOrder : OrderType
        {
            public override string Identifier
            {
                get { return "market"; }
            }
        }

        private class FillOrKillOrder : OrderType
        {
            public override string Identifier
            {
                get { return "fill-or-kill"; }
            }
        }

        private class ImmediateOrCancelOrder : OrderType
        {
            public override string Identifier
            {
                get { return "immediate-or-cancel"; }
            }
        }
    }
}
