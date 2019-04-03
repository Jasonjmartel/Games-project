using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public interface iSceneGraph
    {
        #region methods
        void addobject(iEntity pIEntity);
        void removeobject(iEntity pIEntity);
        IList<iEntity> getList();
        #endregion
    }
}
