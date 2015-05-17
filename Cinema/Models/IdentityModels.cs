using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Collections.Generic;

namespace Cinema.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecName { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
        public ApplicationUser()
        {
            Ticket = new List<Ticket>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Genre> tbGenre { get; set; }
        public DbSet<Film> tbFilm { get; set; }
        public DbSet<Client> tbClients { get; set; }
        public DbSet<ECRB> tbECRB { get; set; }
        public DbSet<Review> tbReview { get; set; }
        public DbSet<Room> tbRoom { get; set; }
        public DbSet<Sector> tbSector { get; set; }
        public DbSet<Street> tbStreet { get; set; }
        public DbSet<Ticket> tbTicket { get; set; }
        public DbSet<Session> tbSession { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}