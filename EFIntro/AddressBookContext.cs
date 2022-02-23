using Microsoft.EntityFrameworkCore;



namespace EFIntro
{
    public class AddressBookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("AddressBook");
        }
        public DbSet<Person> Persons { get; set; }
    }
}
