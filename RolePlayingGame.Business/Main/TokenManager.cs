using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RolePlayingGame.Entities.Dtos;
using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Business.Main
{
    public class TokenManager
    {
        IConfiguration configuration;

        public TokenManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }



        public string CreateAccessToken(Player player)
        {

            Claim[] claims = new Claim[]
            {
                 new Claim("id", player.PlayerId.ToString()),
                 new Claim("username", player.Username)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken token = new JwtSecurityToken
                (
                 issuer: configuration["Tokens:Issuer"],//distributor
                 audience: configuration["Tokens:Issuer"],//receivers  - configuration["Tokens:Audience"]
                 expires: DateTime.Now.AddMinutes(50),
                 notBefore: DateTime.Now,
                 signingCredentials: signingCredentials,
                 claims: claimsIdentity.Claims
                );



            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string createdTokenString = tokenHandler.WriteToken(token);

            return createdTokenString;
        }













    }
}
