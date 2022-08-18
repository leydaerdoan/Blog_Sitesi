using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Sitesi.Models
{
    public class PostDetail
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }


        public string Description { get; set; }


    }
}
