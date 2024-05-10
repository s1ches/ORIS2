using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.DAL.Entities;

namespace PokemonAPI.DAL.EntityTypeConfigurations;

public class BreedingConfiguration : IEntityTypeConfiguration<Breeding>
{
    public void Configure(EntityTypeBuilder<Breeding> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Pokemon)
            .WithOne(y => y.Breeding)
            .HasForeignKey<Breeding>(x => x.PokemonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Height).IsRequired();
        builder.Property(x => x.Weight).IsRequired();

        builder.HasIndex(x => x.PokemonId);
    }
}