using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }
        [Display(Name = "Lastname")]
        public string LastName { get; set; }
        public virtual ICollection<Book> AuthorBooks { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

    }
}