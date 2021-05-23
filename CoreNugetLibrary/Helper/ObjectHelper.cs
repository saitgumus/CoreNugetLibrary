using System;
using System.Data.Common;
using SG.Kernel.DB;
using SG.Kernel.Response;

namespace SG.Kernel.Helper
{
    public class ObjectHelper : IDisposable
    {
        public ApplicationContext ApplicationContext { get; set; }

        public virtual void Dispose()
        {
        }
    }
}