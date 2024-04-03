
namespace Xakaton
{
    class MazeTile
    {
        public bool isOcupied;
    }
    class Maze
    {
        public MazeTile[,] mazeTiles;
        public Maze()
        {
            mazeTiles = new MazeTile[50,50];
        }  
    } 

    interface IMazeGenerator
    {
        Maze generate(); 
    }
}