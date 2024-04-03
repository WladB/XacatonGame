using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Xakaton
{
    class MazeSprites
    {
        public Image wall;
        public Image passage;
        public Image player;
    }
    class MazeTile
    {
        public bool isOcupied;
        public int x;
        public int y;
        public MazeTile()
        {
            isOcupied = true;
            x = y = 0;
        }
    }
    class Maze
    {
        public MazeTile[,] mazeTiles;
        public Maze()
        {
            mazeTiles = new MazeTile[50,50];
            for(int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    mazeTiles[i,j] = new MazeTile();
                    mazeTiles[i,j].x = i;
                    mazeTiles[i,j].y = j;
                }
            }
        }  

        private Point toImageCords(Point p, Rectangle area, int cellSize)
        {
            Point result = new Point();
            result.X = (p.X - area.X)*cellSize;
            result.Y = (p.Y - area.Y)*cellSize;
            return result;
        }

        public Image drawFragment(Rectangle area, MazeSprites sprites, Point player, int cellSize)
        {
            sprites.wall = new Bitmap(sprites.wall, new Size(cellSize, cellSize));
            sprites.passage = new Bitmap(sprites.passage, new Size(cellSize, cellSize));
            sprites.player = new Bitmap(sprites.player, new Size(cellSize, cellSize));

            Image result = new Bitmap((area.Width + 1) * cellSize, (area.Height + 1) * cellSize);
            Graphics g = Graphics.FromImage(result);
            if(area.Left < 0)
            {
                for (int i = area.Left; i < 0; i++)
                {
                    for (int j = area.Top; j < area.Bottom; j++)
                    {
                        g.DrawImage(sprites.wall, toImageCords(new Point(i,j), area, cellSize));
                    }
                }
            }

            if (area.Top < 0)
            {
                for (int i = area.Left; i < area.Right; i++)
                {
                    for (int j = area.Top; j < 0; j++)
                    {
                        g.DrawImage(sprites.wall, toImageCords(new Point(i,j), area, cellSize));
                    }
                }
            }

            if (area.Right >= mazeTiles.GetLength(0))
            {
                for (int i = mazeTiles.GetLength(0); i < area.Right + 1; i++)
                {
                    for (int j = area.Top; j < area.Bottom; j++)
                    {
                        g.DrawImage(sprites.wall, toImageCords(new Point(i,j), area, cellSize));
                    }
                }  
            }

            if (area.Bottom >= mazeTiles.GetLength(1))
            {
                for (int i = area.Left; i < area.Right; i++)
                {
                    for (int j = mazeTiles.GetLength(1); j < area.Bottom + 1; j++)
                    {
                        g.DrawImage(sprites.wall, toImageCords(new Point(i,j), area, cellSize));
                    }
                }
            }

            for (int i = area.Left; i < area.Right + 1; i++)
            {
                for (int j = area.Top; j < area.Bottom + 1; j++)
                {
                    if(i >=0 && j >= 0 && i < mazeTiles.GetLength(0) && j < mazeTiles.GetLength(1))
                    {
                        if(player.X == i && player.Y == j)
                        {
                            g.DrawImage(sprites.player, toImageCords(new Point(i,j), area, cellSize));
                        }  
                        else
                        {
                            if(mazeTiles[i,j].isOcupied)
                            {
                                g.DrawImage(sprites.wall, toImageCords(new Point(i,j), area, cellSize));   
                            }   
                            else
                            {
                                g.DrawImage(sprites.passage, toImageCords(new Point(i,j), area, cellSize));       
                            }    
                        }
                    } 
                }
            }

            
            return result;  

        }
    } 

    

    interface IMazeGenerator
    {
        Maze generate(); 
    }
}