using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    // TODO: Work out what the main issue is when trying to use EventArgs instead of KeyBoardEventArgs/MouseEventArgs

    // delegate - declaration of method signature
    public delegate void EventHandlerMouse(object pSource, IList<MouseEventArgs> pInput);

    public class MouseManager : iInputManager, iManager
    {
        #region Data Members

        // Insert Data Members
        private MouseState mMouseState;

        // Events
        public event EventHandler<MouseEventArgs> newInput;

        #endregion

        public MouseManager()
        {

        }

        // Event Publisher method
        protected virtual void onNewInput(MouseState pKeysPressed)
        {
            MouseEventArgs args = new MouseEventArgs(pKeysPressed);
            newInput(this, args);
        }

        // Subscribe listener
        public void addListener(EventHandler<MouseEventArgs> pSubcribe)
        {
            // Add listener
            newInput += pSubcribe;
        }

        // Un-subscribe listener
        public void removeListener(EventHandler<MouseEventArgs> pUnsubcribe)
        {
            // Remove Listener
            newInput -= pUnsubcribe;
        }

        public void Update()
        {
            // Look for changes in input data
            MouseState MouseState = Mouse.GetState();
            if ((MouseState != mMouseState) & newInput != null)
            {
                if (MouseState.LeftButton == ButtonState.Pressed) {
                    onNewInput(MouseState);
                }
            }
            mMouseState = MouseState;
        }
    }
}

