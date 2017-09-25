namespace SeedApp.Models
{
    using System;

    public class Location
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int SourceId { get; set; }
        public Guid SourceRowId { get; set; }
        public Guid BatchId { get; set; }
    }
}