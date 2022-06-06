using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Model
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="*** Please Enter BookName")]
        public string name { get; set; }
        public string author { get; set; }

        public string isbn { get; set; }
    }
}
