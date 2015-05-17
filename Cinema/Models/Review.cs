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
        public string Title { get; set; }
        public virtual Film Film { get; set; }
    }
}