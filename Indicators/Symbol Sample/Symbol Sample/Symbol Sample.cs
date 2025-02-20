﻿using cAlgo.API;
using cAlgo.API.Internals;
using System;

namespace cAlgo
{
    /// <summary>
    /// This sample indicator shows how to get a symbol data
    /// </summary>
    [Indicator(IsOverlay = true, TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class SymbolSample : Indicator
    {
        private TextBlock _spreadTextBlock;
        private TextBlock _bidTextBlock;
        private TextBlock _askTextBlock;
        private TextBlock _unrealizedGrossProfitTextBlock;
        private TextBlock _unrealizedNetProfitTextBlock;
        private TextBlock _timeTillOpenTextBlock;
        private TextBlock _timeTillCloseTextBlock;
        private TextBlock _isOpenedTextBlock;
        private Symbol _symbol;

        [Parameter("Use Current Symbol", DefaultValue = true)]
        public bool UseCurrentSymbol { get; set; }

        [Parameter("Other Symbol Name", DefaultValue = "GBPUSD")]
        public string OtherSymbolName { get; set; }

        protected override void Initialize()
        {
            var grid = new Grid(24, 2) 
            {
                BackgroundColor = Color.Gold,
                Opacity = 0.6,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            var style = new Style();

            style.Set(ControlProperty.Padding, 1);
            style.Set(ControlProperty.Margin, 2);
            style.Set(ControlProperty.BackgroundColor, Color.Black);
            style.Set(ControlProperty.FontSize, 8);

            _symbol = UseCurrentSymbol ? Symbol : Symbols.GetSymbol(OtherSymbolName);

            grid.AddChild(new TextBlock 
            {
                Text = "Symbol Info",
                Style = style,
                HorizontalAlignment = HorizontalAlignment.Center
            }, 0, 0, 1, 2);

            grid.AddChild(new TextBlock 
            {
                Text = "Name",
                Style = style
            }, 1, 0);
            grid.AddChild(new TextBlock 
            {
                Text = _symbol.Name,
                Style = style
            }, 1, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "ID",
                Style = style
            }, 2, 0);
            grid.AddChild(new TextBlock 
            {
                Text = _symbol.Id.ToString(),
                Style = style
            }, 2, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Digits",
                Style = style
            }, 3, 0);
            grid.AddChild(new TextBlock 
            {
                Text = _symbol.Digits.ToString(),
                Style = style
            }, 3, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Description",
                Style = style
            }, 4, 0);
            grid.AddChild(new TextBlock 
            {
                Text = _symbol.Description,
                Style = style
            }, 4, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Lot Size",
                Style = style
            }, 5, 0);
            grid.AddChild(new TextBlock 
            {
                Text = _symbol.LotSize.ToString(),
                Style = style
            }, 5, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Pip Size",
                Style = style
            }, 6, 0);
            grid.AddChild(new TextBlock 
            {
                Text = _symbol.PipSize.ToString(),
                Style = style
            }, 6, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Pip Value",
                Style = style
            }, 7, 0);
            grid.AddChild(new TextBlock 
            {
                Text = _symbol.PipValue.ToString(),
                Style = style
            }, 7, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Tick Size",
                Style = style
            }, 8, 0);
            grid.AddChild(new TextBlock 
            {
                Text = _symbol.TickSize.ToString(),
                Style = style
            }, 8, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Tick Value",
                Style = style
            }, 9, 0);
            grid.AddChild(new TextBlock 
            {
                Text = _symbol.TickValue.ToString(),
                Style = style
            }, 9, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Volume In Units Max",
                Style = style
            }, 10, 0);
            grid.AddChild(new TextBlock 
            {
                Text = _symbol.VolumeInUnitsMax.ToString(),
                Style = style
            }, 10, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Volume In Units Min",
                Style = style
            }, 11, 0);
            grid.AddChild(new TextBlock 
            {
                Text = _symbol.VolumeInUnitsMin.ToString(),
                Style = style
            }, 11, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Volume In Units Step",
                Style = style
            }, 12, 0);
            grid.AddChild(new TextBlock 
            {
                Text = _symbol.VolumeInUnitsStep.ToString(),
                Style = style
            }, 12, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Ask",
                Style = style
            }, 13, 0);

            _askTextBlock = new TextBlock 
            {
                Text = _symbol.Ask.ToString(),
                Style = style
            };

            grid.AddChild(_askTextBlock, 13, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Bid",
                Style = style
            }, 14, 0);

            _bidTextBlock = new TextBlock 
            {
                Text = _symbol.Bid.ToString(),
                Style = style
            };

            grid.AddChild(_bidTextBlock, 14, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Spread",
                Style = style
            }, 15, 0);

            _spreadTextBlock = new TextBlock 
            {
                Text = _symbol.Spread.ToString(),
                Style = style
            };

            grid.AddChild(_spreadTextBlock, 15, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Unrealized Gross Profit",
                Style = style
            }, 16, 0);

            _unrealizedGrossProfitTextBlock = new TextBlock 
            {
                Text = _symbol.UnrealizedGrossProfit.ToString(),
                Style = style
            };

            grid.AddChild(_unrealizedGrossProfitTextBlock, 16, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Unrealized Net Profit",
                Style = style
            }, 17, 0);

            _unrealizedNetProfitTextBlock = new TextBlock 
            {
                Text = _symbol.UnrealizedNetProfit.ToString(),
                Style = style
            };

            grid.AddChild(_unrealizedNetProfitTextBlock, 17, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Time Till Open",
                Style = style
            }, 18, 0);

            _timeTillOpenTextBlock = new TextBlock 
            {
                Text = _symbol.MarketHours.TimeTillOpen().ToString(),
                Style = style
            };

            grid.AddChild(_timeTillOpenTextBlock, 18, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Time Till Close",
                Style = style
            }, 19, 0);

            _timeTillCloseTextBlock = new TextBlock 
            {
                Text = _symbol.MarketHours.TimeTillClose().ToString(),
                Style = style
            };

            grid.AddChild(_timeTillCloseTextBlock, 19, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Is Opened",
                Style = style
            }, 20, 0);

            _isOpenedTextBlock = new TextBlock 
            {
                Text = _symbol.MarketHours.IsOpened().ToString(),
                Style = style
            };

            grid.AddChild(_isOpenedTextBlock, 20, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Trading Sessions #",
                Style = style
            }, 21, 0);

            grid.AddChild(new TextBlock 
            {
                Text = _symbol.MarketHours.Sessions.Count.ToString(),
                Style = style
            }, 21, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Trading Session Week Days",
                Style = style
            }, 22, 0);

            var weekDays = string.Empty;

            for (var iSession = 0; iSession < _symbol.MarketHours.Sessions.Count; iSession++)
            {
                var currentSessionWeekDays = string.Format("{0}({1})-{2}({3})", _symbol.MarketHours.Sessions[iSession].StartDay, _symbol.MarketHours.Sessions[iSession].StartTime, _symbol.MarketHours.Sessions[iSession].EndDay, _symbol.MarketHours.Sessions[iSession].EndTime);

                weekDays = iSession == 0 ? currentSessionWeekDays : string.Format("{0}, {1}", weekDays, currentSessionWeekDays);
            }

            grid.AddChild(new TextBlock 
            {
                Text = weekDays,
                Style = style
            }, 22, 1);

            grid.AddChild(new TextBlock 
            {
                Text = "Leverage Tier",
                Style = style
            }, 23, 0);

            var leverageTiers = string.Empty;

            for (var iLeveragTier = 0; iLeveragTier < _symbol.DynamicLeverage.Count; iLeveragTier++)
            {
                var currentLeverageTiers = string.Format("Volume up to {0} is {1}", _symbol.DynamicLeverage[iLeveragTier].Volume, _symbol.DynamicLeverage[iLeveragTier].Leverage);

                leverageTiers = iLeveragTier == 0 ? currentLeverageTiers : string.Format("{0}, {1}", leverageTiers, currentLeverageTiers);
            }

            grid.AddChild(new TextBlock 
            {
                Text = leverageTiers,
                Style = style
            }, 23, 1);

            Chart.AddControl(grid);

            _symbol.Tick += Symbol_Tick;

            Timer.Start(TimeSpan.FromSeconds(1));
        }

        private void Symbol_Tick(SymbolTickEventArgs obj)
        {
            _askTextBlock.Text = obj.Symbol.Ask.ToString();
            _bidTextBlock.Text = obj.Symbol.Bid.ToString();
            _spreadTextBlock.Text = obj.Symbol.Spread.ToString();
            _unrealizedGrossProfitTextBlock.Text = obj.Symbol.UnrealizedGrossProfit.ToString();
            _unrealizedNetProfitTextBlock.Text = obj.Symbol.UnrealizedNetProfit.ToString();
        }

        protected override void OnTimer()
        {
            _timeTillOpenTextBlock.Text = _symbol.MarketHours.TimeTillOpen().ToString();
            _timeTillCloseTextBlock.Text = _symbol.MarketHours.TimeTillClose().ToString();
            _isOpenedTextBlock.Text = _symbol.MarketHours.IsOpened().ToString();
        }

        public override void Calculate(int index)
        {
        }
    }
}
