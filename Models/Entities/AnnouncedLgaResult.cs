using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BincomElectionProject.Models.Entities
{
    public class AnnouncedLgaResult
    {
        [Key]
        [Column("result_id")]
        public int ResultId { get; set; } // Maps to `result_id` (Primary Key)

        [Column("lga_name")]
        [Required]
        [MaxLength(50)] // Maps to `lga_name` with a maximum length of 50 characters
        public string LgaName { get; set; } // Maps to `lga_name`

        [Column("party_abbreviation")]
        [Required]
        [MaxLength(4)] // Since the column is char(4) in the database
        public string PartyAbbreviation { get; set; } // Maps to `party_abbreviation`

        [Column("party_score")]
        [Required]
        public int PartyScore { get; set; } // Maps to `party_score`

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
