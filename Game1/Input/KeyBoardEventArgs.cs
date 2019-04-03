using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Game1
{
    /// <summary>
    /// Class for the Event Data
    /// </summary>
    public class KeyBoardEventArgs : EventArgs
    {
        #region Data Members

        // Insert Data Members

        // Lists
        private KeyboardState mKeysPressed;

        #endregion

        #region Properties - Getters / Setters

        // Keys Pressed on Keyboard
        public KeyboardState KeysPressed
        {
            get { return mKeysPressed; }
            set { mKeysPressed = value; }
        }

        #endregion

        // Constructor
        public KeyBoardEventArgs(KeyboardState pKeys)
        {
            this.mKeysPressed = pKeys;
        }
    }
}
