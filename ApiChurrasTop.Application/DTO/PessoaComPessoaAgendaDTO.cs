using System.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiChurrasTop.Application.Type;

namespace ApiChurrasTop.Application.DTO
{
    public class PessoaComPessoaAgendaDTO
    {
        public Guid Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string TelefoneCelular { get; set; }
        public string Email { get; set; }
        public decimal Valor { get; set; }
        public bool ComBebida { get; set; }
    }
}