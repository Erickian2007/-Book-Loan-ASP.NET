using Microsoft.VisualBasic;

namespace EmprestimoLivros.Models
{
    public class EmprestimosModel
    {
        public int Id { get; set; }
        public string? Recebedor { get; set; }
        public string? Fornecedor { get; set; }
        public string? LivroEmprestado { get; set; }
        public DateAndTime? DataEmprestimo { get; set; }
    }
}
