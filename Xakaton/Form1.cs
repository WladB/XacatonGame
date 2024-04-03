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
        MazeImages images;
        Image mazeImage;
        public Form1()
        {
            InitializeComponent();
            PrimMazeGenerator generator = new PrimMazeGenerator();
            maze = generator.generate();


            images = new MazeImages();
            Graphics g;

            images.wall = new Bitmap(20, 20);
            g = Graphics.FromImage(images.wall);
            g.Clear(Color.Black);

            images.passage = new Bitmap(20, 20);
            g = Graphics.FromImage(images.passage);
            g.Clear(Color.White);

            MazeSprite player = new MazeSprite();
            player.image = new Bitmap(20, 20);
            g = Graphics.FromImage(player.image);
            g.Clear(Color.Red);
            player.name = "player";

            for (int i = 0; i < maze.mazeTiles.GetLength(0); i++)
            {
                for (int j = 0; j < maze.mazeTiles.GetLength(1) ; j++)
                {
                    if (!maze.mazeTiles[i,j].isOcupied)
                    {
                        player.point = new Point(i, j);
                    }
                }
            }

            images.sprites.Add(player);

            mazeImage = maze.drawFragment(new Rectangle(player.point.X - 10, player.point.Y - 10, 20, 20), images, 20);
            //mazeImage = maze.drawFragment(new Rectangle(0, 0, maze.mazeTiles.GetLength(0), maze.mazeTiles.GetLength(1)), images, 20);

        }

        private void RePaint()
        {
            Point player = images.getByName("player").point;
            mazeImage = maze.drawFragment(new Rectangle(player.X - 10, player.Y - 10, 20, 20), images, 20);
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            g.DrawImage(mazeImage, (Width - mazeImage.Width) / 2, (Height - mazeImage.Height) / 2);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AbstractFactory factory = new Room1();
            factory.play();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            RePaint();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            RePaint();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point curPoint = images.getByName("player").point;
            switch (e.KeyCode)
            {
                case Keys.D:
                    if (curPoint.X < maze.mazeTiles.GetLength(0) - 2 && 
                        !maze.mazeTiles[curPoint.X + 1, curPoint.Y].isOcupied)
                    {
                        images.getByName("player").point.X++;
                    } 
                    break;
                case Keys.A:
                    if (curPoint.X > 0 &&
                        !maze.mazeTiles[curPoint.X - 1, curPoint.Y].isOcupied)
                    {
                        images.getByName("player").point.X--;
                    }
                    break;
                case Keys.S:
                    if (curPoint.Y < maze.mazeTiles.GetLength(1) - 2 &&
                        !maze.mazeTiles[curPoint.X, curPoint.Y + 1].isOcupied)
                    {
                        images.getByName("player").point.Y++;
                    }
                    break;
                case Keys.W:
                    if (curPoint.Y > 0 &&
                        !maze.mazeTiles[curPoint.X, curPoint.Y - 1].isOcupied)
                    {
                        images.getByName("player").point.Y--;
                    }
                    break;
                default:
                    break;
            }
            RePaint();
        }
    }
}
