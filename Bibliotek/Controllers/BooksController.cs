using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;
using Library.Services;
using Library.Models.ViewModels;
using Library.Services.Interfaces;
using Bibliotek.Models.ViewModels;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BooksController(IBookService bookService, IAuthorService authorService)
        {
            this._bookService = bookService;
            this._authorService = authorService;
        }

        /// <summary>
        /// Visa en dashboard för böcker
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var vm = new BookIndexVM();
            vm.Books = _bookService.GetAll();

            vm.Authors = _authorService.GetSelectListItems();

            return View(vm);
        }
        
        /// <summary>
        /// Filtrerar bort böcker som inte är tillgängliga och visar Index
        /// </summary>
        /// <returns>Books/Index</returns>
        public IActionResult Available()
        {
            var vm = new BookIndexVM();
            vm.Books = _bookService.GetAvailable();
            vm.Authors = _authorService.GetSelectListItems();
            return View("Index", vm);
        }

        /// <summary>
        /// Filtrerar böckerna på vald författare och returnerar Index
        /// </summary>
        /// <param name="vm"></param>
        /// <returns>Books/Index</returns>
        public IActionResult FilterOnAuthor(BookIndexVM vm)
        {
            vm.Books = _bookService.GetAllByAuthor(vm.Author);
            vm.Authors = _authorService.GetSelectListItems();
            return View("Index", vm);
        }
        
        /// <summary>
        /// Visar detaljer om vald bok
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.Get(id);
                
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        /// <summary>
        /// Visar en sida för att skapa en bok
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
			var vm = new CreateBookVM();
	        vm.NumberOfCopiesToAdd = 1;
            ViewBag.Authors = _authorService.GetSelectListItems();
            return View(vm);
        }

        /// <summary>
        /// Skapar en ny bok
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateBookVM vm)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(vm.Book);
	            _bookService.AddCopies(vm.Book.ID, vm.NumberOfCopiesToAdd);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        /// <summary>
        /// Visar en sida för att ändra på en bok
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
			var vm = new CreateBookVM();
            var book = _bookService.Get(id);
            if (book == null)
            {
                return NotFound();
            }

	        vm.Book = book;
            return View(vm);
        } 

        /// <summary>
        /// Ändrar på en bok
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreateBookVM vm)
        {
            if (ModelState.IsValid)
            {
               
                try
                {
	                //vm.NumberOfCopiesToAdd
					_bookService.AddCopies(vm.Book.ID,vm.NumberOfCopiesToAdd);
	                var bookToUpdate = _bookService.Get(vm.Book.ID);
                    _bookService.Update(bookToUpdate);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_bookService.BookExists(vm.Book.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(vm);
        }

        /// <summary>
        /// Visar en sida för att ta bort en bok
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        /// <summary>
        /// Tar bort en bok
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
