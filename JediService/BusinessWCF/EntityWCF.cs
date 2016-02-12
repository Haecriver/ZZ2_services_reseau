using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EntitiesLayer;
using System.Runtime.Serialization;

namespace JediService.BusinessWCF
{
    [DataContract]
    public class EntityObjectWCF
    {
        private EntityObject entityObject;

        public EntityObjectWCF(EntityObject entityObject)
        {
            this.entityObject = entityObject;
        }

        [DataMember]
        public int Id
        {
            get { return entityObject.Id; }
            set { entityObject.Id = value; }
        }

    }
}