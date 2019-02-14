using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibliotek.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Library.Services.Interfaces;
using Library.Models.ViewModels;
using Library.Models;
using Library.Data;

namespace Bibliotek.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public AuthorsController(IAuthorService authorService)
        {
            this._authorService = authorService;

        }

        public IActionResult Index()
        {
            var vm = new AuthorIndex();

            vm.Authors = _authorService.GetSelectListItems();

            return View(vm);
        }

        public IActionResult Delete(int id)
        {
            _authorService.Delete(id);

            var vm = new AuthorIndex();

            vm.Authors = _authorService.GetSelectListItems();

            return View("Index",vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitAuthor(Author model)
        {

            if (ModelState.IsValid)
            {
                _authorService.Add(model);
            }

            var vm = new AuthorIndex();

            vm.Authors = _authorService.GetSelectListItems();

            return View("Index",vm);
        }

        public IActionResult FilterOnAuthor(Author author)
        {
            author.FirstName = _authorService.GetFirstnameByID(author.ID);
            author.LastName = _authorService.GetLastnameByID(author.ID);
            author.AuthorBooks = _authorService.GetAuthorBooksByID(author.ID);

            return View(author);
        }
    }
}