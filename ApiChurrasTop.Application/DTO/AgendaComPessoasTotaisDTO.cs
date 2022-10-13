using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiChurrasTop.Application.DTO
{
    public class AgendaComPessoasTotaisDTO
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public decimal TotalValor { get; set; }
        public int TotalPessoas { get; set; }
        public HashSet<PessoaComPessoaAgendaDTO> PessoasDTO { get; set; }

        public AgendaComPessoasTotaisDTO()
        {
            this.PessoasDTO = new HashSet<PessoaComPessoaAgendaDTO>();
        }
    }
}