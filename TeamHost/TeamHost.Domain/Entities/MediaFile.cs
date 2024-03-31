using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class MediaFile : BaseAuditableEntity
{
    public string Url { get; set; }
}