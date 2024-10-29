using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookStore.BAL;
using BookStore.Models;
using BookStore.Service;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        //BookRepository
        private readonly BookRepository bookRepository;

        public BookController(BookRepository bookBAL)
        {
            bookRepository = bookBAL;

        }
        public async Task <ActionResult> GetBooks()
        {
            var bookOwners =  await  bookRepository.GetBooksOwnersByAgeGroup();
           
            var viewmodel = new BookOwnerViewModel
            {
                Adults = bookOwners.Above18,
                Children= bookOwners.Below18
            };
            return View(viewmodel);
        }
        public async Task <ActionResult>HardCoverBooks()
        {
            var hardcover  = await bookRepository.GetHardCoverBooks();
            return View (hardcover);

        }
        public async Task<ActionResult> GetAllBooks()
        {
            var AllBooks = await bookRepository.GetAllBooks();
            return View(AllBooks);

        }

    }
}