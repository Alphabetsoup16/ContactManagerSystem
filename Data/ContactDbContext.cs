using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data
{
    public class ContactDbContext : DbContext
	{	
		public DbSet<Contact> Contacts { get; set; }
        public string DbPath { get; }

        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}

