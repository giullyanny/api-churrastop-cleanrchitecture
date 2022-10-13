using System;
using Xunit;
using APIChurrasTop.Domain.Entities;
using FluentAssertions;

namespace ApiChurrasTop.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Testando dominio Pessoal com parametos válidos")]
    public void CriarPessoa_ComParametrosValidos_ResultadoObj()
    {
        Action action = () => new Pessoa(Guid.NewGuid(), "07515361050", "Rafael Marcelo Caldeira", "(62)99977-9194", "eduardo.giullyanny@gmail.com", "12345678");

        action.Should().NotThrow<APIChurrasTop.Domain.PersonalException.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Testando dominio Pessoal com email inválido")]
    public void CriarPessoa_ComEmailInvalido_ResultadoException()
    {
        Action action = () => new Pessoa(Guid.NewGuid(), "07515361050", "Rafael Marcelo Caldeira", "(62)99977-9194", "eduardo.giullyaail.com", "12345678");

        action.Should().Throw<APIChurrasTop.Domain.PersonalException.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Testando dominio Pessoal com cpf inválido")]
    public void CriarPessoa_ComCPFInvalido_ResultadoException()
    {
        Action action = () => new Pessoa(Guid.NewGuid(), "07515361090", "Rafael Marcelo Caldeira", "(62)99977-9194", "eduardo.giullyanny@gmail.com", "12345678");

        action.Should().Throw<APIChurrasTop.Domain.PersonalException.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Testando dominio Pessoal com celular inválido")]
    public void CriarPessoa_ComCelularInvalido_ResultadoException()
    {
        Action action = () => new Pessoa(Guid.NewGuid(), "07515361090", "Rafael Marcelo Caldeira", "99977-9194", "eduardo.giullyail.com", "12345678");

        action.Should().Throw<APIChurrasTop.Domain.PersonalException.DomainExceptionValidation>();
    }
    }
}
