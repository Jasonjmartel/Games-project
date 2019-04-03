using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game1.Collision
{                               // A class to store the locations of imovable objects (could be replaced with Rectangle class theoretically, but this allows for adding unique methods)
    public class Imobox
    {
        //data members
        private int mtop, mbottom, mleft, mright;

        public Imobox(int p1, int p2, int p3, int p4)
        {
            mtop = p1;
            mbottom = p2;
            mleft = p3;
            mright = p4;
        }

        // methods to return the variables (needs to be changed to getters later)
        public int top()
        {
            return mtop;
        }
        public int bottom()
        {
            return mbottom;
        }
        public int left()
        {
            return mleft;
        }
        public int right()
        {
            return mright;
        }
        // Might want to add a 'move' method later? For stuff like moving platforms, etc
    }
}
