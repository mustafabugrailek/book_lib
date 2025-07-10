using System;
using System.Collections.Generic;
using book_lib.Entities;

namespace book_lib.Service
{
    public class BookService
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book) => books.Add(book);
        public List<Book> GetAllBooks() => books;

        public bool RemoveBook(long isbn)
        {
            var book = books.Find(b => b.ISBN == isbn);
            if (book != null) { books.Remove(book); return true; }
            return false;
        }

        public bool UpdateBookStock(long isbn, int newStock)
        {
            var book = books.Find(b => b.ISBN == isbn);
            if (book != null) { book.Stock = newStock; return true; }
            return false;
        }

        public List<Book> SearchByTitle(string keyword) => books.FindAll(b => b.BookName.ToLower().Contains(keyword.ToLower()));
        public List<Book> SearchByAuthor(string keyword) => books.FindAll(b => b.Author.ToLower().Contains(keyword.ToLower()));
        public Book SearchByISBN(long isbn) => books.Find(b => b.ISBN == isbn);
    }
}