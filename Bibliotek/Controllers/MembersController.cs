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

namespace Library.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IAuthorService _authorService;

        public MembersController(IMemberService memberService, IAuthorService authorService)
        {
            this._memberService = memberService;
            this._authorService = authorService;
        }

        /// <summary>
        /// Visa en dashboard för böcker
        /// </summary>
        public IActionResult Index()
        {
            var vm = new MemberIndex();
            vm.Members = _memberService.GetAll();

            //vm.Authors = _authorService.GetSelectListItems();

            return View(vm);
        }

        /// <summary>
        /// Visar detaljer om vald användare (engelska?) ;D
        /// </summary>
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = _memberService.Get(id);

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        /// <summary>
        /// Visar en sida för att skapa en bok
        /// </summary>
        public IActionResult Create()
        {
            ViewBag.Members = _authorService.GetSelectListItems();
            return View();
        }

        /// <summary>
        /// Skapar en ny användare
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                _memberService.Add(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        /// <summary>
        /// Visar en sida för att ändra på en bok
        /// </summary>
        public IActionResult Edit(int id)
        {

            var member = _memberService.Get(id);

            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        /// <summary>
        /// Ändrar på en bok
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Member member)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    _memberService.Update(member);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_memberService.MemberExists(member.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(member);
        }

        /// <summary>
        /// Visar en sida för att ta bort en bok
        /// </summary>
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = _memberService.Get(id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        /// <summary>
        /// Tar bort en bok
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _memberService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
