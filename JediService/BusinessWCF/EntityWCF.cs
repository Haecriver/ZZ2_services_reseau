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
        private int id;

        public EntityObjectWCF(EntityObject entityObject)
        {
            this.id = entityObject.Id;
        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}