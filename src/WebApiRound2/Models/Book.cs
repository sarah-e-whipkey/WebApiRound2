using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRound2.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Title Required")]
        public string Title { get; set;}

        [Required(ErrorMessage ="Author name required")]
        public string Author { get; set; }

        [Required(ErrorMessage ="Genre required")]
        [RegularExpression(@"Sci Fi|Fiction|Fantasy")]
        public string Genre { get; set; }

        [Required(ErrorMessage ="Page count required")]
        [Range(0, int.MaxValue, ErrorMessage ="Page count can't be negative")]
        public int PageCount { get; set; }
    }
}
