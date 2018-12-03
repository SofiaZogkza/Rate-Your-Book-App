using RateYourBook.Types;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IUserService
    {
        Users Login();

        List<Books> AddBook(Books book); //TODO: throw exception or message if the user does not exist
        List<Evaluations> RateBook(Evaluations evaluation);
        List<Users> AddUser(Users user);

        Books GetBookByIsbn(int ISBN);
        List<Books> GetAllBooksAddedPerUser(int userId);
        List<Books> GetAllBooks();

        Users GetUserById(int userId);
        List<Users> GetAllUsers();

        List<Evaluations> GetAllEvaluationsPerBook();
        List<Evaluations> GetAllEvaluationsPerUser(int userId);

        string DeleteEvaluation(int id);
    }
}
