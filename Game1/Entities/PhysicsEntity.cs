using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Physics;
using Game1.Behaviours;

namespace Game1.Entities
{
    public abstract class PhysicsEntity: Entity, iPhysicsEntity
    {
        #region Data Members

        // Insert Data Members

        // Texture2D
        protected Texture2D mTexture2D;

        // Rectangle
        protected Rectangle mRectangle;

        // Entities collisoin range
        protected float mcoll;

        // Defunct boolean (meant for allowing a fixed physics object, which has been removed)
        protected bool Fixed;

        // Level of damping/elasticity
        protected float damping;

        // Gravity on the object (allows for unique levels, for floating, etc)
        protected float grav;

        // physics mind
        protected PhysicsBehaviour PhysMind;



        // HitBox getter return new rectangle
        public Rectangle HitBox
        {
            get
            {
                return mRectangle = new Rectangle((int)Position.X,
              (int)Position.Y, Texture.Width, Texture.Height);
            }
        }

        public float gravity
        {
            get
            {
                return grav;
            }
        }

        // HitBox getter return new rectangle
        public float[] Corners
        {
            get
            {
                return Corners;
            }
        }
        public float damp
        {
            get
            {
                return damping;
            }
            set { damping = value; }
        }

        // Insert collision range
        public float collisionrange
        {
            get { return mcoll; }
            set { mcoll = value; }
        }

        // Insert fixed y/n (defunct)
        public bool mFixed
        {
            get { return Fixed; }
            set { Fixed = value; }
        }
        #endregion

        #region Methods             


        //call the behaviour method of collide
        public virtual void collide(iCollide pcollider)
        {
            // Call behaviours collide method, provided there is a specific mind (should be implemented in specific mind, instead of physics mind)
            if (mBehaviour != null)
            {
                mBehaviour.collide(pcollider);
            }
        }

        //call the behaviour method of impact
        public void impact(Vector2 direction)
        {
            PhysMind.impact(direction);                       
        }
        
        //call the behaviour method of bounce
        public virtual void bounce(int pass)
        {
            PhysMind.bounce(pass);
        }

        // no longer used method
        public virtual void bounce(Vector2 pass)
        {

        }

        public virtual void accelerate(Vector2 Acceleration)
        {
            mVelocity = mVelocity + Acceleration;
        }
        public virtual void move()
        {
            setPosition((mPosition.X + mVelocity.X), (mPosition.Y + mVelocity.Y));
        }

        public override void Update()
        {
            // update the unique behaviours if there's a mind attached
            if (mBehaviour != null)
            {
                mBehaviour.update();
            }
            
            // This is a specific physics entity class, which would always be linked to a physics mind, so it creates on if there isn't already one
            if (PhysMind == null)
            {
                PhysMind = new PhysicsBehaviour(this);
            }
            // update the physics
            PhysMind.update();                                    
            
        }

        #endregion
    }
}
