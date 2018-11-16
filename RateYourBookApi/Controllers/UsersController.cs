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

        }

        [HttpPost]
        [Route("addBook")]
        public List<Books> AddBook(Books book)
        {
            return userService.AddBook(book);
        }

        [HttpPost]
        [Route("rateBook")]
        public List<Evaluations> RateBook(Evaluations evaluation)
        {
            return userService.RateBook(evaluation);
        }

        [Route("getBookByIsbn/{ISBN}")]
        public Books GetBookByIsbn(int ISBN)
        {
            return userService.GetBookByIsbn(ISBN);
        }

        //[HttpPost]
        [Route("getallbooks")]
        public IEnumerable<Books> GetBooks()
        {
            return userService.GetAllBooks();
        }

        [Route("getUserById/{id}")]
        public Users GetUserById(int id)
        {
            return userService.GetUserById(id);
        }

        [HttpPost]
        [Route("getallusers")]       
        public IEnumerable<Users> GetAllUsers()
        {
            return userService.GetAllUsers();
        }
        
        [Route("getAllEvaluationsPerBook")]
        public List<Evaluations> GetAllEvaluationsPerBook()
        {
            return userService.GetAllEvaluationsPerBook();
        }

        [HttpPost]
        [Route("getAllEvaluationsPerUser")]
        public List<Evaluations> GetAllEvaluationsPerUser(Users user)
        {
            return userService.GetAllEvaluationsPerUser(user);
        }

        [HttpPost]
        [Route("getAllBooksAddedPerUser")]
        public List<Books> GetAllBooksAddedPerUser(Users givenUser)
        {
            return userService.GetAllBooksAddedPerUser(givenUser);
        }
    }
}