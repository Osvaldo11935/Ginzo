using Domain.Entities;

namespace Domain.Common.Aggregates;

public class UserAggregate
{
    #region Write
    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="name"></param>
    /// <param name="birthDate"></param>
    /// <param name="documentNumber"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    public User AddUser(string? email, string? name, DateTime birthDate,
        string? documentNumber, string? phoneNumber, string? userName)
    {
        return new User {
            Name = name,
            Email = email,
            UserName = userName,
            BirthDate = birthDate,
            PhoneNumber = phoneNumber,
            DocumentNumber = documentNumber
        };
    }

    #endregion
}