using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{

    public class DataBaseOperation
    {
        public string connectionString;
        public SqlConnection connection;

        public DataBaseOperation(string connectionString)
        {
            this.connectionString = connectionString;
            connection = new SqlConnection(connectionString);
        }

        public void AddBook(Library library)
        {
            connection.Open();
            string insertQuery = "Insert into libraries(book_id, title, author, genre,borrowed) values(@book_id,@title,@author,@genre,@borrowed)";
            SqlCommand InsertCommand = new SqlCommand(insertQuery, connection);
            InsertCommand.Parameters.AddWithValue("@book_id", library.book_id);
            InsertCommand.Parameters.AddWithValue("@title", library.Title);
            InsertCommand.Parameters.AddWithValue("@author", library.Author);
            InsertCommand.Parameters.AddWithValue("@genre", library.Genre);
            InsertCommand.Parameters.AddWithValue("@borrowed", library.Borrowed);

            InsertCommand.ExecuteNonQuery();
        }


        public int GetTotalBooks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Book";
                SqlCommand command = new SqlCommand(query, connection);
                return (int)command.ExecuteScalar();
            }
        }

        public int GetAvailableBooks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Book WHERE Borrowed = 0";
                SqlCommand command = new SqlCommand(query, connection);
                return (int)command.ExecuteScalar();
            }
        }

        public int GetBorrowedBooks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Book WHERE Borrowed = 1";
                SqlCommand command = new SqlCommand(query, connection);
                return (int)command.ExecuteScalar();
            }
        }

        public Library GetBooksByAuthor(string author)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Book WHERE Author = @Author";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Author", author);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Library book = new Library()
                        {
                            book_id = (int)reader["BookId"],
                            Title = (string)reader["Title"],
                            Author = (string)reader["Author"],
                            Genre = (string)reader["Genre"],
                            Borrowed = (bool)reader["Borrowed"]
                        };
                        return book;
                    }
                }
            }
            return null;
        }


        public Library GetBooksByGenre(string genre)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Book WHERE Genre = @Genre";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Genre", genre);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Library book = new Library()
                        {
                            book_id = (int)reader["BookId"],
                            Title = (string)reader["Title"],
                            Author = (string)reader["Author"],
                            Genre = (string)reader["Genre"],
                            Borrowed = (bool)reader["Borrowed"]
                        };
                        return book;
                    }
                }
            }
            return null;
        }

        public void BorrowBook(int bookId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Book SET Borrowed = 1 WHERE BookId = @BookId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookId", bookId);
                command.ExecuteNonQuery();
            }
        }

        public void BorrowerName()

        public void ReturnBook(int bookId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Book SET Borrowed = 0 WHERE BookId = @BookId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookId", bookId);
                command.ExecuteNonQuery();
            }
        }

        public Library GetBookDetails(int bookId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Book WHERE BookId = @BookId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookId", bookId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Library library = new Library()
                        {
                            book_id = (int)reader["BookId"],
                            Title = (string)reader["Title"],
                            Author = (string)reader["Author"],
                            Genre = (string)reader["Genre"],
                            Borrowed = (bool)reader["Borrowed"]
                        };
                        return library;
                    }
                }
            }
            return null;
        }
    }
}

   
