using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    public interface iBehaviour
    {
        // Body associated with the behaviour
        iEntity Body { get; }

        #region methods
        // Update
        void update();
        // Collision has been detected        
        void collide(iCollide pcollider);
        #endregion
    }
}
