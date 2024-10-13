using System.Security.Claims;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Common.Interfaces.IRepositories;

public interface IUserRepository
{
     #region SignIn

     /// <summary>
     /// 
     /// </summary>
     /// <param name="user"></param>
     /// <returns></returns>
     Task<IList<string>> FindRoleByUser(User user);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<bool> CheckPasswordAsync(User user, string password);
    #endregion

    #region SignUp

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<IdentityResult> SignUpAsync(User? user, string password);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    Task<IdentityResult> AddRoleToUserAsync(User user, string role);

    #endregion

    #region ForgotPassword

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<string> GeneratePasswordResetTokenAsync(User user);
    #endregion

    #region ResetPassword

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="resetToken"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    Task<IdentityResult> ResetPasswordAsync(User user, string resetToken, string newPassword);


    #endregion

    #region ChangePassword

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="currentPassword"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);

    #endregion

    #region Claim

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<List<Claim>> SelectClaimUserAndRoleAsync(User user);

    #endregion
}