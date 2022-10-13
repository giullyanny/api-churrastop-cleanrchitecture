using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiChurrasTop.Application.DTO
{
    public class AgendaAddDTO
    {
        [Required(ErrorMessage = "Data do evento deve ser informada!")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Nome do evento deve ser informada!")]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [MaxLength(200)]
        public string Observacao { get; set; }
    }
}