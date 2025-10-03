﻿using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository) 
        {
            _bookRepository = bookRepository;
        }

        public List<Book> ViewBooks()
        {
            return _bookRepository.ViewBooks();
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            var newBook = new Book
            {
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                CreatedBy = book.Author,
                CreatedTime = DateTime.Now
            };

            _bookRepository.AddBook(newBook);
        }

        public Book GetBookById(int bookId)
        {
            return _bookRepository.GetBookById(bookId);
        }

        public void UpdateBook(Book book)
        {
            if(book == null)
            {
                throw new ArgumentNullException();
            }

            var existingBook = _bookRepository.GetBookById(book.Id);
            if(existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Description = book.Description;
                existingBook.Author = book.Author;

                _bookRepository.UpdateBook(existingBook);
            }
        }

        public void DeleteBook(int bookId)
        {
            _bookRepository.DeleteBook(bookId);
        }
    }
}
