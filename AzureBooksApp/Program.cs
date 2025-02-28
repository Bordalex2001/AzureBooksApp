using AzureBooksApp.Models;

class Program
{
    static void Main()
    {
        using (var context = new AzureBooksDBContext())
        {
            //Читаем данные из БД
            var booksWithAuthors = context.BooksWithAuthors.ToList();

            foreach (var book in booksWithAuthors)
            {
                Console.WriteLine($"Книга: {book.BookTitle} ({book.YearPublished})");
                Console.WriteLine($"Автор: {book.AuthorName}");
                Console.WriteLine(new string('-', 40));
            }

            //Добавляем новые данные
            var newAuthor = new Author { Name = "New Author" };
            var newBook = new Book { Title = "New Book", YearPublished = 2025 };
            var newBookAuthor = new BookAuthor { Book = newBook, Author = newAuthor };

            context.Authors.Add(newAuthor);
            context.Books.Add(newBook);
            context.BookAuthors.Add(newBookAuthor);

            context.SaveChanges();

            Console.WriteLine("\nДанные успешно добавлены!");
        }
    }
}