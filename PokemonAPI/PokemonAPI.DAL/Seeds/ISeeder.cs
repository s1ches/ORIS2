namespace PokemonAPI.DAL.Seeds;

public interface ISeeder
{
    public Task SeedAsync(CancellationToken cancellationToken = default);
}