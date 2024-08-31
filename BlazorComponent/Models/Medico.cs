using System.ComponentModel.DataAnnotations;

namespace BlazorComponent.Models
{
    public class Medico
    {
        [Required(ErrorMessage = "O campo ID é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter entre 3 e 50 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo CRM é obrigatório")]
        [MaxLength(6, ErrorMessage = "CRM deve ter no máximo 6 caracteres")]
        public string CRM { get; set; } = string.Empty;

       

        public void Update(string name, string crm)
        {
            Name = name;
            CRM = crm;
        }
    }
}
