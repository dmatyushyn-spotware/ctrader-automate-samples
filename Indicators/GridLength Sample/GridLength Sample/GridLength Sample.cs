﻿using cAlgo.API;

namespace cAlgo
{
    // This sample shows how to use GridLength
    [Indicator(IsOverlay = true, TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class GridLengthSample : Indicator
    {
        [Parameter("Grid Row Length", DefaultValue = 2)]
        public int GridRowLength { get; set; }

        [Parameter("Grid Row Length Unit Type", DefaultValue = GridUnitType.Auto)]
        public GridUnitType GridRowLengthUnitType { get; set; }

        [Parameter("Grid Column Length", DefaultValue = 2)]
        public int GridColumnLength { get; set; }

        [Parameter("Grid Column Length Unit Type", DefaultValue = GridUnitType.Auto)]
        public GridUnitType GridColumnLengthUnitType { get; set; }

        protected override void Initialize()
        {
            var grid = new Grid(2, 2) 
            {
                BackgroundColor = Color.Gold,
                Opacity = 0.6,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                ShowGridLines = true
            };
            for (int iRow = 0; iRow < 2; iRow++)
            {
                var row = grid.Rows[iRow];
                SetGridRowLength(row);
                for (int iColumn = 0; iColumn < 2; iColumn++)
                {
                    var column = grid.Columns[iColumn];
                    SetGridColumnLength(column);
                    grid.AddChild(new TextBlock 
                    {
                        Text = string.Format("Row {0} and Column {1}", iRow, iColumn),
                        Margin = 5,
                        ForegroundColor = Color.Black,
                        FontWeight = FontWeight.ExtraBold
                    }, iRow, iColumn);
                }
            }
            Chart.AddControl(grid);
        }

        private void SetGridRowLength(GridRow row)
        {
            switch (GridRowLengthUnitType)
            {
                case GridUnitType.Auto:
                    row.SetHeightToAuto();
                    break;

                case GridUnitType.Pixel:
                    row.SetHeightInPixels(GridRowLength);
                    break;

                case GridUnitType.Star:
                    row.SetHeightInStars(GridRowLength);
                    break;
            }
        }

        private void SetGridColumnLength(GridColumn column)
        {
            switch (GridColumnLengthUnitType)
            {
                case GridUnitType.Auto:
                    column.SetWidthToAuto();
                    break;

                case GridUnitType.Pixel:
                    column.SetWidthInPixels(GridColumnLength);
                    break;

                case GridUnitType.Star:
                    column.SetWidthInStars(GridColumnLength);
                    break;
            }
        }

        public override void Calculate(int index)
        {
        }
    }
}
