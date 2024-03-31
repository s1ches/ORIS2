using System.ComponentModel.DataAnnotations;
using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class Country: BaseEntity
{
    /// <summary>
    /// Короткое название
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Числовой код страны
    /// </summary>
    public int Code { get; set; }
    
    /// <summary>
    /// Полное название страны
    /// </summary>
    public string FullName { get; set; }
    
    /// <summary>
    /// 2х-буквенный код
    /// </summary>
    [MaxLength(2)]
    public string Alpha2 { get; set; }
    
    /// <summary>
    /// 3х-буквенный код
    /// </summary>
    [MaxLength(3)]
    public string Alpha3 { get; set; }

    /// <summary>
    /// Список разработчиков
    /// </summary>
    public virtual List<Developer> Developers { get; set; }
}