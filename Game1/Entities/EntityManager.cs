using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    public class EntityManager : iEntityManager
    {
        private int count = 0;

        // CreateInstance of iEntity form as a new iEntity and generate UID
        public T CreateInstance<T>() where T : iEntity, new()
        {
            count++;

            T mIRequestedEntity = new T();
            mIRequestedEntity.generateUID();
            mIRequestedEntity.generateUName(count);

            // Return mIRequestedEntity
            return mIRequestedEntity;
        }
    }
}
