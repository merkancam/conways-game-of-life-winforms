using GameOfLife.GameOfLife.Boards;
using GameOfLife.GameOfLife.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.GameOfLife.Cells
{
    public class Cell :  ICell
    {
        public Cell(int xLocation, int yLocation, Board board)
        {
            X = xLocation;
            Y = yLocation;
            Status = CellStatus.Dead;
            NextStatus = CellStatus.None;
            Board = board;
        }


        public CellStatus NextStatus { get; set; }
        public CellStatus Status { get; set; }
        public IBoard Board { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Color CellColor
        {
            get
            {
                switch (Status)
                {
                    case CellStatus.Dead:
                        return Color.LightGray;
                    case CellStatus.Alive:
                        return Color.Green;
                    default:
                        return Color.LightGray;
                }
            }
        }

        public virtual int GetNeighborsCount(CellStatus SearchCellStatus)
        {
            int[,] SearchLocations = new int[,] { { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, -1 } };

            int neighborCount = 0;
            for (int i = 0; i < SearchLocations.Length / 2; i++)
            {
                int xOfNeighborCell = X + SearchLocations[i, 0];
                int yOfNeigborCell = Y + SearchLocations[i, 1];
                var neighborCell = Board.Cells.Where(x => x.X == xOfNeighborCell && x.Y == yOfNeigborCell).FirstOrDefault();

                if (neighborCell == null)
                {
                    //if (SearchCellStatus == CellStatus.Dead)
                    //    neighborCount++;

                    continue;
                }

                if (neighborCell.Status == SearchCellStatus)
                {
                    neighborCount++;
                }
            }
            return neighborCount;
        }


    }
}
