﻿using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookCopy
    {
        [Key]
        public int ID { get; set; }

	    public int BookID { get; set; }
		public Book Book { get; set; }
    }
}