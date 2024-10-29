using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Model;
namespace BookStore.BAL
{
    public interface IBooksRepository
    {
        Task<(List<Owner> Below18, List<Owner> Above18)> GetBooksOwnersByAgeGroup();
       //Task<List<Owner>> Getbooks (bool isAdult);
        Task<List<Book>> GetHardCoverBooks();
        Task<List<Book>> GetAllBooks();

    }
}
