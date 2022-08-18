using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Sitesi.Models
{
    public class Favorites
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }

    }
}
