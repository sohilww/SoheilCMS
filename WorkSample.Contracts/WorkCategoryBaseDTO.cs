using System.Collections.Generic;
using WorkSamples.DomainModel;

namespace WorkSample.Contracts
{
    public class WorkCategoryBaseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }
        public IEnumerable<SampleWork> Samples { get; set; }
    }
}