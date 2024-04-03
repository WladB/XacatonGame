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

            for (int i = maze.mazeTiles.GetLength(0) - 1; i >= 0 ; i--)
            {
                for (int j = maze.mazeTiles.GetLength(1) - 1; j >= 0 ; j--)
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
    }
}
