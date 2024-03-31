namespace TeamHost.Shared.Requests.Main.GetById;

public class GetByIdRequest
{
    public GetByIdRequest(GetByIdRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        Id = request.Id;
    }
    
    public GetByIdRequest()
    {
    }
    
    /// <summary>
    /// Id игры в базе данных
    /// </summary>
    public int Id { get; set; }
}