using AudioLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace AudioLibrary.Data
{
    public class AudioLibraryContext:DbContext
    {

        public AudioLibraryContext(DbContextOptions<AudioLibraryContext> opcije): base(opcije) {
        
        }

        public DbSet<Book> Books { get; set; }

    }
}
