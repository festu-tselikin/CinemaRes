using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class ECRB
    {
        [Key]
        public int ECRBId { get; set; }
        [Display(Name = "Название возрастного рейтинга")]
        public string ECRBName { get; set; }
        public virtual ICollection<Film> Film { get; set; }
    }
}