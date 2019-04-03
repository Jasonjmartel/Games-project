using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public abstract class Entity : iEntity
    {
        #region Data Members

        //Insert Data Members
        
        //GUID
        protected Guid mUid;

        // Associated behaviour
        protected iBehaviour mBehaviour;

        // UName
        protected String mUName;
        
        //Associated texture
        protected Texture2D mTexture;

        // Vectors
        protected Vector2 mVelocity;
        protected Vector2 mPosition;

        // Current speed
        protected int mSpeed;

        // Current mass
        protected float mMass;

        #endregion

        #region Properties
        // Texture getter and setter
        public Texture2D Texture
        {
            get { return mTexture; }
            set { mTexture = value; }
        }

        // Generate unique ID
        public Guid UID
        {
            get { return mUid; }
            set { mUid = value; }
        }

        // Generate unique Name
        public string uName
        {
            get { return mUName; }
            set { mUName = value; }
        }

        // Position getter and setter
        public Vector2 Position
        {
            get { return mPosition; }
            set { mPosition = value; }
        }

        // Position getter and setter
        public iBehaviour Behaviour
        {
            get { return mBehaviour; }
            set { mBehaviour = value; }
        }

        // Speed getter and setter
        public int Speed
        {
            get { return mSpeed; }
            set { mSpeed = value; }
        }

        // Velocity getter and setter
        public Vector2 Velocity
        {
            get { return mVelocity; }
            set { mVelocity = value; }
        }

        // Entities mass
        public float Mass
        {
            get { return mMass; }
            set { mMass = value; }
        }
        #endregion

        #region Methods
        // Draw the entity to the current spritebatch (so it shows up on screen)
        public void Draw(SpriteBatch spritebatch) {
            Vector2 tempvect = new Vector2(Texture.Height / 2, Texture.Width / 2);
            tempvect = Position - tempvect;
            spritebatch.Draw(Texture, tempvect, Color.AntiqueWhite);
        }

        // Generate GUID
        public void generateUID()
        {
            UID = Guid.NewGuid();
        }

        // Generate UName
        public void generateUName(int pCount)
        {
            mUName = ToString() + pCount;
        }

        // Set position in 2d space
        public void setPosition(float xPos, float yPos)
        {
            mPosition.X = xPos;
            mPosition.Y = yPos;
        }

        public virtual void Update()
        {
            // Update
        }

        #endregion
    }
}
