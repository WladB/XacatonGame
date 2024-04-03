
namespace Xakaton
{
    class MazeTile
    {
        public bool isOcupied;
        public int x;
        public int y;
        MazeTile()
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
    } 

    interface IMazeGenerator
    {
        Maze generate(); 
    }
}