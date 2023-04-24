using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalInsightsTribuneApi.Entitys
{
    public class Comments
    {

        Comments() 
        {

        }


        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("text")]
        public string Text { get; set; }


        [Column("users_id")]
        public int Users_id { get; set; }

        [Column("news_id")]
        public int News_id { get; set; }

        [Required]
        [Column("date_publication")]
        public DateTime date_publication { get; set; }

        [ForeignKey(nameof(Users_id))]
        [InverseProperty(nameof(Users.Comments))]
        public virtual Users Fk_Users{ get; set; }

        [ForeignKey(nameof(News_id))]
        [InverseProperty(nameof(News.Comments))]
        public virtual News Fk_News { get; set; }



    }
}
