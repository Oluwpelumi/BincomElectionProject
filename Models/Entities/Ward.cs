using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BincomElectionProject.Models.Entities
{
    public class Ward
    {
        [Key]
        [Column("uniqueid")]
        public int UniqueId { get; set; } // Maps to `uniqueid` (Primary Key)

        [Column("ward_id")]
        public int WardId { get; set; } // Maps to `ward_id`

        [Column("lga_id")]
        public int LgaId { get; set; } // Maps to `lga_id`

        [Column("ward_name")]
        [Required]
        [MaxLength(50)]
        public string WardName { get; set; } // Maps to `ward_name`

        [Column("ward_description")]
        public string? WardDescription { get; set; } // Maps to `ward_description` (nullable)

        [Column("entered_by_user")]
        [Required]
        [MaxLength(50)]
        public string EnteredByUser { get; set; } // Maps to `entered_by_user`

        [Column("date_entered")]
        public DateTime DateEntered { get; set; } // Maps to `date_entered`

        [Column("user_ip_address")]
        [MaxLength(50)]
        public string UserIpAddress { get; set; } // Maps to `user_ip_address`

    }
}
