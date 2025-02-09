﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class PessoaViewModel
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo código é obrigatório")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string? Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo cpf é obrigatório")]
        [StringLength(11, ErrorMessage = "No minímo 11 caracteres e no máximo 11.", MinimumLength = 11)]
        public string? Cpf { get; set; }
        [Display(Name = "Idade")]
        public int Idade { get; set; }
        [Display(Name = "Rua")]
        [StringLength(50, ErrorMessage = "No minímo 1 caracteres e no máximo 50.", MinimumLength = 1)]
        public string? Rua { get; set; }
        [Display(Name = "Bairro")]
        [StringLength(40, ErrorMessage = "No minímo 1 caracteres e no máximo 40.", MinimumLength = 1)]
        public string? Bairro { get; set; }
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Campo data de nascimento é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; }

       
    }
}
