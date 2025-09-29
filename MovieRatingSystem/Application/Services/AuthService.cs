using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MovieRatingSystem.Application.DTOs;
using MovieRatingSystem.Domain;
using MovieRatingSystem.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieRatingSystem.Application.Services;

public class AuthService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<AuthResult> LoginAsync(LoginInput model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            return new AuthResult { Success = false, Errors = new[] { "Invalid login attempt." } };

        var token = await GenerateJwtToken(user);
        return new AuthResult { Success = true, Token = token };
    }

    private async Task<string> GenerateJwtToken(ApplicationUser user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, (await _userManager.GetRolesAsync(user)).FirstOrDefault() ?? "User")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SharedConstants.JwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: SharedConstants.JwtIssuer,
            audience: SharedConstants.JwtAudience,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}