using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RateYourBook.Types
{
    [DataContract]
    public class Books
    {
        [DataMember(Name = "isbn")]
        public int Id { get; set; } //ISBN

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "user")]
        public Users User { get; set; }
    }
}
