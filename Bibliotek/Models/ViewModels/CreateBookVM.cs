using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotek.Models.ViewModels
{
	public class CreateBookVM
	{
		public Book Book { get; set; }
		public int NumberOfCopiesToAdd { get; set; }
		

	}
}
