using System.ComponentModel.DataAnnotations;
using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

/// <summary>
/// Страна
/// </summary>
public class Country : BaseEntity
{
    /// <summary>
    /// числовой код страны
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// короткое название
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// полное название страны
    /// </summary>
    public string Fullname { get; set; }

    /// <summary>
    /// 2х-буквенный код
    /// </summary>
    public string Aplha2 { get; set; }

    /// <summary>
    /// 3х-буквенный код
    /// </summary>
    public string Aplha3 { get; set; }
}