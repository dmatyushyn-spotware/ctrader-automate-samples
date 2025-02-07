﻿using cAlgo.API;
using cAlgo.API.Internals;

namespace cAlgo
{
    /// <summary>
    /// This sample indicator shows how to get a symbol and time frame market data
    /// </summary>
    [Indicator(IsOverlay = true, TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class MarketDataSample : Indicator
    {
        private Bars _bars;

        private Ticks _ticks;

        private MarketDepth _marketDepth;

        [Parameter("Use Current Symbol", DefaultValue = true)]
        public bool UseCurrentSymbol { get; set; }

        [Parameter("Other Symbol Name", DefaultValue = "GBPUSD")]
        public string OtherSymbolName { get; set; }

        [Parameter("Use Current TimeFrame", DefaultValue = true)]
        public bool UseCurrentTimeFrame { get; set; }

        [Parameter("Other TimeFrame", DefaultValue = "Daily")]
        public TimeFrame OtherTimeFrame { get; set; }

        protected override void Initialize()
        {
            var symbol = UseCurrentSymbol ? Symbol : Symbols.GetSymbol(OtherSymbolName);
            var timeframe = UseCurrentTimeFrame ? TimeFrame : OtherTimeFrame;

            // You can use GetBarsAsync instead of GetBars
            _bars = MarketData.GetBars(timeframe, symbol.Name);
            // You can use GetTicksAsync instead of GetTicks
            _ticks = MarketData.GetTicks(symbol.Name);

            _marketDepth = MarketData.GetMarketDepth(symbol.Name);
        }

        public override void Calculate(int index)
        {
        }
    }
}
