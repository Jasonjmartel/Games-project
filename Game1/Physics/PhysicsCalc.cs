using Game1.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    class PhysicsCalc
    {                                   // This class exists purely to hold methods for calculating physics interaction
        public PhysicsCalc()
        {
        }

        // The (presently only) method is for calculating forces between two moving objects colliding in space. Other methods have been either taken out or folded elsewhere for now (such as calculating
        // the point of impact, that is partially being used in impact with static objects, etc). For now this is the only thing in here
        public void getforce(iCollide p1, iCollide p2)
        {
            #region defunct code (kept for reference)
            // The first initial try at the code, which ended up more for 1d collisions rather than 2d

            //float initforce1, initforce2, combforce = new float();
            /*
            #region initial force calc
            float temp1 = p1.Velocity.X;
            float temp2 = p1.Velocity.Y;
            temp1 = temp1 * temp1;
            temp2 = temp2 * temp2;
            temp1 = temp1 + temp2;
            double temp3 = Math.Sqrt(temp1);
            initforce1 = (float)temp3;
            initforce1 = initforce1 * p1.Mass;

            temp1 = p2.Velocity.X;
            temp2 = p2.Velocity.Y;
            temp1 = temp1 * temp1;
            temp2 = temp2 * temp2;
            temp1 = temp1 + temp2;
            temp3 = Math.Sqrt(temp1);
            initforce2 = (float)temp3;
            initforce2 = initforce2 * p2.Mass;
            #endregion

            #region normalised vector calc
            Vector2 tempVect = p1.Velocity + p2.Velocity;
            tempVect.Normalize();
            #endregion

            combforce = initforce1 + initforce2;*/
            #endregion

            //two temporary vectors (for storing resultant forces later)
            Vector2 res1 = new Vector2();
            Vector2 res2 = new Vector2();

            #region defunct code (kept for reference)
            // calculate the magnitudes of the forces (defunct not too)
            //float dot1 = (p1.Velocity.X * p2.Velocity.X) + (p1.Velocity.Y * p2.Velocity.Y);
            //float dot2 = (p1.Position.X * p2.Position.X) + (p1.Position.Y * p2.Position.Y);
            #endregion

            //calculate the resultant forces on each object after the collision
            res1 = (p1.Velocity*(p1.Mass-p2.Mass)+(2*p2.Mass*p2.Velocity)/(p1.Mass+p2.Mass));
            res2 = (p2.Velocity * (p2.Mass - p1.Mass) + (2 * p1.Mass * p1.Velocity) / (p1.Mass + p2.Mass));

            #region non functional code - Safely seperate two objects
            // This section of code was meant to be calculating the minimum distance objects would need to move to seperate from each other
            // Right now it's still partially broken however, and considering the (lack of) team based issues there likely won't be time to finish it now


            /*Rectangle check = new Rectangle();
            check = Rectangle.Intersect(p1.HitBox, p2.HitBox);

            float p1xlev = p1.Velocity.X / (p1.Velocity.X + p2.Velocity.X);
            float p1ylev = p1.Velocity.X / (p1.Velocity.X + p2.Velocity.X);
            float p2xlev = p2.Velocity.X / (p1.Velocity.X + p2.Velocity.X);
            float p2ylev = p2.Velocity.X / (p1.Velocity.X + p2.Velocity.X);

            float temp1, temp2;

            if (p1.Velocity.X > 0)
            {
                temp1 = 1;
            }
            else
            {
                temp1 = -1;
            }
            if (p1.Velocity.X > 0)
            {
                temp2 = 1;
            }
            else
            {
                temp2 = -1;
            }
            Vector2 tempvect = new Vector2(p1xlev * temp1, p1ylev * temp2);
            tempvect = p1.Position + tempvect;
            p1.setPosition(tempvect.X, tempvect.Y);

            if (p2.Velocity.X > 0)
            {
                temp1 = 1;
            }
            else
            {
                temp1 = -1;
            }
            if (p2.Velocity.X > 0)
            {
                temp2 = 1;
            }
            else
            {
                temp2 = -1;
            }
            tempvect = new Vector2(p2xlev * temp1, p2ylev * temp2);
            tempvect = p2.Position + tempvect;
            p2.setPosition(tempvect.X, tempvect.Y);*/
            #endregion

            // run the impact methods, passing each entity their resulting forces
            p1.impact(res1);
            p2.impact(res2);                       
        }
    }
}
