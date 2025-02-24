using System;
using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace TutormatchWeb.Models
{
    [Table("Dispute")]  // Use Supabase Table attribute
    public class Dispute : BaseModel
    {
        [PrimaryKey]
        [Column("id")]  // Use Supabase Column attribute
        public Guid id { get; set; }

        [Column("booking_id")]
        public Guid BookingId { get; set; }

        [Column("issue_type")]
        public string IssueType { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by_role")]
        public string CreatedByRole { get; set; }

        [Column("resolution_notes")]
        public string ResolutionNotes { get; set; }

        [Column("resolved_at")]
        public DateTime? ResolvedAt { get; set; }

        [Column("resolved_by")]
        public Guid? ResolvedBy { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }
    }
}
