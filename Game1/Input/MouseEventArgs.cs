using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class MouseEventArgs : EventArgs
    {
        #region Data Members

        // Insert Data Members

        // Lists
        private MouseState mMouseState;

        #endregion

        #region Properties - Getters / Setters

        // Keys Pressed on Mouse
        public MouseState Mouse
        {
            get { return mMouseState; }
            set { mMouseState = value; }
        }

        #endregion

        // Constructor
        public MouseEventArgs(MouseState pKeys)
        {
            this.mMouseState = pKeys;
        }
    }
}
