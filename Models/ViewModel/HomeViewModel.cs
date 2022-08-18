using System.Collections.Generic;

namespace Blog_Sitesi.Models.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Comment> Comment { get; set; }
    }
}
