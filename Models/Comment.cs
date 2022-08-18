using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Blog_Sitesi.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string CommentDescription { get; set; }
        [Display(Name = "Email")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
