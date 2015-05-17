using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Display(Name = "Название жанра")]
        public string GenreName { get; set; }
        public virtual ICollection<Film> Film { get; set; }
    }
}