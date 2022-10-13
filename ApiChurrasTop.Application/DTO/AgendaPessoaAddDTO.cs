using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiChurrasTop.Application.DTO
{
    public sealed class AgendaPessoaAddDTO
    {
        [Required(ErrorMessage = "Nome do evento deve ser informada!")]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Required]
        public bool ComBebida { get; set; }
        
        [Required(ErrorMessage = "Pessoa do evento deve ser informada!")]
        public Guid PessoaId { get; set; }        
        
        [Required(ErrorMessage = "Evento deve ser informada!")]
        public Guid AgendaId { get; set; }
    }
}