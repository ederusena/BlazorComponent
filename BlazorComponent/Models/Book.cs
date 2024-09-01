using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace BlazorComponent.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo Nome deve ter entre 1 e 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Autor é obrigatório")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo Autor deve ter entre 2 e 50 caracteres")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo ISBN é obrigatório")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "O campo ISBN deve ter entre 10 e 13 caracteres")]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Data de Lançamento é obrigatório")]
        public DateTime ReleaseDate { get; set; }

        public void Update(string name, string author, string isbn, DateTime releaseDate)
        {
            Name = name;
            Author = author;
            ISBN = isbn;
            ReleaseDate = releaseDate;
        }
    }
}