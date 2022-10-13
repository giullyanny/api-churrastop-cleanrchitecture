using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIChurrasTop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIChurrasTop.Infra.Data.EntitiesConfiguration
{
    public class AgendaPessoaConfiguration : IEntityTypeConfiguration<AgendaPessoa>
    {
        public void Configure(EntityTypeBuilder<AgendaPessoa> entity)
        {
            entity.ToTable("AgendaPessoa");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.AgendaId).HasColumnName("agenda_id");

            entity.Property(e => e.PessoaId).HasColumnName("pessoa_id");

            entity.Property(e => e.Valor)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor");

            entity.HasOne(d => d.Agenda)
                .WithMany(p => p.AgendaPessoas)
                .HasForeignKey(d => d.AgendaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgendaPessoa_Agenda");

            entity.HasOne(d => d.Pessoa)
                .WithMany(p => p.AgendaPessoas)
                .HasForeignKey(d => d.PessoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgendaPessoa_Pessoa");
        }
    }
}