using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Street
    {
        [Key]
        public int StreetID { get; set; }
        [Display(Name = "Улица")]
        public string StreetName { get; set; }
        public virtual ICollection<Client> Client { get; set; }
    }
}