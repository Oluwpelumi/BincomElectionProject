using System.ComponentModel.DataAnnotations.Schema;

namespace BincomElectionProject.Models.Entities
{
    public class Lga
    {
        [Column("uniqueid")]
        public int UniqueId { get; set; } // Maps to `uniqueid` (Primary Key)

        [Column("lga_id")]
        public int LgaId { get; set; } // Maps to `lga_id`

        [Column("lga_name")]
        public string LgaName { get; set; } // Maps to `lga_name`

        [Column("state_id")]
        public int StateId { get; set; } // Maps to `state_id`

        [Column("lga_description")]
        public string? LgaDescription { get; set; } // Maps to `lga_description` (nullable)

        [Column("entered_by_user")]
        public string EnteredByUser { get; set; } // Maps to `entered_by_user`

        [Column("date_entered")]
        public DateTime? DateEntered { get; set; } // Maps to `date_entered`

        [Column("user_ip_address")]
        public string UserIpAddress { get; set; } // Maps to `user_ip_address`
    }
}
