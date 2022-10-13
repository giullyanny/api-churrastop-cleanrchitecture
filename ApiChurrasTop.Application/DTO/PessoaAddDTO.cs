using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiChurrasTop.Application.Type;

namespace ApiChurrasTop.Application.DTO
{
    public class PessoaAddDTO
    {
        [Required(ErrorMessage = "CPF da pessoa deve ser informada!")]
        [MaxLength(14)]
        public CPF CPF { get; set; }

        [Required(ErrorMessage = "Nome da pessoa deve ser informada!")]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Celular da pessoa deve ser informada!")]
        [MaxLength(14)]
        public Celular TelefoneCelular { get; set; }

        [Required(ErrorMessage = "Email da pessoa deve ser informada!")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha da pessoa deve ser informada com no máximo 8 caracteres!")]
        [MinLength(8)]
        public string Senha { get; set; }
    }
}