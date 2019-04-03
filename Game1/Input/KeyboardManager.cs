using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    // TODO: Work out what the main issue is when trying to use EventArgs instead of KeyBoardEventArgs/MouseEventArgs

    // delegate - declaration of method signature
    public delegate void EventHandler(object pSource, IList<KeyBoardEventArgs> pInput);

    public class KeyboardManager : iInputManager, iManager
{
        #region Data Members

        // Insert Data Members
        private KeyboardState mKeysPressed;

        // Events
        public event EventHandler<KeyBoardEventArgs> newInput;

        #endregion

        public KeyboardManager()
        {

        }

        // Event Publisher method
        protected virtual void onNewInput(KeyboardState pKeysPressed)
        {
            KeyBoardEventArgs args = new KeyBoardEventArgs(pKeysPressed);
            newInput(this, args);
        }

        // Subscribe listener
        public void addListener(EventHandler<KeyBoardEventArgs> pSubcribe)
        {
            // Add listener
            newInput += pSubcribe;
        }

        // Un-subscribe listener
        public void removeListener(EventHandler<KeyBoardEventArgs> pUnsubcribe)
        {
            // Remove Listener??? not sure if correct
            newInput -= pUnsubcribe;
        }

        public void Update()
        {
            // Look for changes in input data
            KeyboardState keyboardState = Keyboard.GetState();
            if ((keyboardState != mKeysPressed) & newInput != null) {
                onNewInput(keyboardState);
            }
            mKeysPressed = keyboardState;
        }
    }
}
