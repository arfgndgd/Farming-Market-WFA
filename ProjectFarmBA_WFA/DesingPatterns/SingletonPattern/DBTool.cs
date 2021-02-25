using ProjectFarmBA_WFA.ModelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFarmBA_WFA.DesingPatterns.SingletonPattern
{
    public class DBTool
    {

        DBTool() { }

        static ProjectFarmBAEntities _dbInstance;

        public static ProjectFarmBAEntities DBInstance
        {
            get
            {
                if (_dbInstance == null)
                {
                    _dbInstance = new ProjectFarmBAEntities();
                }
                return _dbInstance;
            }
        }


    }
}
