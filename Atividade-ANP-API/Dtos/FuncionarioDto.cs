using System.ComponentModel.DataAnnotations;

namespace Atividade_ANP_API.Dtos
{
    public class FuncionarioDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string CTPS { get; set; }
        [Required]
        public string RG { get; set; }
        [Required]
        public string Funcao { get; set; }
        [Required]
        public string Setor { get; set; }
        [Required]
        public string Sala { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Endereco { get; set; }
    }
}
