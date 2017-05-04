using GameOfLife.GameOfLife.Boards;
using GameOfLife.GameOfLife.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.GameOfLife.Cells
{
    public interface ICell
    {
        int GetNeighborsCount(CellStatus SearchCellStatus);
        CellStatus Status { get; set; }
        CellStatus NextStatus { get; set; }
        IBoard Board { get; set; }
    }
}
