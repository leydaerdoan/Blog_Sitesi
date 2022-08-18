using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Blog_Sitesi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //Post içeriği
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        //Okuma miktarı
        public decimal? AvarageScore { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey("CategoryName")]
        public Category Category { get; set; }




    }
}
