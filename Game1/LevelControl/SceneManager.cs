using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class SceneManager : iSceneManager
    {

        #region Data Members

        // Insert Data Members
        public int score;

        // List
        private SceneGraph mSceneGraph;
        
        #endregion

        public SceneManager()
        {
            // Initialize mIEntityList to a List
            mSceneGraph = new SceneGraph();
        }

        #region methods
        public void Spawn(iEntity pIEntity, float xPos, float yPos)
        {
            // Set entity position to = the position passed in
            pIEntity.setPosition(xPos,yPos);
            // add to scene graph
            mSceneGraph.addobject(pIEntity);
        }

        public void Remove(iEntity pIEntity)
        {
            // Remove Entity from scene
            this.mSceneGraph.removeobject(pIEntity);
        }

        public void Draw(SpriteBatch spriteBatch){
            // Add the sprites from the scenegraph to the spritebatch
            foreach (iEntity entity in mSceneGraph.getList())
            {
                entity.Draw(spriteBatch);
            }
        }

        public void Update()
        {
            // Update the entities in the scenegraph
            foreach (iEntity entity in mSceneGraph.getList())
            {
                entity.Update();
            }
        }

        // place the turret in the target location (or move it there as the case may be)
        public void placeturret(int pcount, Vector2 pos) {
            IList<iEntity> templist = mSceneGraph.getList();
            templist[0].setPosition(pos.X, pos.Y);
        }
        #endregion
    }
}
