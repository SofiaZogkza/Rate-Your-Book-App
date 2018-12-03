using Interfaces;
using RateYourBook.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserService : IUserService
    {
        public Users Login()
        {
            throw new NotImplementedException();
        }

        #region Add
        public List<Books> AddBook(Books book)
        {
            InsertManyBooks(book);

            var books = GetAllBooksFromDb();

            return books;
        }

        public List<Users> AddUser(Users user)
        {
            InsertUser(user);

            var users = GetAllUsers();

            return users;
        }

        public List<Evaluations> RateBook(Evaluations evaluation)
        {
            InsertEvaluation(evaluation);

            var evaluations = GetAllEvaluationsPerBook();

            return evaluations;
        }
        #endregion

        #region Get - Services are Ready

        public Books GetBookByIsbn(int ISBN)
        {
            return GetBookFromDb(ISBN);
        }
        public List<Books> GetAllBooksAddedPerUser(int givenUserId)
        {
            using (var context = new BookDbContext())
            {
                var books = context.Book.ToList();
                var users = context.User.ToList();

                var booksAddedPerUser = new List<Books>();

                foreach (var u in users)
                {
                    foreach (var b in books)
                    {
                        if (u.Id == b.User.Id)
                        {
                            if (u.Id == givenUserId)
                            {
                                booksAddedPerUser.Add(b);
                            }
                        }
                    }
                }

                return booksAddedPerUser;
            }
        }
        public List<Books> GetAllBooks()
        {
            return GetAllBooksFromDb();
        }

        public Users GetUserById(int id)
        {
            return GetUserFromDb(id);
        }
        public List<Users> GetAllUsers()
        {
            return GetAllUsersFromDb();
        }
        
        public List<Evaluations> GetAllEvaluationsPerBook()
        {
            using (var context = new BookDbContext())
            {
                var evaluations = context.Evaluation.ToList();
                var books = context.Book.ToList();
                var users = context.User.ToList();
                               
                return evaluations;
            }
        }
        public List<Evaluations> GetAllEvaluationsPerUser(int givenUserId)
        {
            //{"id":1} --> Test this value in Restlet or Fiddler
            using (var context = new BookDbContext())
            {
                var evaluations = context.Evaluation.ToList();
                var books = context.Book.ToList();
                var users = context.User.ToList();

                var evaluationsPerUser = new List<Evaluations>();

                foreach (var u in users)
                {
                    foreach (var e in evaluations)
                    {
                        if (u.Id == e.User.Id)
                        {
                            if(u.Id == givenUserId)
                            {
                                evaluationsPerUser.Add(e);
                            }
                        }
                    }
                }

                return evaluationsPerUser;
            }
        }
        #endregion

        //----------------------------------------------------
        private static void InsertManyBooks(Books request)
        {
            #region json Example
            //{
            //  "Title" : "Doctor Sleep",
            //	"Author" : "Stephen King",
            //	"User":
            //	{
            //        "Id" : 2
            //  }
            //}
            #endregion
            var book = new Books()
            {
                Id = request.Id,
                Title = request.Title,
                Author = request.Author
            };

            //DbSet
            using (var context = new BookDbContext())
            {
                var user = context.User.FirstOrDefault(x => x.Id == request.User.Id);
                book.User = user;

                context.Book.AddRange(new List<Books> { book });
                context.SaveChanges();
            }
        }

        private static void InsertEvaluation(Evaluations request)
        {
            #region json Example
            //{
            //    "TextReview" : "Wtf man?",
            //    "Stars" : 5,
            //    "user":
            //    {
            //        "Id" : 1
            //    },
            //    "book":
            //    {
            //        "isbn" : 2
            //    }
            //}
            #endregion
            var evaluation = new Evaluations()
            {
                TextReview = request.TextReview,
                Stars = request.Stars
            };

            //DbSet
            using (var context = new BookDbContext())
            {
                var user = context.User.FirstOrDefault(x => x.Id == request.User.Id);
                evaluation.User = user;

                var book = context.Book.FirstOrDefault(z => z.Id == request.Book.Id);
                evaluation.Book = book;

                context.Evaluation.AddRange(new List<Evaluations> { evaluation });
                context.SaveChanges();
            }
        }

        private static void InsertUser(Users request)
        {
            #region json Example
            //{
            //   "Name":"Mary",
            //   "Surname":"Papadopoulou",
            //   "Email":"mar.pap@gmail.com",
            //   "UserName":"MaryPap",
            //   "Password":"1234"
            //}
            #endregion
            var user = new Users()
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password
            };

            //DbSet
            using (var context = new BookDbContext())
            {
                context.User.AddRange(new List<Users> { user });
                context.SaveChanges();
            }
        }

        private Books GetBookFromDb(int ISBN)
        {
            using (var context = new BookDbContext())
            {
                var book = context.Book.Find(ISBN);

                return book;
            }
        }

        private Users GetUserFromDb(int userId)
        {
            using (var context = new BookDbContext())
            {
                var user = context.User.Find(userId);

                return user;
            }
        }

        private static List<Books> GetAllBooksFromDb()
        {
            using (var context = new BookDbContext())
            {
                var books = context.Book.SqlQuery("SELECT * FROM Books").ToList();

                return books;
            }
        }

        private static List<Users> GetAllUsersFromDb()
        {
            using (var context = new BookDbContext())
            {
                var users = context.User.SqlQuery("SELECT * FROM Users").ToList();

                return users;
            }
        }
    }
}
