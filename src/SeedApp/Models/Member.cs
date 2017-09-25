namespace SeedApp.Models
{
    using System;

    public class Member
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SourceId { get; set; }
        public Guid SourceRowId { get; set; }
        public Guid BatchId { get; set; }
    }
}