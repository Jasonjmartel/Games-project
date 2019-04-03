using Game1.Entities;
using Game1.Physics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.Behaviours
{
    class BlockBehaviour : iBehaviour
    {
        #region datamembers

        //body associated with the mind
        protected iEntity mBody;

        //get/set for the body
        public iEntity Body
        {
            get { return mBody; }
        }

        #endregion

        public BlockBehaviour(BasicBlock pBody)
        {
            // Store associated body
            mBody = pBody;
        }

        #region methods
        // No methods contain code for this behaviour, as it was purely a test bed for the physics/collision engines
        public void collide(iCollide pcollider)
        {
            //unused for this, since the only things that happen on impact are physics based, which are handled elsewhere
        }


        public void update()
        {
            
        }
        #endregion
    }
}
