using DataAccessLayer.Model.User;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using StudentManagementSystem.Controllers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagementSystem.Services
{
    public static class TokenGeneratorService
    {
        public static string GenerateToken(TokenGenerateDetail user, IConfiguration configuration)
        {
            var claims = GetClaims(user);
            return GetToken(claims, configuration);
        }

        private static string GetToken(List<Claim> claims, IConfiguration configuration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience : configuration["Jwt:Audience"],
                claims,
                signingCredentials: credentials
                );

            if (securityToken == null)
                return "Not available";
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;   
        }

        private static List<Claim> GetClaims(TokenGenerateDetail user)
        {
           List<Claim> claims = new List<Claim>
           {
               new Claim("id",user.UserId),
               new Claim(JwtRegisteredClaimNames.UniqueName, user.FullName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("FullName", user.FullName),
                new Claim("PhoneNumber", user.Phone),
                new Claim("UserName", user.UserName),
                new Claim("UserType", user.UserType.ToString()),
                new Claim("Address", user.Address),
                new Claim("StudnetId", user.StudentId.ToString())
           };
            return claims;
        }
    }
}
