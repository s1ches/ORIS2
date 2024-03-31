using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class Developer : BaseAuditableEntity
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Guid CountryId { get; set; }
    
    public Country Country { get; set; }
    
    public List<Game> Games { get; set; }
    
    /// <summary>
    /// JSON Object
    /// </summary>
    public string Platforms { get; set; }
}