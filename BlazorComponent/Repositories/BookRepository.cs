using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazorComponent.Models;

namespace BlazorComponent.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly List<Book> _books = new();
        private int _nextId = 1;

        public Task AddAsync(Book entity)
        {
            entity.Id = _nextId++;
            _books.Add(entity);
            return Task.CompletedTask;
        }

        public Task<List<Book>> GetAllAsync()
        {
            return Task.FromResult(_books.ToList());
        }

        public Task<Book?> GetByIdAsync(int id)
        {
            return Task.FromResult(_books.FirstOrDefault(x => x.Id == id));
        }

        public Task RemoveAsync(int id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Book book)
        {
            var existingBook = _books.FirstOrDefault(x => x.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Update(book.Name, book.Author, book.ISBN, book.ReleaseDate);
            }
            return Task.CompletedTask;
        }
    }
}