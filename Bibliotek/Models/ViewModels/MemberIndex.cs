using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModels
{
    public class MemberIndex
    {
        public IEnumerable<Member> Members { get; set; }
        //public IEnumerable<SelectListItem> Authors { get; set; }

        //public Author Author { get; set; } = new Author();
    }
}
