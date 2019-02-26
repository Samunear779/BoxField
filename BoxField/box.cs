using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoxField
{
    class box
    {
        //need colour eventually 
        public int x, y, size;

        public box(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }

        //TODO move method 
        public void Move(int speed)
        {
            y += speed;
        }

        public void Move(int speed, string direction)
        {
           if(direction == "right")
            {
                x += speed;
            }
           else if(direction == "left")
            {
                x -= speed;
            }
        }

        public bool Collision(box b)
        {
            Rectangle rect1 = new Rectangle(b.x, b.y, b.size, b.size);
            Rectangle rect2 = new Rectangle(x, y, size, size);

            if (rect1.IntersectsWith(rect2))
            {
                return true;
            }
                return false;        
        }

    }
}
