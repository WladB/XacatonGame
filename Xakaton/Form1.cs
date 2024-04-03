using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xakaton
{
    public partial class Form1 : Form
    {
        private Maze maze;
        private Point playerCords;
        private Image wall;
        private Image passage;
        private Image Player;
        public Form1()
        {
            InitializeComponent();
            PrimMazeGenerator generator = new PrimMazeGenerator();
            maze = generator.generate();


            Graphics g;

            wall = new Bitmap(20, 20);
            g = Graphics.FromImage(wall);
            g.Clear(Color.Black);

            passage = new Bitmap(20, 20);
            g = Graphics.FromImage(passage);
            g.Clear(Color.White);

            wall = new Bitmap(20, 20);
            g = Graphics.FromImage(wall);
            g.Clear(Color.Red);
        }

        private Image DrawMazeFragment(Maze maze, Point upperLeft, Point bottomRight, int cellSize)
        {
            Image resizedWall = new Bitmap(wall, new Size(cellSize, cellSize));

            Image result = new Bitmap((bottomRight.X - upperLeft.X + 1) * cellSize, (bottomRight.Y - upperLeft.Y + 1) * cellSize);
            Graphics g = Graphics.FromImage(result);
            if(upperLeft.X < 0)
            {
                for (int i = 0; i < Math.Abs(upperLeft.X); i++)
                {
                    for (int j = upperLeft.Y; j <= bottomRight.Y; j++)
                    {
                        g.DrawImage(resizedWall, i * cellSize, j * cellSize);
                    }
                }
            }

            if (upperLeft.Y < 0)
            {
                for (int i = 0; i < Math.Abs(upperLeft.Y); i++)
                {
                    for (int j = upperLeft.X; j <= bottomRight.X; j++)
                    {
                        g.DrawImage(resizedWall, j * cellSize, j * cellSize);
                    }
                }
            }

            if (bottomRight.X > maze.mazeTiles.GetLength(0))
            {

            }
            return result;
        }




       
    }
}
