using Microsoft.VisualBasic;
using System.Security.Cryptography;

namespace EmprestimoLivros.Models
{
    public class EmprestimosModel
    {
        public int Id { get; set; }
        public string? Recebedor { get; set; }
        public string? Fornecedor { get; set; }
        public string? LivroEmprestado { get; set; }
        public DateOnly DataEmprestimo { get; private set; }

        public EmprestimosModel()
        {
            DataEmprestimo = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }
    }
}
