﻿using System.ComponentModel.DataAnnotations;

namespace Atividade_ANP_API.Dtos
{
    public class FornecedorDto
    {
        [Required]
        public string NomeFantasia { get; set; }
        [Required]
        public string RazaoSocial { get; set; }
        [Required]
        public string CNPJ { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Responsavel { get; set; }
    }
}
