using GameOfLife.GameOfLife.Boards;
using GameOfLife.GameOfLife.Rules;
using GameOfLife.GameOfLife.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife.GameOfLife
{
    public class GameOfLifeManager
    {

        private List<IRule> _rules;
        private Board _board;

        public GameOfLifeManager(Board board, List<IRule> rules)
        {
            _rules = rules;
            _board = board;
        }

        public IBoard ImplementRules()
        {
            foreach (var cell in _board.Cells)
            {
                foreach (var rule in _rules)
                {
                    rule.Implement(cell);
                }
            }

            foreach (var cell in _board.Cells)
            {
                if (cell.NextStatus != CellStatus.None)
                    cell.Status = cell.NextStatus;
            }

            return _board;
        }


    }



}
