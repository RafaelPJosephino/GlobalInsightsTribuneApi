using GlobalInsightsTribuneApi.Enumerator;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalInsightsTribuneApi.Entitys
{
    public class News
    {

       public News ()
        {
            Comments = new HashSet<Comments>();       

        }

        [Key]
        [Column ("id") ]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("contents")]
        public string Contents { get; set; }

        [Column("author")]
        [StringLength(255)]
        public string Author { get; set; }

        [Column("source")]
        [StringLength(255)]
        public string Source { get; set; }

        [Required]
        [Column("date_publication")]
        public DateTime date_publication { get; set; }

        [Column("category")]
        public EnumCategory Category { get; set; }


        [InverseProperty("Fk_News")]
        public virtual ICollection<Comments> Comments { get; set; }



            
    }
}
