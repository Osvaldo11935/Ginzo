using System.Security.Claims;
using Application.Common.Interfaces.IRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    #region Properties and builders

    private readonly RoleManager<Role> _roleManager;
    private readonly UserManager<User> _userManager;


    public UserRepository(ApplicationDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager) :
        base(context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    #endregion

    #region SignIn
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<IList<string>> FindRoleByUser(User user) 
        => await _userManager.GetRolesAsync(user);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<bool> CheckPasswordAsync(User user, string password)
        => await _userManager.CheckPasswordAsync(user, password);
    #endregion

    #region SignUp
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<IdentityResult> SignUpAsync(User? user, string password)
        => await _userManager.CreateAsync(user!, password);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public async Task<IdentityResult> AddRoleToUserAsync(User user, string role)
        => await _userManager.AddToRoleAsync(user, role);

    #endregion

    #region ForgotPassword
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<string> GeneratePasswordResetTokenAsync(User user)
        => await _userManager.GeneratePasswordResetTokenAsync(user);
    #endregion

    #region ResetPassword

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="resetToken"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    public async Task<IdentityResult> ResetPasswordAsync(User user, string resetToken, string newPassword)
    => await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
        

    #endregion

    #region ChangePassword
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="currentPassword"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    public async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        => await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

    #endregion

    #region Claim
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<List<Claim>> SelectClaimUserAndRoleAsync(User user)
    {
        List<Claim> claims = new List<Claim>();

        IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);

        claims.AddRange(userClaims);

        IList<string> userRoles = await _userManager.GetRolesAsync(user);

        claims = await AddClaimToRoleAsync(userRoles, claims);

        return claims;
    }

    #endregion

    #region Aux
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userRoles"></param>
    /// <param name="claims"></param>
    /// <returns></returns>
    private async Task<List<Claim>> AddClaimToRoleAsync(IList<string> userRoles, List<Claim> claims)
    {
        foreach (var userRole in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, userRole));
            var role = await _roleManager.FindByNameAsync(userRole);
            if (role == null) continue;

            var roleClaims = await _roleManager.GetClaimsAsync(role);

            foreach (var roleClaim in roleClaims)
            {
                if (claims.Contains(roleClaim)) continue;
                claims.Add(roleClaim);
            }
        }

        return claims;
    }

    #endregion
}