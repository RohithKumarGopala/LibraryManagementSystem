using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Data.Common;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Library
    {
        public int book_id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool Borrowed { get; set; }

        public override string ToString()
        {
            return $"Book ID: {book_id}\nTitle: {Title}\nAuthor: {Author}\nGenre: {Genre}\nBorrowed: {Borrowed}";
        }
    }
}