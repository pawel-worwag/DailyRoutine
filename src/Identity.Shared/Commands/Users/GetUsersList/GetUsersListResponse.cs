namespace Identity.Shared.Commands.Users.GetUsersList;

public class GetUsersListResponse
{
    public int Count { get; set; }
    public ICollection<UserDto> Users { get; set; } = new List<UserDto>();
}