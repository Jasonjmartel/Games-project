using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Behaviours;

namespace Game1.Entities
{
    class BasicBlock : PhysicsEntity, iCollide
    {
        // Constructor
        public BasicBlock()
        {
            // set initial values
            setPosition(mPosition.X, mPosition.Y);
            mcoll = 36;
            mSpeed = 0;
            grav = 0;
            Fixed = false;
            mMass = 100;
            mVelocity.X = -0.5F;
            grav = 0.05f;
            damping = 0.1f;
        }

        #region methods
        // No methods since it's all in the Physics Entity abstract class, as this is a test object and has nothing of it's own

        #endregion
    }
}