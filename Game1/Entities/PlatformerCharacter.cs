using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.Entities
{
    class PlatformerCharacter : PhysicsEntity, iCollide
    {
        //constructor
        public PlatformerCharacter()
        {
            setPosition(mPosition.X, mPosition.Y);
            mcoll = 36;
            mSpeed = 0;
            grav = 0.1F;
            Fixed = false;
            mMass = 100;
            mVelocity.X = -1;
            damping = 0.1f;
        }

    }
}
