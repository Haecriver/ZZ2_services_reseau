using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public abstract class EntityObject
    {
        private int id;
        public int Id
        {
            get { return id; }
        }

        public EntityObject(int _id)
        {
            id = _id;
        }
        public bool Equals(EntityObject b)
        {
            throw new NotImplementedException();
        }
        public int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
