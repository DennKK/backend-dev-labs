namespace lab12.Models;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated(); 

        if (context.Books.Any()) return;

        var books = new[]
        {
            new Book { Title = "1984", Author = "George Orwell", Year = 1949, Genre = "Dystopian" },
            new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960, Genre = "Fiction" },
            new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925, Genre = "Classic" },
            new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Year = 1813, Genre = "Romance" }
        };

        context.Books.AddRange(books);
        context.SaveChanges();
    }
}
