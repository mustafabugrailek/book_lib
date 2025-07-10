using System;
using System.Collections.Generic;
using System.Linq;
using book_lib.Entities;
using book_lib.Service;

namespace book_lib
{
    class Program
    {
        static void Main(string[] args)
        {
            BookService bookService = new BookService();
            MemberService memberService = new MemberService();
            LoanService loanService = new LoanService();

            while (true)
            {
                Console.WriteLine("=== BOOK MENU ===");
                Console.WriteLine("1 - Add Book");
                Console.WriteLine("2 - List Books");
                Console.WriteLine("3 - Delete Book");
                Console.WriteLine("4 - Update Book Stock");
                Console.WriteLine("5 - Exit");
                Console.Write("Your Choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Book Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Author: ");
                        string author = Console.ReadLine();

                        Console.Write("ISBN: ");
                        long isbn = Convert.ToInt64(Console.ReadLine());

                        Console.Write("Published Year: ");
                        int year = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Stock: ");
                        int stock = Convert.ToInt32(Console.ReadLine());

                        Book newBook = new Book(name, author, isbn, year, stock);
                        bookService.AddBook(newBook);
                        Console.WriteLine(" Book added successfully.\n");
                        break;

                    case "2":
                        var books = bookService.GetAllBooks();
                        Console.WriteLine("--- Book List ---");
                        foreach (var b in books)
                        {
                            Console.WriteLine(b);
                        }
                        Console.WriteLine();
                        break;

                    case "3":
                        Console.Write("Enter ISBN of book to delete: ");
                        long deleteIsbn = Convert.ToInt64(Console.ReadLine());

                        bool deleted = bookService.RemoveBook(deleteIsbn);
                        Console.WriteLine(deleted ? " Book deleted.\n" : " Book not found.\n");
                        break;

                    case "4":
                        Console.Write("Enter ISBN of book to update: ");
                        long updateIsbn = Convert.ToInt64(Console.ReadLine());

                        Console.Write("Enter new stock value: ");
                        int newStock = Convert.ToInt32(Console.ReadLine());

                        bool updated = bookService.UpdateBookStock(updateIsbn, newStock);
                        Console.WriteLine(updated ? " Stock updated.\n" : " Book not found.\n");
                        break;

                    case "5":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine(" Invalid choice.\n");
                        break;
                }
            }
        }
    }
}
