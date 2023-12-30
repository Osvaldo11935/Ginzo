using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class UserResponse
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? DocumentNumber { get; set; }
    
    public static List<UserResponse> UserToUserResponse(List<User> users)
        => users.Select(e => new UserResponse() {
            Name = e.Name,
            Email = e.Email,
            BirthDate = e.BirthDate,
            PhoneNumber = e.PhoneNumber,
            DocumentNumber = e.DocumentNumber,
        }).ToList();
    
    public static UserResponse UserToUserResponse(User user)
        => new UserResponse() {
            Name = user.Name,
            Email = user.Email,
            BirthDate = user.BirthDate,
            PhoneNumber = user.PhoneNumber,
            DocumentNumber = user.DocumentNumber,
        };
}