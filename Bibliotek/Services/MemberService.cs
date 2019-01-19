using Library.Data;
using Library.Models;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    public class MemberService : IMemberService
    {
        private readonly LibraryContext _context;

        public MemberService(LibraryContext libraryContext)
        {
            this._context = libraryContext;
        } 
        public void Add(Member member)
        {
            _context.Add(member);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            ///TODO : Kontrollera eventuella utlåningar?
            var member = _context.Members.Find(id);
            _context.Members.Remove(member);
            _context.SaveChanges();
        }

        public Member Get(int? id)
        {
            return _context.Members.FirstOrDefault(m => m.ID == id);
        }


        public IList<Member> GetAll()
        {
            ///TODO: ev. inkludera länkade tabeller
            return _context.Members
                .ToList();
        }

        public bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.ID == id);
        }

        public void Update(Member member)
        {
            _context.Update(member);
            _context.SaveChanges();
        }
    }
}
