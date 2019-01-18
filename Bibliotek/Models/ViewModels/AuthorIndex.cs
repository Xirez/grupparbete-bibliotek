using Library.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotek.Models.ViewModels
{
    public class AuthorIndex
    {
        public IEnumerable<SelectListItem> Authors { get; set; }

        public Author Author { get; set; } = new Author();
    }
}
