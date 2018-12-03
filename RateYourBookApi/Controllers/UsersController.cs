using Interfaces;
using RateYourBook.Types;
using Services;
using System.Collections.Generic;
using System.Web.Http;

namespace RateYourBookApi
{
    public class UsersController : ApiController
    {
        private IUserService userService = new UserService();

        public UsersController()
        {
            //
        }

        [HttpPost]
        [Route("books")]
        public List<Books> AddBook(Books book)
        {
            return userService.AddBook(book);
        }

        [Route("books/{ISBN}")]
        public Books GetBookByIsbn(int ISBN)
        {
            return userService.GetBookByIsbn(ISBN);
        }

        [Route("books")]
        public IEnumerable<Books> GetBooks()
        {
            return userService.GetAllBooks();
        }

        [Route("books/user/{userId}")]
        public List<Books> GetAllBooksAddedPerUser(int userId)
        {
            return userService.GetAllBooksAddedPerUser(userId);
        }

        [HttpPost]
        [Route("rateBook")]
        public List<Evaluations> RateBook(Evaluations evaluation)
        {
            return userService.RateBook(evaluation);
        }

        [HttpPost]
        [Route("user")]
        public List<Users> AddUser(Users user)
        {
            return userService.AddUser(user);
        }

        [Route("users/{id}")]
        public Users GetUserById(int id)
        {
            return userService.GetUserById(id);
        }
        
        [Route("users")]       
        public IEnumerable<Users> GetAllUsers()
        {
            return userService.GetAllUsers();
        }
        
        [Route("evaluations")]
        public List<Evaluations> GetAllEvaluationsPerBook()
        {
            return userService.GetAllEvaluationsPerBook();
        }
       
        [Route("evaluations/{userId}")]
        public List<Evaluations> GetAllEvaluationsPerUser(int userId)
        {
            return userService.GetAllEvaluationsPerUser(userId);
        }
    }
}