using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace BlazorComponent.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo ID do Usuário é obrigatório")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "O campo ID do Livro é obrigatório")]
        public int BookId { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }

        public User? User { get; set; }
        public Book? Book { get; set; }

        public void Update(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
            LoanDate = DateTime.Now;
            DueDate = LoanDate.AddDays(10);
        }
    }
}