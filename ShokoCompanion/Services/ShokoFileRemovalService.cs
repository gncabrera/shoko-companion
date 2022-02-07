using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShokoCompanion.Services
{
    internal class ShokoFileRemovalService
    {
        private static ShokoFileRemovalService instance = null;
        private static readonly object padlock = new object();

        public static int USER_ID { get { return 1; } }

        ShokoFileRemovalService()
        {
        }

        public static ShokoFileRemovalService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ShokoFileRemovalService();
                    }
                    return instance;
                }
            }
        }
    }
}
