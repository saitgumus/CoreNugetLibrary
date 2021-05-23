using System;
using SG.Kernel.Types.Abstract;

namespace SG.Kernel.Types
{
    public class OperationClaim : IEntity
    {
        public int OperationClaimId { get; set; }
        public string Name { get; set; }
    }
}
