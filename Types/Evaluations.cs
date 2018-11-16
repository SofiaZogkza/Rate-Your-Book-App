using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RateYourBook.Types
{
    [DataContract]
    public class Evaluations
    {
        [DataMember(Name ="id")]
        public int Id { get; set; }
        [DataMember(Name = "textReview")]
        public string TextReview { get; set; }
        [DataMember(Name = "stars")]
        public int Stars { get; set; } // TODO: from 1 till 5

        [DataMember(Name = "book")]
        [Required]
        public Books Book { get; set; }

        [DataMember(Name = "user")]
        [Required]
        public Users User { get; set; }
    }
}
