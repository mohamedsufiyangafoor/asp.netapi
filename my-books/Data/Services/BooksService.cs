using my_books.Data.Models;
using my_books.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class BooksService
    {
        private readonly AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead : null,
                Rate = book.IsRead ? book.Rate : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            var allBooks = _context.Books.ToList();
            return allBooks;
        }


        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(n => n.Id == id);
        }

        public Book UpdateBookById(int id,BookVM book)
        {
            var bookToUpdate = _context.Books.FirstOrDefault(n => n.Id == id);
            if(bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Description = book.Description;
                bookToUpdate.IsRead = book.IsRead;
                bookToUpdate.DateRead = book.IsRead ? book.DateRead : null;
                bookToUpdate.Rate = book.IsRead ? book.Rate : null;
                bookToUpdate.Genre = book.Genre;
                bookToUpdate.Author = book.Author;
                bookToUpdate.CoverUrl = book.CoverUrl;
                _context.SaveChanges();
            }
            return bookToUpdate;
        }

        public void DeleteBookById(int id)
        {
            var bookToDelete = _context.Books.FirstOrDefault(n => n.Id == id);
            if(bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
                _context.SaveChanges();
            }
            
        }
    }
}
