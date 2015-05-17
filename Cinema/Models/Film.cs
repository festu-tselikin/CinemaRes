using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; }
        public string FilmName { get; set; }
        [Column(TypeName = "ntext")]
        [DataType(DataType.MultilineText)]
        public string AllAbout { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        [ForeignKey("ECRB")]
        public int ECRBId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ECRB ECRB { get; set; }   
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}