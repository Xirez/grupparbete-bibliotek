using System.Collections.Generic;
using Library.Models;

namespace Library.Services.Interfaces
{
    public interface IMemberService
    {
        /// <summary>
        /// Lägger till en bok
        /// </summary>
        /// <param name="member">Boken som ska läggas till</param>
        void Add(Member member);
        /// <summary>
        /// Kollar om boken finns eller ej
        /// </summary>
        /// <param name="id">bokens ID</param>
        /// <returns>true om boken finns</returns>
        bool MemberExists(int id);
        /// <summary>
        /// Tar bort en bok givet dess ID
        /// </summary>
        /// <param name="id">ID på boken som ska tas bort</param>
        void Delete(int id);
        /// <summary>
        /// Hämtar en bok utifrån dess ID
        /// </summary>
        /// <param name="id">ID på boken som ska hämtas</param>
        /// <returns></returns>
        Member Get(int? id);
        /// <summary>
        /// Hämtar alla böcker
        /// </summary>
        /// <returns>en lista av alla böcker</returns>
        IList<Member> GetAll();     
        void Update(Member member);
    }
}