using Game1.Entities;
using Game1.Physics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.Behaviours
{
    public class PhysicsBehaviour:iBehaviour
    {
        #region datamembers
        // Body associated with the behaviour
        protected PhysicsEntity mBody;
        //get/set for body
        public iEntity Body
        {
            get { return mBody; }
        }

        public PhysicsBehaviour(PhysicsEntity body)
        {
            //get the body
            mBody = body;
        }
        #endregion

        #region methods
        // Update, 
        public void update()
        {
            //calls the move method from Physentity, which will alter the current location based on current velocity
            mBody.move();
            //gravity pulls you down. The if statement works with the way objects lieing on top of each other interact (to prevent them being forced into each other)
            if (mBody.HitBox.Bottom < 823)
            {
                mBody.Velocity = new Vector2(mBody.Velocity.X, (mBody.Velocity.Y + mBody.gravity));
            }
        }
        
        // Collision has been detected        
        public void collide(iCollide pcollider)
        {
            //Nothing in here, as it's a abstract class (specific game features could have this built in, for stuff like health loss, etc)
        }

        // Method for resolving physics aspects of a collision with another physics object, passed in as a vector from the PhysicsCalculator
        public void impact(Vector2 direction)
        {
            // have a version of the parameter that can be altered (legacy, but was left in due to code still using it instead of the parameter)
            Vector2 temp = direction;

            // this is currently a stopgap, and will be changed later
            // it currently reverts the object to it's previous location, which will allow it to avoid merging with other objects
            // an alternative is partially implemented, but isn't finished yet (calculated in the physCalc, it tries to move the object the minimum distance to seperate them)
            // didn't have enough time to implement it properly however, due to the timing issues due to the team issues, so I used this version due to it functioning okay, while the 'true' method
            // breaks a lot of the time due to still not having been fully tested yet
            mBody.setPosition(mBody.Position.X - 2 * mBody.Velocity.X, Body.Position.Y - 2 * mBody.Velocity.Y);

            //Legacy if statement from previous implementation, for resolving collisions on one axis only without needing more lines of code
            #region legacy
            /*
            // first two if statements are simplifications
            if (direction.X == 0 && mBody.Velocity.X != 0)
            { // if the resulting 
                mBody.Velocity = new Vector2(0,mBody.Velocity.Y);
            }
            else if (direction.Y == 0 && mBody.Velocity.Y != 0)
            {
                mBody.Velocity = new Vector2(mBody.Velocity.X,0);
            }
            else
            {*/
            #endregion

            // use the accelerate method (changes current velocity based on the parameter velocity) to nullify current Velocity (thus cancelling current movement)
            mBody.accelerate(-mBody.Velocity);
            // then accelerate based on the new velocity, thus changing the direction/magnitude of movement
            mBody.accelerate(temp * (1 - mBody.damp));
        }

        // Method called when colliding with an immovable object, instead of another moving object
        public void bounce(int pass)
        {                   // the parameter allows storage of if the collision is on x or y axis. Other numbers could potentially be used for more esoteric angles once non right angle
                            // planes are implemented (which hasn't been yet)
            if (pass == 0)
            {               //get the current velocity
                Vector2 temp = mBody.Velocity;
                            //get twice the negative x velocity
                temp.X = temp.X * -2;
                            // set y to 0 (as there should be no change in y axis movement when you reflect on x)
                temp.Y = 0;
                            // similarly to impact calc, this makes sure you are ejected from the object.
                            // theoretically anyway, at the moment it doesn't actually do that, so will need the 'proper' implementation to eject it properly
                //mBody.setPosition(mBody.Position.X - 2 * mBody.Velocity.X, Body.Position.Y - 2 * mBody.Velocity.Y);

                // use the temp Vector to change the velocity. There should be no change on the y axis, while the x axis movement should be reversed completely
                mBody.accelerate(temp);
            }
            else if (pass == 1)
            {               //get the current velocity
                Vector2 temp = mBody.Velocity;
                            //get twice the negative y velocity
                temp.Y = temp.Y * -2;
                            // set x to 0 (as there should be no change in y axis movement when you reflect on x)
                temp.X = 0;
                        // similarly to impact calc, this makes sure you are ejected from the object.
                            // theoretically anyway, at the moment it doesn't actually do that, so will need the 'proper' implementation to eject it properly
                //mBody.setPosition(mBody.Position.X - 2 * mBody.Velocity.X, Body.Position.Y - 2 * mBody.Velocity.Y);

                // use the temp Vector to change the velocity. There should be no change on the y axis, while the x axis movement should be reversed completely
                mBody.accelerate(temp * (1 - mBody.damp));
            }

        }

        #endregion
    }
}
