using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerClient([FromBody] ClientDTO client)
    {
        var clientModel = Model.Client.convertDTOToModel(client);
        try
        {
            int id = clientModel.save();
        }
        catch (Exception e)
        {
            return new
            {
                response = new
                {
                    e.Message
                }
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
        Console.WriteLine("1");
        var clientDao =  Model.Client.findByUser(client.login, client.passwd);

        var response = new{
            name = clientDao.name,
            email = clientDao.email,
            birth = clientDao.date_of_birth,
            document = clientDao.document,
            phone = clientDao.phone
        };
        var  retorno = new ObjectResult(response);

        Response.Headers.Add("Access-Control-Allow-Origin", "*");
        Console.WriteLine("2");
        return retorno;
    }
}


