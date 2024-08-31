using System.ComponentModel.DataAnnotations;

namespace BlazorComponent.Models
{
    public class Medico
    {
        private static int autoId = 1;

        public Medico()
        {
            Id = generateId();
            Name = "Eder Sena";
            CRM = "123452";
        }

        public int Id { get; private set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter entre 3 e 50 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo CRM é obrigatório")]
        public string CRM { get; set; } = string.Empty;

        private static int generateId()
        {
            return autoId++;
        }

        public void Update(string name, string crm)
        {
            Name = name;
            CRM = crm;
        }
    }
}
