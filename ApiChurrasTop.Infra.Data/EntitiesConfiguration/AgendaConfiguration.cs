using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIChurrasTop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIChurrasTop.Infra.Data.EntitiesConfiguration
{
    public class AgendaConfiguration : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> entity)
        {
            entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");

            entity.Property(e => e.DataAlteracao)
                .HasColumnType("datetime")
                .HasColumnName("data_alteracao");

            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descricao");

            entity.Property(e => e.Observacao)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("observacao");
        }
    }
}