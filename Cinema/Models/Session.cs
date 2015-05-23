using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Session
    {
        [Key]
        public int SessionID { get; set; }
        [ForeignKey("Film")]
        public int FilmId { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата сеанса")]
        [CustomValidation(typeof(Session),"ValidateDate")]
        public DateTime? DateSession { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Время вылета")]
        public DateTime? TimeSession { get; set; }
        public virtual Room Room {get;set;}
        public virtual Film Film { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
        public static ValidationResult ValidateDate(DateTime date)
        {
            if (date.Date < DateTime.Today)
            {
                return new ValidationResult("Нельзя выбрать уже прошедший день");
            }
            return ValidationResult.Success;
        }
    }
}