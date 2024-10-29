using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;
using BookStore.Service;

namespace BookStore.BAL
{
    public class BookRepository : IBooksRepository
    {
       private readonly  IBookService _bookService;
        public BookRepository(IBookService bookService)
        {
            _bookService = bookService;
        }
        private async Task<List<Owner>> GetBooksData()
        {
            return await _bookService.GetData();
        }
        public async Task<(List<Owner> Below18,List<Owner> Above18)> GetBooksOwnersByAgeGroup()
        {
            var books = await GetBooksData();
            //if (books == null)
            //{
            //    return new List<Owner>();
            //}

            //if (isAdult)
            //{            
            //    return books.Where(adultBook => adultBook.Age >= 18).Select(adultsort => { adultsort.Books = adultsort.Books.OrderBy(adulto => adulto.Name).ToList(); return adultsort; }).ToList();
            //}
            //else
            //{
            //    return books.Where(adultBook => adultBook.Age < 18).Select(adultsort => { adultsort.Books = adultsort.Books.OrderBy(adulto => adulto.Name).ToList(); return adultsort; }).ToList();
            //}
            var above18= books.Where(adultBook => adultBook.Age >= 18).Select(adultsort => { adultsort.Books = adultsort.Books.OrderBy(adulto => adulto.Name).ToList(); return adultsort; }).ToList();
            var below18 = books.Where(adultBook => adultBook.Age < 18).Select(adultsort => { adultsort.Books = adultsort.Books.OrderBy(adulto => adulto.Name).ToList(); return adultsort; }).ToList();
            return (Below18: below18, Above18: above18);

        }

        public async Task<List<Book>> GetHardCoverBooks()
        {
            var HardCoverBooks= await GetBooksData();
            if(HardCoverBooks==null)
            {
                return new List<Book>();
            }
            return HardCoverBooks.SelectMany(ownercover => ownercover.Books).Where(type => type.Type == "Hardcover").OrderBy(cover => cover.Name).ToList();
        }
        public async Task<List<Book>> GetAllBooks()
        {
            var AllBooks = await GetBooksData();
            if (AllBooks == null)
            {
                return new List<Book>();
            }
            return AllBooks.Where(owner => owner.Books != null).SelectMany(listbooks => listbooks.Books).OrderBy(bookssort => bookssort.Name).ToList();
        }
    }
}
