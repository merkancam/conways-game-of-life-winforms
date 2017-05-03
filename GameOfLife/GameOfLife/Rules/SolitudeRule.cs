using GameOfLife.GameOfLife.Cells;
using GameOfLife.GameOfLife.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.GameOfLife.Rules
{
    public class SolitudeRule : IRule
    {
        public void Implement(ICell cell)
        {
            if (cell.Status == CellStatus.Dead)
                return;

            int aliveNeighborsCount = cell.GetNeighborsCount(CellStatus.Alive);
            if (aliveNeighborsCount < 2)
            {
                cell.SetNewCellStatus(CellStatus.Dead);
            }
        }
    }
}
