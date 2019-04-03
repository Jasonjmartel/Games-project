using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public interface iEntity
    {
        #region datamembers
        // Unique ID
        Guid UID { get; set; }
        // Unique Name
        String uName { get; set; }
        // Current position
        Vector2 Position { get; set; }
        // Texture of entity
        Texture2D Texture { get; set; }
        // associated behaviour
        iBehaviour Behaviour { get; set; }
        #endregion

        #region methods
        //set the entities position
        void setPosition(float xPos, float yPos);
        // generate it's unique ID
        void generateUID();
        // generate it's unique name
        void generateUName(int pCount);
        // Draw on canvas
        void Draw(SpriteBatch spritebatch);
        //update
        void Update();
        #endregion
    }
}
