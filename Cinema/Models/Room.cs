using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Display(Name = "Название зала")]
        public string RoomName { get; set; }
        [Display(Name = "Вместимость зала")]
        public int Capacity {get;set;}
        public virtual ICollection<Session> Session { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}