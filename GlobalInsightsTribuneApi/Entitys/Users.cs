using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalInsightsTribuneApi.Entitys
{
    public class Users
    {
        public Users() 
        {
          Comments =  new HashSet<Comments>();   
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [Column("password")]
        [StringLength(255)]
        public string Password { get; set; }

        [InverseProperty("Fk_Users")]
        public virtual ICollection<Comments> Comments { get; set; }


    }
}
