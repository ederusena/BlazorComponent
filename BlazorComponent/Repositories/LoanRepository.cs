using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazorComponent.Models;

namespace BlazorComponent.Repositories
{
    public class LoanRepository : IRepository<Loan>
    {
        private readonly List<Loan> _loans = new();
        private int _nextId = 1;

        public Task AddAsync(Loan entity)
        {
            entity.Id = _nextId++;
            _loans.Add(entity);
            return Task.CompletedTask;
        }

        public Task<List<Loan>> GetAllAsync()
        {
            return Task.FromResult(_loans.ToList());
        }

        public Task<Loan?> GetByIdAsync(int id)
        {
            return Task.FromResult(_loans.FirstOrDefault(x => x.Id == id));
        }

        public Task RemoveAsync(int id)
        {
            var loan = _loans.FirstOrDefault(x => x.Id == id);
            if (loan != null)
            {
                _loans.Remove(loan);
            }
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Loan loan)
        {
            var existingLoan = _loans.FirstOrDefault(x => x.Id == loan.Id);
            if (existingLoan != null)
            {
                existingLoan.Update(loan.UserId, loan.BookId);
            }
            return Task.CompletedTask;
        }

        public Task<List<Loan>> GetLoansByUserIdAsync(int userId)
        {
            return Task.FromResult(_loans.Where(x => x.UserId == userId).ToList());
        }
    }
}