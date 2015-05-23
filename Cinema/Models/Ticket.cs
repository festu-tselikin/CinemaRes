using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [ForeignKey("Client")]
        public string ClientId { get; set; }
        [ForeignKey("Sector")]
        public int SectorId { get; set; }
        [ForeignKey("Session")]
        public int SessionId { get; set; }
        public virtual Session Session { get; set; }
        public virtual Sector Sector { get; set; }
        public virtual ApplicationUser Client {get;set;}
        [Display(Name = "Ряд")]
        public int NColumn { get; set; }
        [Display(Name = "Место")]
        public int NSpot { get; set; }
        [Display(Name = "Цена")]
        public float Price { get; set; }
    }
}