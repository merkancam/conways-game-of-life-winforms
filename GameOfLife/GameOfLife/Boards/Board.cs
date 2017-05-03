using GameOfLife.GameOfLife.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.GameOfLife.Boards
{
    public class Board : IBoard
    {
        public int Rows;
        public int Cols;
        public List<Cell> Cells { get; set; }

        public Board(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            GenerateBoard();
        }

        private void GenerateBoard()
        {
            Cells = new List<Cell>();
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    Cell cell = new Cell(r, c, this);
                    Cells.Add(cell);
                }
            }
        }

        public Cell GetCell(int X, int Y)
        {
            var cell = Cells.Where(c => c.X == X && c.Y == Y).FirstOrDefault();

            if (cell == null)
                throw new NullReferenceException($"There is no cell at {X},{Y} location");

            return cell;
        }



    }
}
