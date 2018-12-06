using Interfaces;
using RateYourBook.Types;
using Services;
using System.Collections.Generic;
using System.Web.Http;

namespace RateYourBookApi
{
    [Authorize]
    public class UsersController : ApiController
    {
        private IUserService userService = new UserService();

        public UsersController()
        {
            //
        }
      
        [HttpPost]
        [Route("login")]
        public string LogIn(Users user)
        {
            return userService.LogIn(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public List<Users> Register(Users user)
        {
            return userService.Register(user);
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

        [HttpPost]
        [Route("evaluations")]
        public List<Evaluations> RateBook(Evaluations evaluation)
        {
            return userService.RateBook(evaluation);
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

        [HttpDelete]
        [Route("evaluations/{id}")]
        public string DeleteEvaluation(int id)
        {
            return userService.DeleteEvaluation(id);
        }
    }
}