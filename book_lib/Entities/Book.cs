
using System;

namespace book_lib.Entities
{
    public class Book
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public long ISBN { get; set; }
        public int PublishedYear { get; set; }
        public int Stock { get; set; }

        public Book(string bookName, string author, long isbn, int publishedYear, int stock)
        {
            BookName = bookName;
            Author = author;
            ISBN = isbn;
            PublishedYear = publishedYear;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"{BookName} by {Author} (ISBN: {ISBN}) - Published: {PublishedYear} - Stock: {Stock}";
        }
    }
}