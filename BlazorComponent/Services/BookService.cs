using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazorComponent.Models;
using BlazorComponent.Repositories;

namespace BlazorComponent.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task AddBookAsync(Book book)
        {
            if (string.IsNullOrEmpty(book.Name) || string.IsNullOrEmpty(book.Author) || string.IsNullOrEmpty(book.ISBN))
            {
                throw new Exception("Todos os campos são obrigatórios");
            }
            await _bookRepository.AddAsync(book);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _bookRepository.UpdateAsync(book);
        }

        public async Task RemoveBookAsync(int id)
        {
            await _bookRepository.RemoveAsync(id);
        }
    }
}