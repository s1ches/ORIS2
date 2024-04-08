namespace TeamHost.Shared.Requests.Main.GetAll;

/// <summary>
/// DTO игр в Store
/// </summary>
public class GetAllResponse
{
    public List<GetAllResponseItem> Games { get; set; }
}