using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xakaton
{
    class Decor {// клас для того, щоб було зручно додавати пікче бокси в ліст 
        public Image img;
        public Point location;
        public Size size;
        private PictureBox picture;
        public Decor(Image p, Point l, Size s) {
            img = p;
            location = l;
            size = s;
            picture = new PictureBox();
            picture.Image = img;
            picture.Location = location;
            picture.Size = size;
        }
        public PictureBox GetPictureBox(){
            return picture;
        }
    }
    class DecorRoom1 : RoomsDecor
    {
        public override void start()
        {
            listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("OffRoad1"), new Point(), new Size()).GetPictureBox());
        }
        public override void show(Form form)
        {
            for(int i = 0; i< listDecor.Count; i++) {
                form.Controls.Add((PictureBox)listDecor[i]);
            }
        }
    }
    class DecorRoom2 : RoomsDecor
    {
        public override void start()
        {
           listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("OffRoad1"), new Point(), new Size()).GetPictureBox());
           listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("OffRoad1"), new Point(), new Size()).GetPictureBox());
        }
        public override void show(Form form)
        {
            for (int i = 0; i < listDecor.Count; i++)
            {
                form.Controls.Add((PictureBox)listDecor[i]);
            }
        }
    }
    class DecorRoom3 : RoomsDecor
    {
        public override void start()
        {
            listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("OffRoad1"), new Point(), new Size()).GetPictureBox());
        }
        public override void show(Form form)
        {
            for (int i = 0; i < listDecor.Count; i++)
            {
                form.Controls.Add((PictureBox)listDecor[i]);
            }
        }
    }
}
