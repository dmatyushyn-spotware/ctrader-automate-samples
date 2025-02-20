﻿using cAlgo.API;
using cAlgo.API.Indicators;

namespace cAlgo.Robots
{
    /// <summary>
    /// This sample cBot shows how to use the Positive/Negative Volume Index indicators
    /// </summary>
    [Robot(TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class VolumeIndexSample : Robot
    {
        private double _volumeInUnits;

        private PositiveVolumeIndex _positiveVolumeIndex;
        private NegativeVolumeIndex _negativeVolumeIndex;

        private SimpleMovingAverage _simpleMovingAverage;

        [Parameter("Volume (Lots)", DefaultValue = 0.01)]
        public double VolumeInLots { get; set; }

        [Parameter("Stop Loss (Pips)", DefaultValue = 10)]
        public double StopLossInPips { get; set; }

        [Parameter("Take Profit (Pips)", DefaultValue = 10)]
        public double TakeProfitInPips { get; set; }

        [Parameter("Label", DefaultValue = "Sample")]
        public string Label { get; set; }

        public Position[] BotPositions
        {
            get
            {
                return Positions.FindAll(Label);
            }
        }

        protected override void OnStart()
        {
            _volumeInUnits = Symbol.QuantityToVolumeInUnits(VolumeInLots);

            _positiveVolumeIndex = Indicators.PositiveVolumeIndex(Bars.ClosePrices);
            _negativeVolumeIndex = Indicators.NegativeVolumeIndex(Bars.ClosePrices);

            _simpleMovingAverage = Indicators.SimpleMovingAverage(Bars.ClosePrices, 20);
        }

        protected override void OnBar()
        {
            if (Bars.ClosePrices.Last(1) > _simpleMovingAverage.Result.Last(1))
            {
                ClosePositions(TradeType.Sell);

                if (BotPositions.Length == 0 && _negativeVolumeIndex.Result.Last(1) > _positiveVolumeIndex.Result.Last(1))
                {
                    ExecuteMarketOrder(TradeType.Buy, SymbolName, _volumeInUnits, Label, StopLossInPips, TakeProfitInPips);
                }
            }
            else if (Bars.ClosePrices.Last(1) < _simpleMovingAverage.Result.Last(1))
            {
                ClosePositions(TradeType.Buy);

                if (BotPositions.Length == 0 && _negativeVolumeIndex.Result.Last(1) > _positiveVolumeIndex.Result.Last(1))
                {
                    ExecuteMarketOrder(TradeType.Sell, SymbolName, _volumeInUnits, Label, StopLossInPips, TakeProfitInPips);
                }
            }
        }

        private void ClosePositions(TradeType tradeType)
        {
            foreach (var position in BotPositions)
            {
                if (position.TradeType != tradeType) continue;

                ClosePosition(position);
            }
        }
    }
}