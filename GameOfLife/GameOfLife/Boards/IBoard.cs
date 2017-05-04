using GameOfLife.GameOfLife.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.GameOfLife.Boards
{
    public interface IBoard
    {
        List<Cell> Cells { get; set; }
    }
}
