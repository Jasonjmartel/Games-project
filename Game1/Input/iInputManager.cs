using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public interface iInputManager//:iManager
    {
        //@Zaib if you're going to use InputEventArgs just for Keyboard then you can't use in the interface here
        // Commented out for now (but helps keep track of building KeyboardManagers still)
        // Done some changes for making this useful again later, but don't have time to fix right now

        /*// Define event
        event EventHandler<EventArgs> newInput;

        // Event Publisher
        //protected virtual void onNewInput(object source, InputEventArgs args);

        // Listeners to subcribe
        void addListener(EventHandler<EventArgs> pSubcribe);

        // Listeners to un-sub
        void removeListener(EventHandler<EventArgs> pUnsubcribe);

        */

        //Further notes: Trying to shift to using EventArgs instead of the specific versions in the regular manager
        // keeps causing crashes. (can't convert methodgroup). Being caused in listener, but can't further to see
        // if it would keep on in the other methods too. If there's time do extra research to try and fix this.

        // A bried method might be trying and making a temporary interface which draws from EventArgs and see if that
        // helps.
        //void Update();
    }
}
