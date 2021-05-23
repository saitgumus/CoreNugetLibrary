using System;
using SG.Kernel.DB;

namespace SG.Kernel
{
    public class Request
    {
        public decimal BusinessKey { get; set; }
        public string UserName { get; set; }
        
    }

    public class TransactionalRequest : Request
    {

    }

}
