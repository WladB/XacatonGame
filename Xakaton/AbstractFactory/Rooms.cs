using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xakaton
{
    class Rooms1 : AbstractFactory
    {
        public override AbstractEnemy CreateEnemyOgr()
        {
            return new Ogr1();
        }
        public override AbstractEnemy CreateEnemyGoblin()
        {
            return new Goblin1();
        }
        public override AbstractEnemy CreateEnemyBomb()
        {
            return new Bomb();
        }
        public override AbstractRoomLogic CreateRoomLogic()
        {
            return new RoomsLogic1();
        }
        public override RoomsDecor CreateDecor()
        {
            return new DecorRoom1();
        }
        public override void play()
        {
            Form form1 = new Form();
            PictureBox picturePlayer = new PictureBox();
            Player player = new Player(picturePlayer);
           // new Point(X, Y);
             void timer1_Tick(object sender, EventArgs e)
            {
                player.move(new Point(X, Y));
                player.Attack(form1);
                //progressBar1.Value = player.health;
            }
            
            Timer timer = new Timer();
            timer.Tick += timer1_Tick;
            form1.Text = "Room1 Level";
            form1.BackColor = Color.White;
            form1.Width = 1000;
            form1.Height = 500;
            form1.Controls.Add(picturePlayer);
            ogr = CreateEnemyOgr();
            goblin = CreateEnemyGoblin();
            bomb = CreateEnemyBomb();
            logic = CreateRoomLogic();
            decor = CreateDecor();
            player.enemies.Add(ogr);
            player.enemies.Add(goblin);
            player.enemies.Add(bomb);
            ogr.start();
            goblin.start();
            bomb.start();
            logic.start();
            decor.start();
            ogr.show(form1);
            goblin.show(form1);
            bomb.show(form1);
            logic.show(form1);
            decor.show(form1);
            bomb.show(form1);
            form1.Show();
        }
    }
}

