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
            set { id = value; }
        }

        public EntityObject()
        {

        }
        public EntityObject(int _id)
        {
            id = _id;
        }
        public bool Equals(EntityObject b)
        {
            // TODO : Pas sur ...
            return Id == b.Id;
        }
        public override int GetHashCode()
        {
            // TODO : Pas sur ...
            return Id.GetHashCode();
        }
    }
}
