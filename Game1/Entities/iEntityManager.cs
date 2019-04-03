using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    public interface iEntityManager
    {
        // Doesn't inherit iManager (it's more of a factory than a manager, and actual updating is handled by scene manager)

        /// <summary>
        /// Generic Method which Creates a new Instance of iEntity
        /// </summary>
        /// <typeparam name="T">Generic Type Parameter</typeparam>
        /// <returns></returns>
        T CreateInstance<T>() where T: iEntity, new();
    }
}
