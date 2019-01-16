using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string ISBN { get; set; }
        [Display(Name = "Titel")]
        public string  Title { get; set; }
        [Display(Name = "Author")]
        [Required]
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        [Display(Name="Description")]
        public string Description { get; set; }
        [Display(Name ="Copies")]
        public ICollection<BookCopy> BookCopeis { get; set; }
    }
}
