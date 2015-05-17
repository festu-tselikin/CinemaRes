using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [ForeignKey("Street")]
        public int StreetId { get; set; }
        [Display(Name = "Фамилия")]
        public string Family { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string SecName { get; set; }
        public virtual Street Street { get; set; }
    }
}