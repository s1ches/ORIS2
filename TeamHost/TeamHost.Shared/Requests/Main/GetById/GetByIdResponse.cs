using TeamHost.Shared.Requests.Main.GetAll;

namespace TeamHost.Shared.Requests.Main.GetById;

public class GetByIdResponse : GetAllResponseItem
{
    public string? Description { get; set; }
    
    public List<string?> ImagesUrls { get; set; }
    
    public int RatingsNumber { get; set; }
    
    public DateTime ReleaseDate { get; set; }
    
    public string CompanyName { get; set; }
}