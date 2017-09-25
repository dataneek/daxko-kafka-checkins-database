namespace SeedApp.Models
{
    using System;

    public class LocationCheckin
    {
        public int LocationCheckinId { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public DateTime CheckinCompleted { get; set; }
        public int SourceId { get; set; }
        public Guid SourceRowId { get; set; }
        public Guid BatchId { get; set; }
    }
}