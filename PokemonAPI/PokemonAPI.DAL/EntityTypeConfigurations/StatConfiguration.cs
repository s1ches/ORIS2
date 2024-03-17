using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.DAL.Entities;

namespace PokemonAPI.DAL.EntityTypeConfigurations;

public class StatConfiguration : IEntityTypeConfiguration<Stat>
{
    public void Configure(EntityTypeBuilder<Stat> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Pokemon)
            .WithMany(x => x.Stats)
            .HasForeignKey(x => x.PokemonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.StatValue).IsRequired();
        builder.Property(x => x.StatName).IsRequired().HasMaxLength(50);
        
        builder.HasIndex(x => x.PokemonId);
    }
}