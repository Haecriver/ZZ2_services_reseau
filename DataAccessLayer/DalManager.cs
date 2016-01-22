using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntitiesLayer;

namespace DataAccessLayer
{
    public enum _typeBDD {
        SQL,
        ORACLE
    }
    public class DalManager
    {
        private static DalManager instance;
        private static readonly object padlock = new object();

        _typeBDD typeBDD;

        private IDAL usingDal;

        private DalManager()
        {
            typeBDD = _typeBDD.SQL;
            if(typeBDD==_typeBDD.SQL){
                usingDal = new DALSqlServer();
            }
        }

        public static DalManager Instance{
            get{
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            return new DalManager();
                        }
                    }
                }
                return instance;
            }
        }

        public IDAL UsingDal
        {
            get { return usingDal; }
        }

    }
}
