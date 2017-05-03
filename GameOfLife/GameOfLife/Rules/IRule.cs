using GameOfLife.GameOfLife.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.GameOfLife.Rules
{
    public interface IRule
    {
        void Implement(ICell cell);
    }
}
