using GameOfLife.GameOfLife;
using GameOfLife.GameOfLife.Boards;
using GameOfLife.GameOfLife.Cells;
using GameOfLife.GameOfLife.Rules;
using GameOfLife.GameOfLife.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Game : Form
    {
        private int squareSize = 15;
        private int topMargin = 40;

        List<Square> squares = new List<Square>();
        Board board = new Board(32, 48);
        List<IRule> rules = new List<IRule>()
            {
                new SolitudeRule(),
                new SurviveRule(),
                new OverPopulationRule(),
                new BornRule()
            };

        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            timer.Enabled = true;
            timer.Stop();
            this.StartPosition = FormStartPosition.CenterScreen;
            DrawBoard(board);
        }



        public void DrawBoard(Board board)
        {
            for (int r = 0; r < board.Rows; r++)
            {
                int y = r * (squareSize + 1) + topMargin;
                for (int c = 0; c < board.Cols; c++)
                {
                    int x = c * (squareSize + 1);
                    squares.Add(new Square(board.GetCell(r, c), new System.Drawing.Point(x, y), squareSize));
                }
            }
            this.Controls.AddRange(squares.ToArray());
        }



        private void timer_Tick(object sender, EventArgs e)
        {
            GameOfLifeManager manager = new GameOfLifeManager(board, rules);
            manager.ImplementRules();
            RefreshBoardView();
        }

        private void RefreshBoardView()
        {
            foreach (var s in squares)
            {
                s.RefreshColor();
            }
        }


        private void bStart_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == true)
                return;
            timer.Start();
            GameOfLifeManager manager = new GameOfLifeManager(board, rules);
            manager.ImplementRules();
            RefreshBoardView();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void bClean_Click(object sender, EventArgs e)
        {
            timer.Stop();
            foreach (var cell in board.Cells)
            {
                cell.Status = CellStatus.Dead;
                cell.NextStatus = CellStatus.None;
            }
            RefreshBoardView();
        }
    }




    public class Square : Panel
    {
        public Cell Cell { get; set; }

        public void RefreshColor()
        {
            this.BackColor = Cell.CellColor;
        }

        public void ReverseColor()
        {
            if (Cell.Status == CellStatus.Alive)
                Cell.Status = CellStatus.Dead;
            else
                Cell.Status = CellStatus.Alive;

            this.BackColor = this.Cell.CellColor;
        }

        public Square(Cell cell, Point location, int size)
        {
            Cell = cell;
            Height = size;
            Width = size;
            Location = location;
            BackColor = Cell.CellColor;
            Click += new EventHandler(Square_Click);
        }

        private void Square_Click(object sender, EventArgs e)
        {
            Square square = (Square)sender;
            square.ReverseColor();
        }
    }


}
