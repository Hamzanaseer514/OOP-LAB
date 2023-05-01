using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_constructors_.BL
{
    class coordinate
    {
        public char[,] print;
        public int x;
        public int y;
        public List<int> BulletX = new List<int>();
        public List<int> BulletY = new List<int>();
        public int health;
    }
}
