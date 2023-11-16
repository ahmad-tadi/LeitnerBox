using Microsoft.EntityFrameworkCore;

namespace Leitner;

// The DbContext class for the leitner box
public class LeitnerBoxContext : DbContext
{
	public DbSet<Flashcard> Flashcards { get; set; } // The DbSet property for the flashcards

	// The method to configure the connection string and the database provider
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source=D:\\leitnerbox.db"); // Using SQLite as the database provider
	}
}