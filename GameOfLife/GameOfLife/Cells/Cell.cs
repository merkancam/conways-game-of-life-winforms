using GameOfLife.GameOfLife.Boards;
using GameOfLife.GameOfLife.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.GameOfLife.Cells
{
    public class Cell : CellBase, ICell
    {
        public Cell(int xLocation, int yLocation, Board board)
        {
            X = xLocation;
            Y = yLocation;
            Status = CellStatus.Dead;
            Board = board;
        }
    }
}
