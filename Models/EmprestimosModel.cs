using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace EmprestimoLivros.Models
{
    public class EmprestimosModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Coloque Um Recebedor")]
        public string? Recebedor { get; set; }
        
        [Required(ErrorMessage = "Coloque Um Fornecedor")]
        public string? Fornecedor { get; set; }
        
        [Required(ErrorMessage = "Coloque Um Livro Para Fazer Emprestimo")]
        public string? LivroEmprestado { get; set; }
        public DateOnly DataEmprestimo { get; private set; }

        public EmprestimosModel()
        {
            DataEmprestimo = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }
    }
}
