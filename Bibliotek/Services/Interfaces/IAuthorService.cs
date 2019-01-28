using System.Collections.Generic;
using Library.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Services.Interfaces
{
    public interface IAuthorService
    {
        /// <summary>
        /// Hämtar en SelectList av alla författare
        /// </summary>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetSelectListItems();

	    //void Add(Author author);

	    //void Delete(int id);

	    //string GetLastnameByID(int id);

	    //string GetFirstnameByID(int id);

	    //ICollection<Book> GetAuthorBooksByID(int id);
	}
}