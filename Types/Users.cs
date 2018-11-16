using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RateYourBook.Types
{
    [DataContract]
    public class Users
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "surname")]
        public string Surname { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "userName")]
        public string UserName { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

       //[Key, ForeignKey("Book_Id")]
        //[Key, ForeignKey("User_Id"), ForeignKey("Book_Id")]
        //[DataMember(Name = "evalList")]
        //public List<Evaluations> EvalList { get; set; }

        //[Key, ForeignKey("User_Id")]
        //[DataMember(Name = "booksList")]
        //public List<Books> BooksList { get; set; }
    }
}
