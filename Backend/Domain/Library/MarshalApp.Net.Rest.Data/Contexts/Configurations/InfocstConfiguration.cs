﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using MarshalApp.Net.Rest.Infrastructure.Data.Contexts;
using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Contexts.Configurations
{
    public partial class InfocstConfiguration : IEntityTypeConfiguration<Infocst>
    {
        public void Configure(EntityTypeBuilder<Infocst> entity)
        {
            entity.HasKey(e => e.Idinfocst)
                .HasName("AK_Inf_cst_Idinfcst");

            entity.ToTable("Infocst");

            entity.Property(e => e.Idinfocst).HasDefaultValueSql("(newid())");

            entity.Property(e => e.Adress1)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Adress2)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Dterequest).HasColumnType("datetime");

            entity.Property(e => e.Idcustomer)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idcustomer");

            entity.Property(e => e.Idtocustomer)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Numprocess)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Ubigeo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UserRequest)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdinfhdrNavigation)
                .WithMany(p => p.Infocsts)
                .HasForeignKey(d => d.Idinfhdr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inf_cst_ToTable");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Infocst> entity);
    }
}