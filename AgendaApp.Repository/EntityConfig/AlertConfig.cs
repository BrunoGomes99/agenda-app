using AgendaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Repository.EntityConfig
{
    public class AlertConfig : IEntityTypeConfiguration<Alert>
    {
        public void Configure(EntityTypeBuilder<Alert> builder)
        {
            builder.ToTable("alerta");
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(h => h.Title).HasColumnName("titulo");
            builder.Property(h => h.Description).HasColumnName("descricao");
            builder.Property(h => h.IdAlertType).HasColumnName("id_tipo_alerta");
            builder.Property(h => h.Date).HasColumnName("data");
        }
    }
}
