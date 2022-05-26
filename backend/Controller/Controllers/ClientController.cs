using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;

using Model.Utils;

namespace Controller.Controllers;


[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{

    public IConfiguration _configuration; //add

    public ClientController(IConfiguration config){ //add
        _configuration = config;
    }

    [HttpPost]
    [Route("register")]
    public object registerClient([FromBody] ClientDTO client)
    {
        var clientModel = Model.Client.convertDTOToModel(client);
        try
        {
            int id = clientModel.save();
        }
        catch (ValidationException ex)
        {   
            var response = ex.Errors;
            return new
            {
                response = response
            };
        }
        return new
        {
            response = "Sucess"
        };



    }

    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(String document)
    {

        var client = Model.Client.find(document);

        return client;
    }

    [HttpPost]
    [Route("login")]
    public IActionResult checkLogin([FromBody] ClientDTO client)
    {
        // if(client == null)
        // {
        //     return BadRequest("Error 4584654");
        // }
        var clientDTO =  Model.Client.findByUser(client.login, client.passwd); // arrumar o metodo
       
        if(clientDTO != null){
            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim("UserId", clientDTO.Id.ToString()),
                new Claim("UserName", clientDTO.name.ToString()),
                new Claim("Email", clientDTO.email.ToString())

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials:singIn);
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
        else
        {
            return BadRequest();
        }
        
    }
}


