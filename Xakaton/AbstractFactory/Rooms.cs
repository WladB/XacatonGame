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
            int X = 0;
            int Y = 0;
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
            void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                switch(e.KeyCode) {
                    case Keys.W: Y--;  break;
                    case Keys.A: X--;  break;
                    case Keys.D: X++;  break;
                    case Keys.S: Y++;  break;
                }
            }
            Timer timer = new Timer();
            timer.Tick += timer1_Tick;
            form1.Text = "Room1 Level";
            form1.BackColor = Color.White;
            form1.Width = 1149;
            form1.Height = 720;
            form1.Controls.Add(picturePlayer);
            form1.KeyDown += Form1_KeyDown;
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

