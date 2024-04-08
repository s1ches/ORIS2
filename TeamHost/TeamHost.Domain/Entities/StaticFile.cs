using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

/// <summary>
/// Файл
/// </summary>
public class StaticFile: BaseAuditableEntity
{
    /// <summary>
    /// Имя
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Путь
    /// </summary>
    public string? Path { get; set; }
}