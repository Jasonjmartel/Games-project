using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public interface iSceneManager : iManager
    {
        /// <summary>
        /// Spawns Entity in its dessired position.
        /// </summary>
        /// <param name="pIEntity">iEntity</param>
        /// <param name="pPosition">Vector 2 Position to place object</param>
        void Spawn(iEntity pIEntity, float xPos, float yPos);

        /// <summary>
        /// Removes iEntity from scene
        /// </summary>
        /// <param name="pIEntity">iEntity</param>
        void Remove(iEntity pIEntity);

        /// <summary>
        /// Draw the entities in the scenemanager to the spritebatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        void Draw(SpriteBatch spriteBatch);
    }
}
