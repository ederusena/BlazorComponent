using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazorComponent.Models;
using BlazorComponent.Repositories;

namespace BlazorComponent.Services
{
    public class LoanService
    {
        private readonly LoanRepository _loanRepository;
        private readonly UserRepository _userRepository;
        private readonly BookRepository _bookRepository;

        public LoanService(LoanRepository loanRepository, UserRepository userRepository, BookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        
        public async Task<List<Loan>> GetAllLoansAsync()
        {
            var loans = await _loanRepository.GetAllAsync();
            foreach (var loan in loans)
            {
                loan.User = await _userRepository.GetByIdAsync(loan.UserId);
                loan.Book = await _bookRepository.GetByIdAsync(loan.BookId);
            }
            return loans;
        }

        public async Task<Loan?> GetLoanByIdAsync(int id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);
            if (loan != null)
            {
                loan.User = await _userRepository.GetByIdAsync(loan.UserId);
                loan.Book = await _bookRepository.GetByIdAsync(loan.BookId);
            }
            return loan;
        }

        public async Task UpdateLoanAsync(Loan loan)
        {
            await _loanRepository.UpdateAsync(loan);
        }

        public async Task RemoveLoanAsync(int id)
        {
            await _loanRepository.RemoveAsync(id);
        }

        public async Task AddLoanAsync(Loan loan)
        {
            var user = await _userRepository.GetByIdAsync(loan.UserId);
            var book = await _bookRepository.GetByIdAsync(loan.BookId);

            if (user == null || book == null)
            {
                throw new Exception("Usuário ou livro não encontrado");
            }

            var userLoans = await _loanRepository.GetLoansByUserIdAsync(loan.UserId);
            if (userLoans.Count >= 3)
            {
                throw new Exception("O usuário já atingiu o limite de 3 livros emprestados");
            }

            if (!await IsBookAvailableAsync(loan.BookId))
            {
                throw new Exception("O livro não está disponível para empréstimo");
            }

            loan.LoanDate = DateTime.Now;
            loan.DueDate = loan.LoanDate.AddDays(10);

            await _loanRepository.AddAsync(loan);
        }

        public async Task<bool> IsBookAvailableAsync(int bookId)
        {
            var activeLoans = await _loanRepository.GetAllAsync();
            return !activeLoans.Any(l => l.BookId == bookId);
        }

        public async Task<List<Book>> GetAvailableBooksAsync()
        {
            var allBooks = await _bookRepository.GetAllAsync();
            var activeLoans = await _loanRepository.GetAllAsync();
            var loanedBookIds = activeLoans.Select(l => l.BookId).ToHashSet();
            return allBooks.Where(b => !loanedBookIds.Contains(b.Id)).ToList();
        }
    }
}