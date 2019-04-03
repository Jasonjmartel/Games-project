using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Game1.Entities;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class TDLevelManager
    {
        #region Data Members

        // Insert Data Members 
        // managers that it needs access to
        private SceneManager mSceneManager;
        private CollisionManager mCollManager;
        private EntityManager mEntityManager;
        private ContentManager mContent;
        private MouseManager mMouseManager;
        // size of the screen for reference (it's set to 1600/900, but that could change easily)
        private int mScreenWidth, mScreenHeight;
        // list of entities in the current level (generally identical to the one in the scenegraph, but not always due to turrets potentially persisting through waves)
        private IList<iEntity> mCurrentLevel;

        #endregion
        public TDLevelManager(SceneManager pScene, CollisionManager pColl, EntityManager pEntity, ContentManager pContent, int pScreenWidth, int pScreenHeight, MouseManager pMouse) {
            // instantiate variables
            mSceneManager = pScene;
            mCollManager = pColl;
            mEntityManager = pEntity;
            mContent = pContent;
            mScreenWidth = pScreenWidth;
            mScreenHeight = pScreenHeight;
            mMouseManager = pMouse;
            mCurrentLevel = new List<iEntity>();
        }


        #region methods
        public void addlevel1()
        {
            #region create ball+block
            //call entity manager
            BasicBall ball = mEntityManager.CreateInstance<BasicBall>();

            // grant entities their textures 
            ball.Texture = mContent.Load<Texture2D>("Assets/NewBall.png");

            //add to scene manager
            mSceneManager.Spawn(ball, 400, 300);

            /// add to collision manager
            mCollManager.addmobile(ball);

            //add to level
            mCurrentLevel.Add(ball);

            //call entity manager
            ball = mEntityManager.CreateInstance<BasicBall>();

            // grant entities their textures 
            ball.Texture = mContent.Load<Texture2D>("Assets/NewBall.png");

            //add to scene manager
            mSceneManager.Spawn(ball, 300, 300);

            // add to collision manager
            mCollManager.addmobile(ball);

            //add to level
            mCurrentLevel.Add(ball);

            //call entity manager
            BasicBlock block = mEntityManager.CreateInstance<BasicBlock>();

            // grant entities their textures 
            block.Texture = mContent.Load<Texture2D>("Assets/Block.png");

            //add to scene manager
            mSceneManager.Spawn(block, 200, 300);

            // add to collision manager
            mCollManager.addmobile(block);

            mCurrentLevel.Add(block);
            
            //call entity manager
            block = mEntityManager.CreateInstance<BasicBlock>();

            // grant entities their textures 
            block.Texture = mContent.Load<Texture2D>("Assets/Block.png");

            //add to scene manager
            mSceneManager.Spawn(block, 500, 300);

            // add to collision manager
            mCollManager.addmobile(block);

            //add to level
            mCurrentLevel.Add(block);
            #endregion

        }

        // clear the current level
        public void removelevel1() {
            foreach (iEntity entity in mCurrentLevel)
            {   // remove all things from this list from the scenegraph
                mSceneManager.Remove(entity);
            }   // they don't NEED to be removed from collision management, but it would be a good idea to do so
        }       // for now that's missed out though (due to seperation of static/mobile lists making this harder)

        #region example extra methods
        // example methods for later. Unused for now
        public void addlevel2()
        {
        }
        public void removelevel2()
        {
        }
        //more methods later
        #endregion
        #endregion
    }
}
