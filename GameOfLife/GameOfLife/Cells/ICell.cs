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
        void SetNewCellStatus(CellStatus NewCellStatus);
        CellStatus Status { get; set; }
    }
}
