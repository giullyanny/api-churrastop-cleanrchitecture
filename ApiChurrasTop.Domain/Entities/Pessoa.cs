using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIChurrasTop.Domain.PersonalException;

namespace APIChurrasTop.Domain.Entities
{
    public sealed class Pessoa : Entity
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string TelefoneCelular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<AgendaPessoa> AgendaPessoas { get; set; }

        public Pessoa(Guid Id, string CPF, string Nome, string TelefoneCelular, string Email, string Senha)
        {
            this.Validation(CPF, Nome, TelefoneCelular, Email, Senha);
            this.Id = Id;
            this.AgendaPessoas =  new HashSet<AgendaPessoa>();
        }

        public void Update(string cpf, string nome, string telefoneCelular, string email, string senha, ICollection<AgendaPessoa> agendaPessoas)
        {
            this.Validation(cpf, nome, telefoneCelular, email, senha);
            this.AgendaPessoas = agendaPessoas;
        }

        public void Validation(string cpf, string nome, string telefoneCelular, string email, string senha)
        {
            // validar nome
            DomainExceptionValidation.When(string.IsNullOrEmpty((nome ?? "").Trim()), Message.ERROR.NOME_PESSOA_VAZIO);
            DomainExceptionValidation.When((nome ?? "").Length <= 10, Message.ERROR.NOME_PESSOA_MIN);
            DomainExceptionValidation.When((nome ?? "").Length > 70, Message.ERROR.NOME_PESSOA_MAX);

            // validar telefoneCelular
            bool isEmailInvalid = true;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                isEmailInvalid = addr.Address == email;
                isEmailInvalid = false;
            }
            catch { }
            DomainExceptionValidation.When(isEmailInvalid, Message.ERROR.EMAIL_INVALIDO);
            DomainExceptionValidation.When(email.Length > 100, Message.ERROR.NOME_EMAIL_MAX);

            //validar senha
            DomainExceptionValidation.When(((senha ?? "").Length < 10 && (senha ?? "").Length > 20), Message.ERROR.SENHA_INVALIDA);

            //definindo valores
            this.CPF = cpf;
            this.Nome = nome;
            this.TelefoneCelular = telefoneCelular;
            this.Email = email;
            this.Senha = senha;
        }
    }
}