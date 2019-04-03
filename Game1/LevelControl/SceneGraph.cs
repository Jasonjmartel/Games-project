using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class SceneGraph : iSceneGraph
    {
        #region datamembers
        // list of entities making up the current scene
        private IList<iEntity> mScenes;
        #endregion

        public SceneGraph()
        {
            //initialise list
            mScenes = new List<iEntity>();
        }

        #region methods
        public void addobject(iEntity pIEntity)
        {
            // If entity is not on scene then
            if (!mScenes.Contains(pIEntity))
            {   //add it to the scene
                mScenes.Add(pIEntity);
            }
        }

        public void removeobject(iEntity pIEntity) {
            // Remove Entity from scene
            if (mScenes.Contains(pIEntity))
            {   //add it to the scene
                this.mScenes.Remove(pIEntity);
            }
            
        }

        public IList<iEntity> getList() {
            return mScenes;
        }
        #endregion
    }
}
