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
    public class AlertTypeConfig : IEntityTypeConfiguration<AlertType>
    {
        public void Configure(EntityTypeBuilder<AlertType> builder)
        {
            builder.ToTable("alert_type");
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(h => h.Alert).HasColumnName("alert");            
        }
    }
}
