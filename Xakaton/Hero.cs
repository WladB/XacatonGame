using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xakaton
{
    public class Hero
    {
        public Point location;
        public PictureBox picture;
        public Image heroSprite;
        public Maze maze;
        public int speed = 10;

        public void labMove(string whereToMove)// left, right, up, down
        {
            switch (whereToMove)
            {
                case "left":
                    if (!maze.mazeTiles[location.X - 1, location.Y].isOcupied)
                        location.X--;
                    break;
                case "right":
                    if (!maze.mazeTiles[location.X + 1, location.Y].isOcupied)
                        location.X++;
                    break;
                case "up":
                    if (!maze.mazeTiles[location.X, location.Y - 1].isOcupied)
                        location.Y--;
                    break;
                case "down":
                    if (!maze.mazeTiles[location.X, location.Y + 1].isOcupied)
                        location.Y++;
                    break;
                default:
                    break;
            }
            labDraw();
        }

        public void roomMove(Point point)
        {
            if (this.picture.Right - (this.picture.Width / 2) <= point.X)
            {
                this.picture.Left += speed;
            }
            if (this.picture.Left + (this.picture.Width / 2) >= point.X)
            {
                this.picture.Left -= speed;
            }

            if (this.picture.Bottom - (this.picture.Height / 2) <= point.Y)
            {
                this.picture.Top += speed;
            }
            if (this.picture.Top + (this.picture.Height / 2) >= point.Y)
            {
                this.picture.Top -= speed;
            }
            roomDraw();
        }

        public void roomDraw()
        {
            //TODO:
            //make it draw hero in room
        }

        public void labDraw()
        {
            //TODO:
            //make it draw hero in lab
        }

        public void interact()
        {
            //TODO 
            //make it interact with other objects in room
        }
    }
}
