using System;
using SG.Kernel.Helper;

namespace APMAN.Core.DB
{
    public abstract class ManagerBase
    {
        public ManagerBase(ApplicationContext context)
        {
            this.applicationContext = context;
        }
        protected ApplicationContext applicationContext;
    }
}
