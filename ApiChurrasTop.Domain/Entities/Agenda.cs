using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIChurrasTop.Domain.PersonalException;

namespace APIChurrasTop.Domain.Entities
{
    public sealed class Agenda : Entity
    {
        public DateTime? DataAlteracao { get; private set; }
        public DateTime Data { get; private set; }
        public string Descricao { get; private set; }
        public string Observacao { get; private set; }

        public ICollection<AgendaPessoa> AgendaPessoas { get; set; }

        public Agenda(Guid Id, DateTime Data, string Descricao, string Observacao)
        {
            this.Validation(Data, Descricao, Observacao);
            this.Id = Id;
            this.AgendaPessoas = new HashSet<AgendaPessoa>();
        }

        public void Update(DateTime data, string descricao, string observacao, ICollection<AgendaPessoa> agendaPessoas)
        {
            this.Validation(data, descricao, observacao);

            this.DataAlteracao = DateTime.Now;
            this.AgendaPessoas = agendaPessoas;
        }

        public void Validation(DateTime data, string descricao, string observacao)
        {
            // validar nome
            DomainExceptionValidation.When(string.IsNullOrEmpty((descricao ?? "").Trim()), Message.ERROR.NOME_DESCRICAO_VAZIO);
            DomainExceptionValidation.When((descricao ?? "").Length <= 3, Message.ERROR.NOME_DESCRICAO_MIN);
            DomainExceptionValidation.When((descricao ?? "").Length > 70, Message.ERROR.NOME_DESCRICAO_MAX);

            // validar nome
            DomainExceptionValidation.When(string.IsNullOrEmpty((descricao ?? "").Trim()), Message.ERROR.NOME_OBSERVACAO_VAZIO);
            DomainExceptionValidation.When((observacao ?? "").Length > 200, Message.ERROR.NOME_OBSERVACAO_MAX);

            //definindo valores
            this.Data = data;
            this.Descricao = descricao;
            this.Observacao = observacao;

        }
    }
}