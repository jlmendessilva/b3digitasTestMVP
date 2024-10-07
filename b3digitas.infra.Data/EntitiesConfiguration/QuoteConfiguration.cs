using b3digitas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3digitas.Infra.Data.EntitiesConfiguration
{
    internal class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Operation).HasMaxLength(1).IsRequired();
            builder.Property(p => p.Coin).HasMaxLength(3).IsRequired();
            builder.Property(p => p.Quantity).HasMaxLength(30).IsRequired();
            builder.Property(p => p.TotalValue).IsRequired();
            builder.Property(p => p.DateCreated).HasColumnType("timestamp without time zone");

        }
    }
}
