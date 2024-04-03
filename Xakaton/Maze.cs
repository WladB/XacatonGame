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
    public class MazeTile
    {
        public bool isOcupied;//if tile is the wall
        public int x;
        public int y;
        public MazeTile()
        {
            isOcupied = true;
            x = y = 0;
        }
    }
    public class Maze
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
    } 

    interface IMazeGenerator
    {
        Maze generate(); 
    }
}