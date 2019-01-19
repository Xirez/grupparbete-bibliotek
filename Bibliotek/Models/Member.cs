using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Member
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Firstname")]
        public string Name { get; set; }
        [Display(Name = "Surname")]
        public string Surname { get; set; }
      //  [Display(Name = "Loans")]
        //public ICollection<BookCopy> BookCopies { get; set; }//:)
    }
}
