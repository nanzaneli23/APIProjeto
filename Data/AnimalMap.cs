﻿using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class AnimalMap :  IEntityTypeConfiguration<AnimalModel>
    {
        public void Configure(EntityTypeBuilder<AnimalModel> builder)
        {
            builder.HasKey(x => x.AnimalId);
            builder.Property(x => x.NomeAnimal).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalRaca).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalTipo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalCor).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalSexo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalObservacao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalFoto).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalDtDesaperecimento).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalDtEncontro);
            builder.Property(x => x.AnimalStatus).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioId);




        }
    }
}
