using System.Collections.ObjectModel;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIChurrasTop.Domain.Entities
{
    public sealed class AgendaPessoa : Entity
    {
        public decimal Valor { get; set; }
        public Guid PessoaId { get; set; }
        public Guid AgendaId { get; set; }
        public bool ComBebida { get; set; }

        public Agenda Agenda { get; set; }
        public Pessoa Pessoa { get; set; }

        public AgendaPessoa(Guid Id, decimal Valor)
        {
            this.Id = Id;
            this.Valor = Valor;
        }
    }
}