using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Sector
    {
        [Key]
        public int SectorId { get; set; }
        [Display(Name = "Название сектора")]
        public string SectorName { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}