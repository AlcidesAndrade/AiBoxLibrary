using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Entities
{
    public class Book
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome do livro")]
        [StringLength(25, ErrorMessage = "O nome deve ter entre 1 até 100 caracteres")]
        public string BookName { get; set; }

        [Required]
        [Display(Name = "Nome do autor")]
        [StringLength(25, ErrorMessage = "O nome deve ter entre 1 até 100 caracteres")]
        public string AutorName { get; set; }

        [Required]
        [Display(Name = "Nome do autor")]
        [StringLength(25, ErrorMessage = "O nome deve ter entre 1 até 100 caracteres")]
        public string PublicData { get; set; }

        [Required]
        [Display(Name = "Unidades no Estoque")]
        [Range(0, Int32.MaxValue, ErrorMessage = "O valor deve ser maior ou igual a 0")]
        public int Units { get; set; }
    }
}
