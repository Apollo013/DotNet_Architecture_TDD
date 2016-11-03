using System.Collections.Generic;

namespace Application.NUnit.Domain.Partitioning
{
    public class Partition
    {
        public object Size { get; set; }
        public IList<IList<Share>> PartitioningResult;
    }
}