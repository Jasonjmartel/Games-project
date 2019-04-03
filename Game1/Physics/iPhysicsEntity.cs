using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.Physics
{
    public interface iPhysicsEntity : iEntity, iCollide
    {
        // Various values for calculating physics interactions        
        // Legacy (until velocities are normalised)(nothing uses speed anymore, remove when there's time)
        int Speed { get; set; }
        float damp { get; set; }

        #region methods
        void accelerate(Vector2 acceleration);
        void move();
        #endregion
    }
}
