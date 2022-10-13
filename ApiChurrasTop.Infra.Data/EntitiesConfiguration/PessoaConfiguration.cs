using APIChurrasTop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIChurrasTop.Infra.Data.EntitiesConfiguration
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> entity)
        {
            entity.ToTable("Pessoa");

            entity.HasIndex(e => e.CPF, "UN_Pessoa_CPF")
                .IsUnique();

            entity.HasIndex(e => e.Email, "UN_Pessoa_EMAIL")
                .IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.CPF)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("cpf");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");

            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");

            entity.Property(e => e.Senha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("senha");

            entity.Property(e => e.TelefoneCelular)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("telefone");
        }
    }
}