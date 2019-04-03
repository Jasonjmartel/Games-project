using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Game1.Behaviours;

namespace Game1
{
    public interface iCollide: iEntity
    {
        // Various values for calculating if a collision is occuring, or about to
        float collisionrange { get; set; }
        Rectangle HitBox { get; }
        Vector2 Velocity { get; set; }
        float[] Corners { get; }
        // Entities mass
        float Mass { get; set; }
        // Fixed object boolean
        bool mFixed { get; set; }

        #region methods
        void collide(iCollide pcollider);
        void impact(Vector2 direction);
        void bounce(int pass);
        void bounce(Vector2 pass);
        #endregion
    }
}
