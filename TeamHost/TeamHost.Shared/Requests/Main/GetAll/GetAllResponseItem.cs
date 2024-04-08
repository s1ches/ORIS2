namespace TeamHost.Shared.Requests.Main.GetAll;

/// <summary>
/// DTO для игры в Store
/// </summary>
public class GetAllResponseItem
{
    /// <summary>
    /// Id игры
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название игры
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Иконки платформ
    /// </summary>
    public List<string?> PlatformsImageUrls { get; set; }
    
    /// <summary>
    /// Жанры
    /// </summary>
    public List<string> Categories { get; set; }
    
    /// <summary>
    /// Ссылка на главую картинку
    /// </summary>
    public string? MainImageUrl { get; set; }
    
    /// <summary>
    /// Рейтинг
    /// </summary>
    public double Rating { get; set; }
}