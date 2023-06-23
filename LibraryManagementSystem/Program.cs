using System.Data.Common;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=ROHITHKUMAR;Initial Catalog=LibraryManagementSystem;Integrated Security=True";

            DataBaseOperation dataBaseOperation = new DataBaseOperation(connectionString);
            while (true)
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Total number of books");
                Console.WriteLine("3. Number of available books");
                Console.WriteLine("4. Number of borrowed books");
                Console.WriteLine("5. List of books by author");
                Console.WriteLine("6. List of books by genre");
                Console.WriteLine("7. Borrow a book");
                Console.WriteLine("8. Return a book");
                Console.WriteLine("9. Book details");
                Console.WriteLine("10. Exit");

                Console.Write("Enter your choice (1-10): ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter book ID: ");
                    int bookId = int.Parse(Console.ReadLine());
                    Console.Write("Enter title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter genre: ");
                    string genre = Console.ReadLine();

                    Library library = new Library()
                    {
                        book_id = bookId,
                        Title = title,
                        Author = author,
                        Genre = genre,
                        Borrowed = false
                    };

                    dataBaseOperation.AddBook(library);
                    Console.WriteLine("Book added successfully.");
                }
                else if (choice == "2")
                {
                    int totalBooks = dataBaseOperation.GetTotalBooks();
                    Console.WriteLine($"Total number of books: {totalBooks}");
                }
                else if (choice == "3")
                {
                    int availableBooks = dataBaseOperation.GetAvailableBooks();
                    Console.WriteLine($"Number of available books: {availableBooks}");
                }
                else if (choice == "4")
                {
                    int borrowedBooks = dataBaseOperation.GetBorrowedBooks();
                    Console.WriteLine($"Number of borrowed books: {borrowedBooks}");
                }
                else if (choice == "5")
                {
                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();

                    Library library = dataBaseOperation.GetBooksByAuthor(author);
                    if (library != null)
                    {
                        Console.WriteLine(library);
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }

                else if (choice == "6")
                { 
                    Console.Write("Enter author: ");
                    string genre = Console.ReadLine();

                    Library library = dataBaseOperation.GetBooksByAuthor(genre);
                    if (library != null)
                    {
                        Console.WriteLine(library);
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }

                else if (choice == "7")
                {
                    Console.Write("Enter book ID to borrow: ");
                    int book_Id = int.Parse(Console.ReadLine());
                    dataBaseOperation.BorrowBook(book_Id);
                    Console.WriteLine("Book borrowed successfully.");
                }
                else if (choice == "8")
                {
                    Console.Write("Enter book ID to return: ");
                    int book_Id = int.Parse(Console.ReadLine());
                    dataBaseOperation.ReturnBook(book_Id);
                    Console.WriteLine("Book returned successfully.");
                }
                else if (choice == "9")
                {
                    Console.Write("Enter book ID: ");
                    int book_Id = int.Parse(Console.ReadLine());

                    Library library = dataBaseOperation.GetBookDetails(book_Id);
                    if (library != null)
                    {
                        Console.WriteLine(library);
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
                else if (choice == "10")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
    }
}
    