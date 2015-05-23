using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [ForeignKey("Film")]
        public int FilmId { get; set; }
        [Display(Name = "Название отзыва")]
        [Column(TypeName = "ntext")]
        [DataType(DataType.MultilineText)]
        public string AllAbout { get; set; }
        public string NameTitle { get; set; }
        public virtual Film Film { get; set; }
    }
}