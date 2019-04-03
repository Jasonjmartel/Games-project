using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Game1.Collision;

namespace Game1
{
    public class CollisionManager
    {
        #region datamembers
        // list for moving entities
        private IList<iCollide> mMobile;

        // list for immovable regions
        private IList<Imobox> mTerrain;

        // physics calculator
        private PhysicsCalc mCalc;
        #endregion


        public CollisionManager()
        {
            // initialise lists
            mMobile = new List<iCollide>();
            mCalc = new PhysicsCalc();
            mTerrain = new List<Imobox>();

            #region testing stuff
            //Imobox testing = new Imobox(700, 800, 0, 100);
            //addbox(testing);
            #endregion
        }

        #region methods
        // add a moving element
        public void addmobile(iCollide piCollide)
        {
            // If entity is not part of mobile object list
            if (!mMobile.Contains(piCollide))
            {   //Add it to the list
                mMobile.Add(piCollide);
            }
        }

        // remove a moving element
        public void removemobile(iCollide piCollide)
        {
            // Remove Entity from list
            this.mMobile.Remove(piCollide);
        }

        // add a fixed region
        public void addbox(Imobox par)
        {
            // If entity is not part of list already
            if (!mTerrain.Contains(par))
            {   //Add it to the list
                mTerrain.Add(par);
            }
        }

        // remove a fixed region
        public void removebox(Imobox par)
        {
            // Remove Entity from list
            this.mTerrain.Remove(par);
        }

        #region collision methods
        //There are several potential methods for doing collision detection that could be used with the current iCollide interface

        // It has a rectangle hitbox (which is currently being used), it has a float for collision radius (allowing you to draw a sphere
        // around the object, or a wide radius around the object seperate from the actual hitbox), it has velocity and position (to predict
        // if there will be a collision before it happens, and stop it cutting through walls if it's going to fast)

        public void colcheck1()
        {   // tier 1 collision checks (general making sure not to waste time)

            // If there's only one moving object, then there's no need for collision of moving objects either
            if (mMobile.Count > 1)
            {                                   // check all moving objects against all other moving objects
                for (int i = 0; i < mMobile.Count; i++)
                {
                    for (int j = 0; j < mMobile.Count; j++)
                    {
                        if (i != j)             // make sure not to compare against yourself
                        {                                       
                            colcheck2(mMobile[i], mMobile[j]);      // transition to second phase collision check
                        }
                    }
                }
            }
        }        

        // first 'true' collision check method uses the bounding circle (objects hold a property on size of that circle to check). Helps cut down on more complex collision methods required
        public void colcheck2(iCollide p1, iCollide p2)
        {
            // temporary floats are used to get the current distances between the objects on the x+y axes.
            float temp1 = p1.Position.X - p2.Position.X;
            float temp2 = p1.Position.Y - p2.Position.Y;
            // then get the actual distance by using square/root rules to get the true distance from x and y distance
            temp1 = temp1 * temp1;
            temp2 = temp2 * temp2;
            temp1 = temp1 + temp2;
            double temp3 = Math.Sqrt(temp1);
            // get the two different collision ranges and add them together
            temp2 = p1.collisionrange + p2.collisionrange;
            // if the 2 objects are closer than their combined collision ranges, then run their collide methods (without this being true, they CANNOT collide, so more methods aren't needed)
            if (temp2 > temp3)
            {       // go to the next method
                colcheck3(p1, p2);
            }
        }

        // last 'true' collision currently implemented. Uses the rectangle.intersects method to determine a boolean result
        public void colcheck3(iCollide p1, iCollide p2)
        {           
            if (p1.HitBox.Intersects(p2.HitBox))
            {       // if the objects hitboxes overlap, then run the collide methods
                p1.collide(p2);
                p2.collide(p1);
                    // and then get the physics calculator to calculate the results, and affect the entities physical properties
                mCalc.getforce(p1, p2);                
            }
        }
        #endregion

        //this method is the 'outer boundary' method. Simple as it generally calls the more complex methods. Hardcoded as a box you can't leave (unless things are entirely broken) so there can 
        // only be one (although the values of where it is can be changed)
        public void boundcheck()
        {
            // If there's no moving object, then it would break
            if (mMobile.Count > 0)
            {
                for (int i = 0; i < mMobile.Count; i++)
                {
                    checkvertical(mMobile[i]);
                    checkhorizontal(mMobile[i]);
                }
            }
        }


        // This method influences the vertical boundaries (top/bottom of the screen).
        public void checkvertical(iCollide p1)
        {
            #region defunct
            /*if (p1.HitBox.Bottom < 800)
            {
                if (p1.HitBox.Bottom + p1.Velocity.Y > 800)
                {
                    p1.bounce(1);
                }
            }
            else if (p1.HitBox.Top > 0)
            {
                if (p1.HitBox.Top + p1.Velocity.Y < 0)
                {
                    p1.bounce(1);
                }
            }            
            else*/
            #endregion

            // if you are below the bottom boundary, and still moving down then run the bounce method
            if (p1.HitBox.Bottom > 830 && p1.Velocity.Y > 0)
            {
                p1.bounce(1);
            }   // ditto for the top boundary (and moving up)
            else if (p1.HitBox.Top < 0 && p1.Velocity.Y < 0)
            {
                p1.bounce(1);
            }
        }
        public void checkhorizontal(iCollide p1)
        {
            #region defunct
            /*if (p1.HitBox.Left > 0)
            {
                if (p1.HitBox.Left + p1.Velocity.X < 0)
                {
                    p1.bounce(0);
                }
            }
            else if (p1.HitBox.Right < 800)
            {
                if (p1.HitBox.Right + p1.Velocity.X > 800)
                {
                    p1.bounce(0);
                }
            }
            else*/
#endregion

            // if you are too far to the left, and are moving that way then bounce back
            if (p1.HitBox.Right > 800 && p1.Velocity.X > 0)
            {
                p1.bounce(0);
            }   //ditto for the right hand side (and moving right)
            else if (p1.HitBox.Left < 25 && p1.Velocity.X < 0)
            {
                p1.bounce(0);
            }

        }


        #region under construction (immovable objects)

        // check boxes method should run through checks against the hardcoded objects (platforms, etc)
        // still under construction (physics sometimes kicks the object out from the wrong side of the object)
        public void checkboxes()
        {       // same check to make sure there's a need to run this code (whether there are things to check against)
            if (mMobile.Count >= 1 && mTerrain.Count >= 1)
            {
                for (int i = 0; i < mMobile.Count; i++)
                {
                    for (int j = 0; j < mTerrain.Count; j++)
                    {                        //check that they intersect (could have just used the rectangles,intersect, so could be streamlined since it works the same way)
                        if (mMobile[i].HitBox.Bottom > mTerrain[j].top() && mMobile[i].HitBox.Top < mTerrain[j].bottom())
                        {
                            if (mMobile[i].HitBox.Right > mTerrain[j].left() && mMobile[i].HitBox.Left < mTerrain[j].right())
                            {
                                //this region focuses on trying to work out the direction that the object entered/needs to leave from/in.
                                #region checkbouncedirection
                                // get the immovable object as a rectangle
                                Rectangle check = new Rectangle(mTerrain[j].left(), mTerrain[j].top(), (mTerrain[j].right() - mTerrain[j].left()), (mTerrain[j].bottom() - mTerrain[j].top()));
                                // get a rectangle that is made up of the combined intersection

                                // in theory this section first calculates the amount that the object penetrated into the immovable object, and uses the current velocity to calculate which side it hit
                                // first (in case it hit a corner). The calculations aren't working correctly so far though, as sometimes moving into the side while moving more up/down than side to side
                                // will lead to getting kicked in the wrong direction (still needs more verification/testing).

                                //get the intersection rectangle
                                check = Rectangle.Intersect(check, mMobile[i].HitBox);
                                // generate some temporary storage variables
                                float xmove, ymove, xres, yres, xfin, yfin;
                                // get the portion of the current velocity that is proportionally on the x axes
                                xmove = mMobile[i].Velocity.X / (mMobile[i].Velocity.X + mMobile[i].Velocity.Y);
                                // same for the y axes
                                ymove = mMobile[i].Velocity.Y / (mMobile[i].Velocity.X + mMobile[i].Velocity.Y);
                                // similar as above for the proportion of each level of penetration into the object for the x/y axes
                                xres = (float)(check.Width);
                                xres = xres / (float)(check.Width + check.Height);
                                yres = (float)(check.Width);
                                yres = yres / (float)(check.Width + check.Height);
                                // then get proportional comparison
                                xfin = xres / xmove;
                                yfin = yres / ymove;
                                // removed at the moment, but was meant to be trying to deal with the 'bouncing up and down into the side of a box' issue
                                //if (check.Width > xmove) xfin = xmove;
                                //if (check.Height > ymove) yfin = ymove;

                                //in theory all of this would let you determine which direction it would need to be ejected from, but as mentioned, bouncing into the side while having significantly more
                                // y axis speed will cause you to get bumped to the bottom (presumably the same for if trying to do the same on the other axes, at a level of trying to skip stones, etc
                                #endregion
                                #region bounce
                                // this region then finalises it, ejects the entity, and then changes the velocity
                                if (xfin > yfin)
                                {       // this set of if statements determines the correct directions/magnitudes of forces involved
                                    if (mMobile[i].Velocity.X > 0)
                                    {
                                        mMobile[i].setPosition(check.Left - 0.2f, mMobile[i].Position.Y);
                                        mMobile[i].bounce(1);
                                    }
                                    else
                                    {
                                        mMobile[i].setPosition(check.Right + 0.2f, mMobile[i].Position.Y);
                                        mMobile[i].bounce(1);
                                    }
                                }
                                else
                                {
                                    if (mMobile[i].Velocity.Y > 0)
                                    {
                                        mMobile[i].setPosition(mMobile[i].Position.X, check.Top - 0.2f);
                                        mMobile[i].bounce(0);
                                    }
                                    else
                                    {
                                        mMobile[i].setPosition(mMobile[i].Position.X, check.Bottom + 0.2f);
                                        mMobile[i].bounce(0);
                                    }
                                }
                                #endregion

                                // overall, the main issue with this method is that when it kicks out, it can kick them into an immediate collision with another object, which can lead to a collision
                                // chain that leads to breaking everything. This still needs to be fixed before the immovable objects can be added.
                                // 'Psuedo' immovable objects are semi possible with specific coding, but isn't the most practical atm
                            }
                        }
                        
                    }
                }
                #endregion


                #endregion
            }
        }
    }
}