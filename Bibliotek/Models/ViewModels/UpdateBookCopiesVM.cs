using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotek.Models.ViewModels
{
	public class UpdateBookCopiesVM
	{
		public Book Book { get; set; }
		public int UpdateBookCopies { get; set; }
	}
}
