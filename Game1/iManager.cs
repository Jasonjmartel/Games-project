using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    public interface iManager
    {
        // The various managers all generally have at least one list, but the contents
        // vary a lot, and the collision detection has 2 lists, so not this one needs to be
        // worked on later, or can probably be largely ignored.

        //contains update to update the thing they're managing
        void Update();

        // Didn't get used, but left in here since it was a possible thing
    }
}
