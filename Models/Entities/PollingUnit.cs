using System.ComponentModel.DataAnnotations.Schema;

namespace BincomElectionProject.Models.Entities
{
    public class PollingUnit
    {
        [Column("uniqueid")]
        public int UniqueId { get; set; } // Maps to `uniqueid` (Primary Key)

        [Column("polling_unit_id")]
        public int PollingUnitId { get; set; } // Maps to `polling_unit_id`

        [Column("ward_id")]
        public int WardId { get; set; } // Maps to `ward_id`

        [Column("lga_id")]
        public int LgaId { get; set; } // Maps to `lga_id`

        [Column("uniquewardid")]
        public int? UniqueWardId { get; set; } // Maps to `uniquewardid` (nullable)

        [Column("polling_unit_number")]
        public string PollingUnitNumber { get; set; } // Maps to `polling_unit_number`

        [Column("polling_unit_name")]
        public string PollingUnitName { get; set; } // Maps to `polling_unit_name`

        [Column("polling_unit_description")]
        public string? PollingUnitDescription { get; set; } // Maps to `polling_unit_description` (nullable)

        [Column("lat")]
        public string? Latitude { get; set; } // Maps to `lat` (nullable)

        [Column("long")]
        public string? Longitude { get; set; } // Maps to `long` (nullable)

        [Column("entered_by_user")]
        public string? EnteredByUser { get; set; } // Maps to `entered_by_user` (nullable)

        [Column("date_entered")]
        public DateTime? DateEntered { get; set; } // Maps to `date_entered` (nullable)

        [Column("user_ip_address")]
        public string? UserIpAddress { get; set; } // Maps to `user_ip_address` (nullable)
    }
}
