using System.ComponentModel.DataAnnotations;
using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class Game : BaseAuditableEntity
{
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Короткое описание
    /// </summary>
    [MaxLength(256)]
    public string ShortDescription{ get; set; }

    /// <summary>
    /// Главное изображение
    /// </summary>
    public StaticFile? MainImage { get; set; }

    /// <summary>
    /// Изображения
    /// </summary>
    public List<StaticFile>? Images { get; set; }

    /// <summary>
    /// Рейтинг
    /// </summary>
    public float Rating { get; set; }

    /// <summary>
    /// Категория
    /// </summary>
    public List<Category> Categories { get; set; }

    /// <summary>
    /// Дата релиза
    /// </summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Платформа
    /// </summary>
    public List<Platform> Platforms { get; set; }

    /// <summary>
    /// Компания-разработчик
    /// </summary>
    public Company CompanyDeveloper { get; set; }
    
    /// <summary>
    /// Количество оценок игры
    /// </summary>
    public int RatingsNumber { get; set; }
}